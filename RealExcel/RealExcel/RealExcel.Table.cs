using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealExcel
{
    partial class RealExcel
    {
        public List<List<Cell>> cells = new List<List<Cell>>();
        private int columnsAmount = 7;
        private int rowsAmount = 10;
        public void InitializeTable()
        {
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
                var cellsRow = new List<Cell>();
                for (int columnIndex = 0; columnIndex != columnsAmount; ++columnIndex)
                {
                    cellsRow.Add(new Cell(rowIndex, columnIndex));
                }
                cells.Add(cellsRow);
            }
        }
        private void UpdateCell(Cell cell)
        {
            if (cell.Expression == null) return;
            var expressionValid = Parser.ValidateExpression(cell.Expression);
            if (expressionValid)
            {
                Parser.EvaluateExpression(cell.Expression);
            }
            expressionTextBox.Text = cell.Expression;
        }
    }
}
