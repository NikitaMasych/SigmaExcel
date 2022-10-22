using System.Collections.Generic;
using System.Windows.Forms;

namespace SigmaExcel
{
    partial class SigmaExcel
    {
        private SigmaTable table;
        private static bool exitNow = false;
        public SigmaExcel()
        {
            InitializeComponent();
            SetDoubleBuffering(true);
            table = new SigmaTable(ref dataGridView);
            ConfigureOpenFileDialog();
            ConfigureSaveFileDialog();
            SetAllWarningsCheckBoxesAccordingToConfig();
        }
        private void HandleReset()
        {
            if (table.State == TableState.Saved ||
                !Config.Warnings[NonSavedContentWarnings.Reset])
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
            if (table.State == TableState.Saved || table.State == TableState.New ||
                !Config.Warnings[NonSavedContentWarnings.Exit])
            {
                updateStatusWorker.CancelAsync();
                exitNow = true;
                Application.Exit();
                return;
            }
            const string message = "Do you want to save the table before exit?";
            const string caption = "Exit";
            switch (MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Yes:
                    {
                        updateStatusWorker.CancelAsync();
                        HandleTableSaving(false);
                        exitNow = true;
                        Application.Exit();
                        break;
                    }
                case DialogResult.No:
                    {
                        updateStatusWorker.CancelAsync();
                        exitNow = true;
                        Application.Exit();
                        break;
                    }
            }
        }
        private void HandleTableOpening()
        {
            if (table.State == TableState.Modified && 
                Config.Warnings[NonSavedContentWarnings.Opening])
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
                var storagePath = string.IsNullOrEmpty(table.StoragePath) ? 
                    table.StoragePath : Config.EmergencySaveFilePath;
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
            if (!table.IsRowEmpty(table.Cells.Count - 1) && 
                Config.Warnings[NonSavedContentWarnings.DeletionOfRow])
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
            if (!table.IsColumnEmpty(table.Cells[0].Count - 1) &&
                 Config.Warnings[NonSavedContentWarnings.DeletionOfColumn])
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
        private void SetAllWarningsCheckBoxesAccordingToConfig()
        {
            deletionOfColumnWarningCheckBox.Checked =
                Config.Warnings[NonSavedContentWarnings.DeletionOfColumn];
            deletionOfRowWarningCheckBox.Checked =
                Config.Warnings[NonSavedContentWarnings.DeletionOfRow];
            resetWarningCheckBox.Checked =
                Config.Warnings[NonSavedContentWarnings.Reset];
            openWarningCheckBox.Checked =
               Config.Warnings[NonSavedContentWarnings.Opening];
            exitWarningCheckBox.Checked =
                Config.Warnings[NonSavedContentWarnings.Exit]; 
        }
        private void KeepTableStatusPosted()
        {
            Dictionary<TableState, string> State =
             new Dictionary<TableState, string>
             {
                 [TableState.Modified] = "Modified",
                 [TableState.New] = "New",
                 [TableState.Saved] = "Saved",
             };
            string previousStatus = table.GetSavedFileName() + " - " + State[table.State];
            string currentStatus;
            const int newStatusPercentage = 100;
            while (true)
            {
                currentStatus = table.GetSavedFileName() + " - " + State[table.State];

                if (previousStatus != currentStatus)
                {
                    updateStatusWorker.ReportProgress(newStatusPercentage, currentStatus);
                    previousStatus = currentStatus;
                }
            }
        }
    }
}
