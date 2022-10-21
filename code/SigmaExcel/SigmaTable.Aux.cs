using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SigmaExcel
{
    public partial class SigmaTable
    {
        private static int defaultColumnsAmount = 
            int.Parse(Environment.GetEnvironmentVariable("DEFAULT_COLUMNS_AMOUNT"));
        private static int defaultRowsAmount =
            int.Parse(Environment.GetEnvironmentVariable("DEFAULT_ROWS_AMOUNT"));
        private int columnsAmount = defaultColumnsAmount;
        private int rowsAmount = defaultRowsAmount;
        private DataGridView dataGridView;

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
            Cells = new List<List<SigmaCell>>();
            for (int rowIndex = 0; rowIndex != rowsAmount; ++rowIndex)
            {
                var CellsRow = new List<SigmaCell>();
                for (int columnIndex = 0; columnIndex != columnsAmount; ++columnIndex)
                {
                    CellsRow.Add(new SigmaCell(rowIndex, columnIndex));
                }
                Cells.Add(CellsRow);
            }
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
                        = Cells[rowIndex][columnIndex].Evaluation;
                }
            }
        }
        private void UpdateCellsInDependencyCycle(int rowIndex, int columnIndex)
        {
            var linkedCells = new HashSet<SigmaCell>() { Cells[rowIndex][columnIndex] };
            var visited = new Dictionary<SigmaCell, bool>();
            linkedCells = GatherCellsInDependencyCycle(linkedCells, visited);
            foreach (var cell in linkedCells)
            {
                cell.Evaluation = cell.Expression;
                
                cell.HasDependencyCycle = true;
                dataGridView.Rows[cell.Row].Cells[cell.Column].Value = cell.Evaluation;
            }
        }
        private void FullCellUpdate(SigmaCell cell)
        {
            try
            {
                cell.CellsIDependOn = GetCellsHashSet(cell.Expression);
                UpdateDependenciesOnMe(cell);
                ValidateDependencyCycleState(cell);
                UpdateCellEvaluation(cell, ReplaceCellsReferences(cell.Expression));
            }
            catch
            {
                cell.Evaluation = cell.Expression;
            }
        }
        private void ValidateDependencyCycleState(SigmaCell cell)
        {
            if (cell.CheckForDependenciesCycle(cell))
            {
                cell.HasDependencyCycle = true;
                throw new Exception("Dependency cycle");
            }
            cell.HasDependencyCycle = false;
        }
        private void UpdateCellEvaluation(SigmaCell cell, string newExpression)
        {
            if (cell.Expression == null || cell.Expression == "")
            {
                return;
            }
            cell.Evaluation = SigmaEvaluator.EvaluateExpression(newExpression).ToString();
        }
        private HashSet<SigmaCell> GatherCellsInDependencyCycle(HashSet<SigmaCell> current, 
            Dictionary<SigmaCell, bool> visited)
        {
            foreach (var cell in current.ToList())
            {   if (visited.ContainsKey(cell))
                {
                    if (!visited[cell])
                    {
                        visited[cell] = true;
                        current.UnionWith(GatherCellsInDependencyCycle(cell.DependentOnMeCells, visited));
                    }
                }
                else
                {
                    visited.Add(cell, true);
                    current.UnionWith(GatherCellsInDependencyCycle(cell.DependentOnMeCells, visited));
                }
            }
            return current;
        }
        private HashSet<SigmaCell> GetCellsHashSet(string expression)
        {
            HashSet<SigmaCell> CellsInExpression = new HashSet<SigmaCell>();
            const string pattern = @"[A-Z]+[0-9]+";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            foreach(Match match in regex.Matches(expression))
            {
                string cellAddress = match.Value;
                var rowIndex = Int32.Parse(Regex.Replace(cellAddress, @"\D", string.Empty)) - 1;
                var columnIndexInPseudo26Base = Regex.Replace(cellAddress, @"[\d-]", string.Empty);
                var columnIndex = ExcelBaseRepresentor.ConvertFromPseudo26Base(columnIndexInPseudo26Base) - 1;
                if (rowIndex < rowsAmount && columnIndex < columnsAmount)
                {
                    CellsInExpression.Add(Cells[rowIndex][columnIndex]);
                }
                else
                {
                    CellsInExpression.Add(new SigmaCell(rowIndex, columnIndex));
                }
            }
            return CellsInExpression;
        }
        private void UpdateDependenciesOnMe(SigmaCell currentCell)
        {
            DeleteExpiredDependenciesOnMe(currentCell);
            SetDependenciesOnMe(currentCell);
        }
        private void DeleteExpiredDependenciesOnMe(SigmaCell currentCell)
        {
            foreach(var cellRow in Cells)
            {
                foreach(var cell in cellRow)
                {
                    if (cell.DependentOnMeCells.Contains(currentCell))
                    {
                        cell.DependentOnMeCells.Remove(currentCell);
                    }
                }
            }
        }
        private void SetDependenciesOnMe(SigmaCell currentCell)
        {
            foreach (var cell in currentCell.CellsIDependOn)
            {
                cell.DependentOnMeCells.Add(currentCell);
            }
        }
        private void SetCellsIDependOn(SigmaCell currentCell)
        {
            foreach (var cellRow in Cells)
            {
                foreach (var cell in cellRow)
                {
                    if (cell.DoIDependOn(currentCell))
                    {
                        currentCell.DependentOnMeCells.Add(cell);
                    }
                }
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
                var cellValue = Cells[rowIndex][columnIndex].Evaluation.ToString();
                return cellValue;
            }
            catch
            {
                throw new Exception("Null value reference");
            }
        }
    }
}
