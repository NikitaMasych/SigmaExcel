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
        private void Reset_Click(object sender, EventArgs e)
        {
            table.Reset();
        }
        private void Evaluate_Click(object sender, EventArgs e)
        {
            HandleCellUpdate(dataGridView.CurrentCell.RowIndex,
                dataGridView.CurrentCell.ColumnIndex, expressionTextBox.Text);
        }
        private void UpdateCell_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            expressionTextBox.Text = 
                $"{dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value}";

            HandleCellUpdate(e.RowIndex, e.ColumnIndex, expressionTextBox.Text);
        }
        private void UpdateTextBox_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            expressionTextBox.Text =
                table.Cells[e.RowIndex][e.ColumnIndex].Expression;
        }
        private void Save_Click(object sender, EventArgs e)
        {
            if (table.HasBeenSaved)
            {
                table.SaveToCSV(table.StoragePath);
            }
            else
            {
                HandleTableSaving(false);
            }
        }
        private void SaveAs_Click(object sender, EventArgs e)
        {
            HandleTableSaving(false);
        }
        private void Open_Click(object sender, EventArgs e)
        {
            HandleTableOpening();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            HandleExit();
        }
        private void FormExit_Click(object sender, FormClosingEventArgs e)
        {
            const bool customHandling = true;
            e.Cancel = customHandling; 
            if (e.CloseReason == CloseReason.UserClosing)
            {
               HandleExit();
            }
            else if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                HandleTableSaving(true);
                HandleExit();
            }
        }
    }
}
