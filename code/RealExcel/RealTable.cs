using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RealExcel
{
    class RealTable
    {
        private DataGridView dataGridView;
        public bool hasBeenSaved;
        public string storagePath;
        public List<List<RealCell>> cells = new List<List<RealCell>>();
        private int columnsAmount = 7;
        private int rowsAmount = 10;
        
        public RealTable(ref DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
            InitializeColumns();
            InitializeRows();
            InitializeCells();
        }
        private void InitializeColumns()
        {
            dataGridView.Columns.Clear();
            for (int columnIndex = 0; columnIndex != columnsAmount; ++columnIndex)
            {
                dataGridView.Columns.Add(ExcelBaseRepresentor.ConvertToPseudo26Base(columnIndex + 1),
                    ExcelBaseRepresentor.ConvertToPseudo26Base(columnIndex + 1));
            }
        }
        private void InitializeRows()
        {
            dataGridView.Rows.Clear();
            for (int rowIndex = 0; rowIndex != rowsAmount; ++rowIndex)
            {
                dataGridView.Rows.Add(1);
                dataGridView.Rows[rowIndex].HeaderCell.Value = (rowIndex + 1).ToString();
            }
        }
        private void InitializeCells()
        {
            for (int rowIndex = 0; rowIndex != rowsAmount; ++rowIndex)
            {
                var cellsRow = new List<RealCell>();
                for (int columnIndex = 0; columnIndex != columnsAmount; ++columnIndex)
                {
                    cellsRow.Add(new RealCell(rowIndex, columnIndex));
                }
                cells.Add(cellsRow);
            }
        }
        public void Reset()
        {
            columnsAmount = 7;
            rowsAmount = 10;
            InitializeColumns();
            InitializeRows();
            InitializeCells();
        }
        public void AddRow()
        {
            ++rowsAmount;
            var cellsRow = new List<RealCell>();
            for (int columnIndex = 0; columnIndex != columnsAmount; ++columnIndex)
            {
                cellsRow.Add(new RealCell(rowsAmount - 1, columnIndex));
            }
            cells.Add(cellsRow);
            dataGridView.Rows.Add(1);
            dataGridView.Rows[dataGridView.Rows.Count - 1].HeaderCell.Value =
                (dataGridView.Rows.Count).ToString();
            UpdateAllCells();
        }
        public void AddColumn()
        {
            ++columnsAmount;
            dataGridView.Columns.Add(ExcelBaseRepresentor.ConvertToPseudo26Base(columnsAmount),
                    ExcelBaseRepresentor.ConvertToPseudo26Base(columnsAmount));

            for (int rowIndex = 0; rowIndex != rowsAmount; ++rowIndex)
            { 
                cells[rowIndex].Add(new RealCell(rowIndex, columnsAmount - 1));
            }
            UpdateAllCells();
        }
        public void DeleteRow()
        {
            if (rowsAmount == 1) return;
            foreach(var cell in cells[rowsAmount - 1])
            {
                cell.Evaluation = "valueToCauseParsingError";
                UpdateDependentOnMeCells(cell.rowIndex, cell.columnIndex);
                var currentCell = cell;
                DeleteExpiredDependenciesOnMe(ref currentCell);
            }
            cells.RemoveAt(rowsAmount - 1);
            dataGridView.Rows.RemoveAt(rowsAmount - 1);
            --rowsAmount;
        }
        public void DeleteColumn()
        {
            if (columnsAmount == 1) return;
            for (int i = 0; i != rowsAmount; ++i)
            {
                cells[i][columnsAmount - 1].Evaluation = "valueToCauseParsingError";
                UpdateDependentOnMeCells(i, columnsAmount - 1);
                var currentCell = cells[i][columnsAmount - 1];
                DeleteExpiredDependenciesOnMe(ref currentCell);
                cells[i].RemoveAt(columnsAmount - 1);
            }
            dataGridView.Columns.RemoveAt(columnsAmount - 1);
            --columnsAmount;
        }
        public void SaveToCSV(string filePath)
        {
            hasBeenSaved = true;
            storagePath = filePath;
            const char delimiter = '$';
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{rowsAmount.ToString()}{delimiter}{columnsAmount.ToString()}");
            foreach (var cellRow in cells)
            {
                StringBuilder line = new StringBuilder();
                foreach (var cell in cellRow)
                {
                    line.Append($"{cell.Expression}{delimiter}");
                }
                output.AppendLine(line.ToString());
            }
            File.WriteAllText(filePath, output.ToString());
        }
        public void OpenFromCSV(string filePath)
        {
            hasBeenSaved = true;
            storagePath = filePath;
            const char delimiter = '$';
            using (var reader = new StreamReader(filePath))
            {
                var size = reader.ReadLine().Split(delimiter);
                rowsAmount = int.Parse(size[0]);
                columnsAmount = int.Parse(size[1]);
                InitializeColumns();
                InitializeRows();

                cells = new List<List<RealCell>>();
                for (int rowIndex = 0; rowIndex != rowsAmount; ++rowIndex)
                {
                    var line = reader.ReadLine();
                    var expressions = line.Split(delimiter);
                    var cellsRow = new List<RealCell>();
                    for (int columnIndex = 0; columnIndex != columnsAmount; ++columnIndex)
                    {
                        cellsRow.Add(new RealCell(rowIndex, columnIndex, expressions[columnIndex]));
                    }
                    cells.Add(cellsRow);
                }
            }
            UpdateAllCells();
        }
        private void UpdateAllCells()
        {
            for(int rowIndex = 0; rowIndex != rowsAmount; ++rowIndex)
            {
                for(int columnIndex = 0; columnIndex != columnsAmount; ++columnIndex)
                {
                    UpdateCell(rowIndex, columnIndex);
                    UpdateDependentOnMeCells(rowIndex, columnIndex);
                    dataGridView.Rows[rowIndex].Cells[columnIndex].Value 
                        = cells[rowIndex][columnIndex].Evaluation;
                }
            }
        }
        public void UpdateDependentOnMeCells(int rowIndex, int columnIndex)
        {
            var cell = cells[rowIndex][columnIndex];
            if (cell.hasDependencyCycle)
            {
                UpdateCellsInDependencyCycle(rowIndex, columnIndex);
                return;
            }
            foreach (var dependentCell in cell.dependentOnMeCells.ToList())
            {
                UpdateCell(dependentCell.rowIndex, dependentCell.columnIndex);
                dataGridView.Rows[dependentCell.rowIndex].Cells[dependentCell.columnIndex].Value 
                    = dependentCell.Evaluation;
                UpdateDependentOnMeCells(dependentCell.rowIndex, dependentCell.columnIndex);
            }
        }
        private void UpdateCellsInDependencyCycle(int rowIndex, int columnIndex)
        {
            var linkedCells = new HashSet<RealCell>() { cells[rowIndex][columnIndex] };
            var visited = new Dictionary<RealCell, bool>();
            linkedCells = GatherCellsInDependencyCycle(linkedCells, visited);
            foreach (var cell in linkedCells)
            {
                cell.Evaluation = cell.Expression;
                cell.hasDependencyCycle = true;
                dataGridView.Rows[cell.rowIndex].Cells[cell.columnIndex].Value = cell.Evaluation;
            }
        }
        private HashSet<RealCell> GatherCellsInDependencyCycle(HashSet<RealCell> current, 
            Dictionary<RealCell, bool> visited)
        {
            foreach (var cell in current.ToList())
            {   if (visited.ContainsKey(cell))
                {
                    if (!visited[cell])
                    {
                        visited[cell] = true;
                        current.UnionWith(GatherCellsInDependencyCycle(cell.dependentOnMeCells, visited));
                    }
                }
                else
                {
                    visited.Add(cell, true);
                    current.UnionWith(GatherCellsInDependencyCycle(cell.dependentOnMeCells, visited));
                }
            }
            return current;
        }
        public void UpdateCell(int rowIndex, int columnIndex)
        {
            var cell = cells[rowIndex][columnIndex];
            if (cell.Expression == null || cell.Expression == "") return;
            cell.Evaluation = cell.Expression;
            try
            {
                cell.cellsIDependOn = GetCellsHashSet(cell.Expression);
                UpdateDependenciesOnMe(ref cell);
                var expressionWithoutReferences = ReplaceCellsReferences(cell.Expression);
                if (cell.CheckForDependenciesCycle(ref cell))
                {
                    cell.hasDependencyCycle = true;
                    throw new Exception("Dependency cycle");
                }
                cell.hasDependencyCycle = false;
                cell.Evaluation = RealEvaluator.EvaluateExpression(expressionWithoutReferences).ToString();
            }
            catch
            {
                return;
            }
        }
        private HashSet<RealCell> GetCellsHashSet(string expression)
        {
            HashSet<RealCell> cellsInExpression = new HashSet<RealCell>();
            const string pattern = @"[A-Z]+[0-9]+";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            foreach(Match match in regex.Matches(expression))
            {
                string cellAddress = match.Value;
                var rowIndex = Int32.Parse(Regex.Replace(cellAddress, @"\D", string.Empty)) - 1;
                var columnIndexInPseudo26Base = Regex.Replace(cellAddress, @"[\d-]", string.Empty);
                var columnIndex = ExcelBaseRepresentor.ConvertFromPseudo26Base(columnIndexInPseudo26Base) - 1;
                try
                {
                    cellsInExpression.Add(cells[rowIndex][columnIndex]);
                }
                catch
                {
                    throw new Exception("Non-existing cell reference");
                }
            }
            return cellsInExpression;
        }
        private void UpdateDependenciesOnMe(ref RealCell currentCell)
        {
            DeleteExpiredDependenciesOnMe(ref currentCell);
            SetDependenciesOnMe(ref currentCell);
        }
        private void DeleteExpiredDependenciesOnMe(ref RealCell currentCell)
        {
            foreach(var cellRow in cells)
            {
                foreach(var cell in cellRow)
                {
                    if (cell.dependentOnMeCells.Contains(currentCell))
                    {
                        cell.dependentOnMeCells.Remove(currentCell);
                    }
                }
            }
        }
        private void SetDependenciesOnMe(ref RealCell currentCell)
        {
            foreach (var cell in currentCell.cellsIDependOn)
            {
                cell.dependentOnMeCells.Add(currentCell);
            }
        }
        private string ReplaceCellsReferences(string expression)
        {
            const string pattern = @"[A-Z]+[0-9]+";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchEvaluator matchEvaluator = new MatchEvaluator(BindValueToAddress);
            return regex.Replace(expression, matchEvaluator);
        }
        private string BindValueToAddress(Match match)
        {
            string cellAddress = match.Value;
            var rowIndex = Int32.Parse(Regex.Replace(cellAddress, @"\D", string.Empty)) - 1;
            var columnIndexInPseudo26Base = Regex.Replace(cellAddress, @"[\d-]", string.Empty);
            var columnIndex = ExcelBaseRepresentor.ConvertFromPseudo26Base(columnIndexInPseudo26Base) - 1;
            try
            {
                var cellValue = cells[rowIndex][columnIndex].Evaluation.ToString();
                return cellValue;
            }
            catch
            {
                throw new Exception("Null value reference");
            }
        }
    }
}
