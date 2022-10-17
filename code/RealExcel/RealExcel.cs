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
        private RealTable table;
        public RealExcel()
        {
            InitializeComponent();
            this.table = new RealTable(ref dataGridView);
        }
        private void RealExcel_Load(object sender, EventArgs e)
        {

        }
        private void AddRow_Click(object sender, EventArgs e)
        {
            table.AddRow();
        }
        private void AddColumn_Click(object senser, EventArgs e)
        {
            table.AddColumn();
        }
        private void DeleteRow_Click(object sender, EventArgs e)
        {
            table.DeleteRow();
        }
        private void DeleteColumn_Click(object sender, EventArgs e)
        {
            table.DeleteColumn();
        }
        private void Evaluate_Click(object sender, EventArgs e)
        {
            HandleCellUpdate(dataGridView.CurrentCell.RowIndex,
                dataGridView.CurrentCell.ColumnIndex, expressionTextBox.Text);
        }
        private void UpdateCell_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            expressionTextBox.Text = 
                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            HandleCellUpdate(e.RowIndex, e.ColumnIndex, expressionTextBox.Text);
        }
        private void UpdateTextBox_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            expressionTextBox.Text =
                table.cells[e.RowIndex][e.ColumnIndex].Expression;
        }
        private void HandleCellUpdate(int rowIndex, int columnIndex, string newExpression)
        {
            var currentCell = table.cells[rowIndex][columnIndex];
            if (newExpression != currentCell.Expression)
            {
                currentCell.Expression = newExpression;
                table.UpdateCell(rowIndex, columnIndex);
                table.UpdateDependentOnMeCells(rowIndex, columnIndex);
            }
            dataGridView.Rows[rowIndex].Cells[columnIndex].Value = currentCell.Evaluation;
        }
    }
}
