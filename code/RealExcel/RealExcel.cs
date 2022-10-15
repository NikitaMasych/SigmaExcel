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
        private void UpdateCell_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            HandleCellUpdate(e.RowIndex, e.ColumnIndex);
        }
        private void HandleCellUpdate(int rowIndex, int columnIndex)
        {
            var currentCellValue = dataGridView.Rows[rowIndex].Cells[columnIndex].Value;
            if (currentCellValue == null) return;
      
            table.cells[rowIndex][columnIndex].Expression = currentCellValue.ToString();
            if ((string)currentCellValue != table.cells[rowIndex][columnIndex].Evaluation)
            {
                table.UpdateCell(rowIndex, columnIndex);
            }
            expressionTextBox.Text = dataGridView.CurrentCell.Value.ToString();
            dataGridView.CurrentCell.Value = table.cells[rowIndex][columnIndex].Evaluation;
        }
    }
}
