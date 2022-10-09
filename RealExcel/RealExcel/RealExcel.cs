using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealExcel
{
    public partial class RealExcel : Form
    {
        public RealExcel()
        {
            InitializeComponent();
            InitializeTable();
        }

        private void RealExcel_Load(object sender, EventArgs e)
        {

        }

        private void AddRow_Click(object sender, EventArgs e)
        {
            var cellsRow = new List<Cell>();
            for (int columnIndex = 0; columnIndex != columnsAmount; ++columnIndex)
            {
                cellsRow.Add(new Cell(rowsAmount, columnIndex));
            }
            cells.Add(cellsRow);
            dataGridView.Rows.Add(1);
            dataGridView.Rows[dataGridView.Rows.Count - 1].HeaderCell.Value = 
                (dataGridView.Rows.Count).ToString();
            ++rowsAmount;
        }
        private void AddColumn_Click(object senser, EventArgs e)
        {
            dataGridView.Columns.Add(ExcelBaseRepresentor.ConvertToPseudo26Base(columnsAmount + 1),
                    ExcelBaseRepresentor.ConvertToPseudo26Base(columnsAmount + 1));
            
            for (int i = 0; i != rowsAmount; ++i)
            {
                cells[i].Add(new Cell(i, columnsAmount));
            }
            ++columnsAmount;
        }
        private void DeleteRow_Click(object sender, EventArgs e)
        {
            if (rowsAmount == 0) return;
            dataGridView.Rows.RemoveAt(rowsAmount - 1);
            cells.RemoveAt(rowsAmount - 1);
            --rowsAmount;
            /*
             * TODO: Add cells' contents update.
             */
        }
        private void DeleteColumn_Click(object sender, EventArgs e)
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
        private void DataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (dataGridView.CurrentCell.Value == null) return;
                var rowIndex = dataGridView.CurrentCell.RowIndex;
                var columnIndex = dataGridView.CurrentCell.ColumnIndex;
                cells[rowIndex][columnIndex].Expression = dataGridView.CurrentCell.Value.ToString();
                UpdateCell(cells[rowIndex][columnIndex]);
                expressionTextBox.Text = dataGridView.CurrentCell.Value.ToString();
            }
        }
    }
}
