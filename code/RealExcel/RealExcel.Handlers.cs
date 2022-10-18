using System;
using System.Windows.Forms;

namespace RealExcel
{
    partial class RealExcel
    {
        private RealTable table;
        private static string emergencySaveFilePath =
            Environment.GetEnvironmentVariable("EMERGENCY_SAVE_FILEPATH");
        public RealExcel()
        {
            InitializeComponent();
            this.table = new RealTable(ref dataGridView);
        }
        private void HandleCellUpdate(int rowIndex, int columnIndex, string newExpression)
        {
            var currentCell = table.Cells[rowIndex][columnIndex];
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
                var storagePath = (table.HasBeenSaved) ? table.StoragePath : emergencySaveFilePath;
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
                        System.Environment.Exit(0);
                        break;
                    }
            }
        }
    }
}
