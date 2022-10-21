using System;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using System.ComponentModel;

namespace SigmaExcel
{
    public partial class SigmaExcel : Form
    {
        private Point mouseDownWarningsSettingPanelLocation;

        private void SigmaExcel_Load(object sender, EventArgs e)
        {
            updateStatusWorker.WorkerReportsProgress = true;
            updateStatusWorker.WorkerSupportsCancellation = true;
            updateStatusWorker.RunWorkerAsync();
        }
        private void AddRow_Click(object sender, EventArgs e) =>
            table.AddRow();
        private void AddColumn_Click(object senser, EventArgs e) => 
            table.AddColumn();
        private void DeleteRow_Click(object sender, EventArgs e) => 
            HandleRowDeletion();
        private void DeleteColumn_Click(object sender, EventArgs e) => 
            HandleColumnDeletion();
        private void Reset_Click(object sender, EventArgs e) => 
            HandleReset();
        private void Evaluate_Click(object sender, EventArgs e) =>
            HandleCellUpdate(dataGridView.CurrentCell.RowIndex,
                dataGridView.CurrentCell.ColumnIndex, expressionTextBox.Text);
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
            if ($"{table.StoragePath}" != string.Empty)
            {
                table.SaveToCSV(table.StoragePath);
            }
            else
            {
                HandleTableSaving(false);
            }
        }
        private void SaveAs_Click(object sender, EventArgs e) =>
            HandleTableSaving(false);
        private void Open_Click(object sender, EventArgs e) =>
            HandleTableOpening();
        private void Exit_Click(object sender, EventArgs e) =>
            HandleExit();
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
        private void SetDeletionOfRowWarning_CheckedChanged(object sender, EventArgs e) =>
            Config.Warnings[NonSavedContentWarnings.DeletionOfRow] =
                deletionOfRowWarningCheckBox.Checked;
        private void SetDeletionOfColumnWarning_CheckedChanged(object sender, EventArgs e) =>
            Config.Warnings[NonSavedContentWarnings.DeletionOfColumn] =
                deletionOfColumnWarningCheckBox.Checked;
        private void SetResetWarning_CheckedChanged(object sender, EventArgs e) =>
            Config.Warnings[NonSavedContentWarnings.Reset] = 
                resetWarningCheckBox.Checked;
        private void SetOpenWarning_CheckedChanged(object sender, EventArgs e) =>
            Config.Warnings[NonSavedContentWarnings.Opening] =
                openWarningCheckBox.Checked;
        private void SetExitWarning_CheckedChanged(object sender, EventArgs e) =>
            Config.Warnings[NonSavedContentWarnings.Exit] =
               exitWarningCheckBox.Checked;
        private void EnableAllWarnings_Click(object sender, EventArgs e)
        {
            const bool enable = true;
            SetValueToAllWarningsCheckBoxes(enable);
            foreach (var warning in Config.Warnings.Keys.ToList())
            {
                Config.Warnings[warning] = enable;
            }
        }
        private void DisableAllWarnings_Click(object sender, EventArgs e)
        {
            const bool disable = false;
            SetValueToAllWarningsCheckBoxes(disable);
            foreach (var warning in Config.Warnings.Keys.ToList())
            {
                Config.Warnings[warning] = disable;
            }
        }
        private void CloseWarningsSettings_Click(object sender, EventArgs e) =>
            warningsSettingsPanel.Visible = false;
        private void OpenWarningsSettings_Click(object sender, EventArgs e) =>
            warningsSettingsPanel.Visible = true;
        private void MoveWarningsSettingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                
                mouseDownWarningsSettingPanelLocation = e.Location;
            }
        }
        private void MoveWarningsSettingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                warningsSettingsPanel.Left = e.X + warningsSettingsPanel.Left - 
                    mouseDownWarningsSettingPanelLocation.X;
                warningsSettingsPanel.Top = e.Y + warningsSettingsPanel.Top -
                    mouseDownWarningsSettingPanelLocation.Y;
            }
        }
        private void UpdateStatusWorker_DoWork(object sender, DoWorkEventArgs e) =>
            KeepTableStatusPosted();
        private void NotifyStatusLabelChange_ProgressChanged(object sender, ProgressChangedEventArgs e) =>
            statusLabel.Text = e.UserState.ToString();
    }
}
