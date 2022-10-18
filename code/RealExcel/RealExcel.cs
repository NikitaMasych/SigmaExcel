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
        private const string defaultStoragePath = "RealExcelTableEmergencySave.csv";
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
                table.cells[e.RowIndex][e.ColumnIndex].Expression;
        }
        private void Save_Click(object sender, EventArgs e)
        {
            if (table.hasBeenSaved)
            {
                table.SaveToCSV(table.storagePath);
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
        private void HandleTableSaving(bool emergency)
        {
            if (emergency)
            {
                var storagePath = (table.hasBeenSaved) ? table.storagePath : defaultStoragePath;
                table.SaveToCSV(storagePath);
                return;
            }
            saveFileDialog.Title = "Save the Table";
            saveFileDialog.InitialDirectory =
                System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.FileName = "";
            saveFileDialog.Filter = "CSV TABLE|*.csv";
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                var selectedFileName = saveFileDialog.FileName;
                table.SaveToCSV(selectedFileName);
            }
        }
        private void HandleTableOpening()
        {
            openFileDialog.Title = "Open the Table";
            openFileDialog.InitialDirectory =
                System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.FileName = "";
            openFileDialog.CheckFileExists = true;
            openFileDialog.Filter = "CSV TABLE|*.csv";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                var selectedFileName = openFileDialog.FileName;
                table.OpenFromCSV(selectedFileName);
            }
        }
        private void HandleExit()
        {
            const string message = "Do you want to save the table before exit?";
            const string caption = "Exit";
            switch (MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Yes:
                {
                    HandleTableSaving(false);
                    System.Environment.Exit(1);
                    break;
                }
                case DialogResult.No:
                {
                    System.Environment.Exit(1);
                    break;
                }
            }
        }
    }
}
