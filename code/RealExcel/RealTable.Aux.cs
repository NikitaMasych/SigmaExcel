using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RealExcel
{
    public partial class RealTable
    {
        private static int defaultColumnsAmount = 
            int.Parse(Environment.GetEnvironmentVariable("DEFAULT_COLUMNS_AMOUNT"));
        private static int defaultRowsAmount =
            int.Parse(Environment.GetEnvironmentVariable("DEFAULT_ROWS_AMOUNT"));
        private DataGridView dataGridView;
        private int columnsAmount = defaultColumnsAmount;
        private int rowsAmount = defaultRowsAmount;

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
            Cells = new List<List<RealCell>>();
            for (int rowIndex = 0; rowIndex != rowsAmount; ++rowIndex)
            {
                var CellsRow = new List<RealCell>();
                for (int columnIndex = 0; columnIndex != columnsAmount; ++columnIndex)
                {
                    CellsRow.Add(new RealCell(rowIndex, columnIndex));
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
            var linkedCells = new HashSet<RealCell>() { Cells[rowIndex][columnIndex] };
            var visited = new Dictionary<RealCell, bool>();
            linkedCells = GatherCellsInDependencyCycle(linkedCells, visited);
            foreach (var cell in linkedCells)
            {
                cell.Evaluation = cell.Expression;
                
                cell.HasDependencyCycle = true;
                dataGridView.Rows[cell.Row].Cells[cell.Column].Value = cell.Evaluation;
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
        private HashSet<RealCell> GetCellsHashSet(string expression)
        {
            HashSet<RealCell> CellsInExpression = new HashSet<RealCell>();
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
                    CellsInExpression.Add(Cells[rowIndex][columnIndex]);
                }
                catch
                {
                    throw new Exception("Non-existing cell reference");
                }
            }
            return CellsInExpression;
        }
        private void UpdateDependenciesOnMe(ref RealCell currentCell)
        {
            DeleteExpiredDependenciesOnMe(ref currentCell);
            SetDependenciesOnMe(ref currentCell);
        }
        private void DeleteExpiredDependenciesOnMe(ref RealCell currentCell)
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
        private void SetDependenciesOnMe(ref RealCell currentCell)
        {
            foreach (var cell in currentCell.CellsIDependOn)
            {
                cell.DependentOnMeCells.Add(currentCell);
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
