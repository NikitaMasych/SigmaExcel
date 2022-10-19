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
            table = new RealTable(ref dataGridView);
            ConfigureOpenFileDialog();
            ConfigureSaveFileDialog();
        }
        private void HandleReset()
        {
            if (table.State == TableState.Saved)
            {
                table.Reset();
                return;
            }
            if (table.State == TableState.New)
            {
                return;
            }
            const string message = "Table has been changed, do you want to make the save first?";
            const string caption = "Reset";
            switch (MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Yes:
                    HandleTableSaving(false);
                    table.Reset();
                    break;
                case DialogResult.No:
                    table.Reset();
                    break;
            }
        }
        private void HandleExit()
        {
            if (table.State == TableState.Saved || table.State == TableState.New)
            {
                System.Environment.Exit(0);
            }

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
        private void HandleTableOpening()
        {
            if (table.State == TableState.Modified)
            {   const string msg = "Do you want to save changes?";
                const string caption = "Save before Open";
                switch (MessageBox.Show(msg, caption, MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        HandleTableSaving(false);
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }

            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                var selectedFileName = openFileDialog.FileName;
                table.OpenFromCSV(selectedFileName);
            }
        }
        private void HandleTableSaving(bool emergency)
        {
            if (emergency)
            {
                var storagePath = (table.StoragePath == string.Empty) ? 
                    table.StoragePath : emergencySaveFilePath;
                table.SaveToCSV(storagePath);
                return;
            }
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                var selectedFileName = saveFileDialog.FileName;
                table.SaveToCSV(selectedFileName);
            }
        }
        private void HandleRowDeletion()
        {
            if (!table.IsRowEmpty(table.Cells.Count - 1))
            {
                const string msg = "Do you want to delete non-empty row?";
                const string caption = "Delete row";
                if (MessageBox.Show(msg, caption, MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
            }
            table.DeleteRow();
        }
        private void HandleColumnDeletion()
        {
            if (!table.IsColumnEmpty(table.Cells[0].Count - 1))
            {
                const string msg = "Do you want to delete non-empty column?";
                const string caption = "Delete column";
                if (MessageBox.Show(msg, caption, MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
            }
            table.DeleteColumn();
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
    }
}
