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
            if (rowsAmount == 0) return;
            dataGridView.Rows.RemoveAt(rowsAmount - 1);
            cells.RemoveAt(rowsAmount - 1);
            --rowsAmount;
            /*
             * TODO: Add cells' contents update.
             */
        }
        public void DeleteColumn()
        {
            if (columnsAmount == 1) return;

            dataGridView.Columns.RemoveAt(columnsAmount - 1);
            for (int i = 0; i != rowsAmount; ++i)
            {
                cells[i].RemoveAt(columnsAmount - 1);
            }
            --columnsAmount;
            /*
             * TODO: Add cells' contents update.
             */
        }
        public void UpdateCell(int rowIndex, int columnIndex)
        {
            var cell = cells[rowIndex][columnIndex];
            if (cell.Expression == null) return;
            cell.Evaluation = cell.Expression;
            try
            {
                ReplaceCellsReferences(ref cell);
            }
            catch
            {
                return;
            }
            if (cell.CheckForDependenciesCycle()) return;
            try
            { 
                cell.Evaluation = RealEvaluator.EvaluateExpression(cell.Expression).ToString();
            }
            catch
            {
                return;
            }
        }
        private void ReplaceCellsReferences(ref RealCell cell)
        {
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
                    cell.ConjugatedCells.Add(cells[rowIndex][columnIndex]);
                }
                catch
                {
                    throw new Exception("Non-existing cell reference");
                }
            }
            MatchEvaluator matchEvaluator = new MatchEvaluator(BindValueToAddress);
            regex.Replace(cell.Expression, matchEvaluator);
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
    }
}
