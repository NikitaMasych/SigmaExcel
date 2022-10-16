using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealExcel
{
    class RealTable
    {
        private DataGridView dataGridView;
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
            for (int columnIndex = 0; columnIndex != columnsAmount; ++columnIndex)
            {
                dataGridView.Columns.Add(ExcelBaseRepresentor.ConvertToPseudo26Base(columnIndex + 1),
                    ExcelBaseRepresentor.ConvertToPseudo26Base(columnIndex + 1));
            }
        }
        private void InitializeRows()
        {
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
        public void AddRow()
        {
            var cellsRow = new List<RealCell>();
            for (int columnIndex = 0; columnIndex != columnsAmount; ++columnIndex)
            {
                cellsRow.Add(new RealCell(rowsAmount, columnIndex));
            }
            cells.Add(cellsRow);
            dataGridView.Rows.Add(1);
            dataGridView.Rows[dataGridView.Rows.Count - 1].HeaderCell.Value =
                (dataGridView.Rows.Count).ToString();
            ++rowsAmount;
        }
        public void AddColumn()
        {
            dataGridView.Columns.Add(ExcelBaseRepresentor.ConvertToPseudo26Base(columnsAmount + 1),
                    ExcelBaseRepresentor.ConvertToPseudo26Base(columnsAmount + 1));

            for (int i = 0; i != rowsAmount; ++i)
            {
                cells[i].Add(new RealCell(i, columnsAmount));
            }
            ++columnsAmount;
        }
        public void DeleteRow()
        {
            if (rowsAmount == 1) return;
            dataGridView.Rows.RemoveAt(rowsAmount - 1);
            foreach(var cell in cells[rowsAmount - 1])
            {
                UpdateDependentOnMeCells(cell.rowIndex, cell.columnIndex);
            }
            cells.RemoveAt(rowsAmount - 1);
            --rowsAmount;
        }
        public void DeleteColumn()
        {
            if (columnsAmount == 1) return;

            dataGridView.Columns.RemoveAt(columnsAmount - 1);
            for (int i = 0; i != rowsAmount; ++i)
            {
                UpdateDependentOnMeCells(i, columnsAmount - 1);
                cells[i].RemoveAt(columnsAmount - 1);
            }
            --columnsAmount;
        }
        public void UpdateDependentOnMeCells(int rowIndex, int columnIndex)
        {
            var cell = cells[rowIndex][columnIndex];
            if (cell.CheckForDependenciesCycle(ref cell))
            {
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
        public void UpdateCell(int rowIndex, int columnIndex)
        {
            var cell = cells[rowIndex][columnIndex];
            if (cell.Expression == null) return;
            cell.Evaluation = cell.Expression;
            try
            {
                var expressionWithoutReferences = ReplaceCellsReferences(ref cell);
                if (cell.CheckForDependenciesCycle(ref cell))
                {
                    throw new Exception("Dependencies cycle");
                }
                cell.Evaluation = RealEvaluator.EvaluateExpression(expressionWithoutReferences).ToString();
            }
            catch
            {
                return;
            }
        }
        private string ReplaceCellsReferences(ref RealCell cell)
        {
            cell.cellsIDependOn = new HashSet<RealCell>();
            DeleteExpiredDependencies(ref cell);
            string pattern = @"[A-Z]+[0-9]+";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            foreach(Match match in regex.Matches(cell.Expression))
            {
                string cellAddress = match.Value;
                var rowIndex = Int32.Parse(Regex.Replace(cellAddress, @"\D", string.Empty)) - 1;
                var columnIndexInPseudo26Base = Regex.Replace(cellAddress, @"[\d-]", string.Empty);
                var columnIndex = ExcelBaseRepresentor.ConvertFromPseudo26Base(columnIndexInPseudo26Base) - 1;
                try
                {
                    if(rowIndex == cell.RowIndex && columnIndex == cell.ColumnIndex)
                    {
                        continue; // important moment
                    }
                    cell.cellsIDependOn.Add(cells[rowIndex][columnIndex]);
                    cells[rowIndex][columnIndex].dependentOnMeCells.Add(cell);
                }
                catch
                {
                    throw new Exception("Non-existing cell reference");
                }
            }
            MatchEvaluator matchEvaluator = new MatchEvaluator(BindValueToAddress);
            return regex.Replace(cell.Expression, matchEvaluator);
        }
        private string BindValueToAddress(Match match)
        {
            string cellAddress = match.Value;
            var rowIndex = Int32.Parse(Regex.Replace(cellAddress, @"\D", string.Empty)) - 1 ;
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
        private void DeleteExpiredDependencies(ref RealCell currentCell)
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
    }
}
