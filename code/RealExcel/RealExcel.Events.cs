using System;
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
            HandleRowDeletion();
        }
        private void DeleteColumn_Click(object sender, EventArgs e)
        {
            HandleColumnDeletion();
        }
        private void Reset_Click(object sender, EventArgs e)
        {
            HandleReset();
        }
        private void Evaluate_Click(object sender, EventArgs e)
        {
            HandleCellUpdate(dataGridView.CurrentCell.RowIndex,
                dataGridView.CurrentCell.ColumnIndex, expressionTextBox.Text);
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleCellUpdate(dataGridView.CurrentCell.RowIndex,
                    dataGridView.CurrentCell.ColumnIndex, expressionTextBox.Text);
                expressionTextBox.Enabled = false;
                expressionTextBox.Enabled = true;
            }
        }
        private void UpdateCell_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            expressionTextBox.Text = 
                $"{dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value}";

            HandleCellUpdate(e.RowIndex, e.ColumnIndex, expressionTextBox.Text);
        }
        private void UpdateTextBox_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            expressionTextBox.Text =
                $"{table.Cells[e.RowIndex][e.ColumnIndex].Expression}"; 
        }
        private void Save_Click(object sender, EventArgs e)
        {
            if (table.StoragePath != string.Empty)
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
            e.Cancel = !exitNow;
            if (!e.Cancel)
            {
                return;
            }
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
        private void GoToDocumentationWebsite_Click(object sender, EventArgs e)
        {
            var documentationURL = Environment.GetEnvironmentVariable("DOCUMENTATION_URL");
            System.Diagnostics.Process.Start(documentationURL);
        }
    }
}
