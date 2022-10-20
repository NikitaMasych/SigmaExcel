using System;
using System.Reflection;
using System.Windows.Forms;

namespace RealExcel
{
    partial class RealExcel
    {
        
        private System.ComponentModel.IContainer components = null;

        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void SetDoubleBuffering(bool enableDoubleBuffering)
        {
            if (!SystemInformation.TerminalServerSession)
            {
                Type dgvType = dataGridView.GetType();
                PropertyInfo pI = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
                pI.SetValue(dataGridView, enableDoubleBuffering, null);
            }
        }
        private void ConfigureOpenFileDialog()
        {
            openFileDialog.Title = "Open the Table";
            openFileDialog.InitialDirectory =
                System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.FileName = "";
            openFileDialog.CheckFileExists = true;
            openFileDialog.Filter = "CSV TABLE|*.csv";
            openFileDialog.RestoreDirectory = true;
        }
        private void ConfigureSaveFileDialog()
        {
            saveFileDialog.Title = "Save the Table";
            saveFileDialog.InitialDirectory =
                System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.FileName = "";
            saveFileDialog.Filter = "CSV TABLE|*.csv";
            saveFileDialog.RestoreDirectory = true;
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealExcel));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.evaluateButton = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToDocumentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warningsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.expressionTextBox = new System.Windows.Forms.TextBox();
            this.warningsSettingsPanel = new System.Windows.Forms.Panel();
            this.exitWarningsSettingButton = new System.Windows.Forms.Button();
            this.disableAllWarningsButton = new System.Windows.Forms.Button();
            this.enableAllWarningsButton = new System.Windows.Forms.Button();
            this.openWarningCheckBox = new System.Windows.Forms.CheckBox();
            this.exitWarningCheckBox = new System.Windows.Forms.CheckBox();
            this.resetWarningCheckBox = new System.Windows.Forms.CheckBox();
            this.deletionOfColumnWarningCheckBox = new System.Windows.Forms.CheckBox();
            this.deletionOfRowWarningCheckBox = new System.Windows.Forms.CheckBox();
            this.warningsSettingsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.warningsSettingsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 113);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(961, 501);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UpdateTextBox_CellClick);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.UpdateCell_CellEndEdit);
            // 
            // evaluateButton
            // 
            this.evaluateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.evaluateButton.AutoSize = true;
            this.evaluateButton.BackColor = System.Drawing.Color.Black;
            this.evaluateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.evaluateButton.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.evaluateButton.FlatAppearance.BorderSize = 3;
            this.evaluateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.evaluateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.evaluateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.evaluateButton.Font = new System.Drawing.Font("Quicksand", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evaluateButton.ForeColor = System.Drawing.Color.White;
            this.evaluateButton.Location = new System.Drawing.Point(844, 13);
            this.evaluateButton.Name = "evaluateButton";
            this.evaluateButton.Size = new System.Drawing.Size(105, 41);
            this.evaluateButton.TabIndex = 9;
            this.evaluateButton.Text = "Evaluate";
            this.evaluateButton.UseVisualStyleBackColor = false;
            this.evaluateButton.Click += new System.EventHandler(this.Evaluate_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.AutoSize = false;
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.menuStrip.Font = new System.Drawing.Font("Quicksand", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.addRowToolStripMenuItem,
            this.deleteRowToolStripMenuItem,
            this.addColumnToolStripMenuItem,
            this.deleteColumnToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(961, 48);
            this.menuStrip.TabIndex = 10;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 44);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::RealExcel.Properties.Resources.Save_1;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(227, 28);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.Save_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::RealExcel.Properties.Resources.SaveAs_1;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(227, 28);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::RealExcel.Properties.Resources.Open_1;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(227, 28);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.Open_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::RealExcel.Properties.Resources.Exit_1;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(227, 28);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToDocumentationToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 44);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // goToDocumentationToolStripMenuItem
            // 
            this.goToDocumentationToolStripMenuItem.Image = global::RealExcel.Properties.Resources.Info_1;
            this.goToDocumentationToolStripMenuItem.Name = "goToDocumentationToolStripMenuItem";
            this.goToDocumentationToolStripMenuItem.Size = new System.Drawing.Size(233, 28);
            this.goToDocumentationToolStripMenuItem.Text = "Go to documentation";
            this.goToDocumentationToolStripMenuItem.Click += new System.EventHandler(this.GoToDocumentationWebsite_Click);
            // 
            // addRowToolStripMenuItem
            // 
            this.addRowToolStripMenuItem.Name = "addRowToolStripMenuItem";
            this.addRowToolStripMenuItem.Size = new System.Drawing.Size(84, 44);
            this.addRowToolStripMenuItem.Text = "Add Row";
            this.addRowToolStripMenuItem.Click += new System.EventHandler(this.AddRow_Click);
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(99, 44);
            this.deleteRowToolStripMenuItem.Text = "Delete Row";
            this.deleteRowToolStripMenuItem.Click += new System.EventHandler(this.DeleteRow_Click);
            // 
            // addColumnToolStripMenuItem
            // 
            this.addColumnToolStripMenuItem.Name = "addColumnToolStripMenuItem";
            this.addColumnToolStripMenuItem.Size = new System.Drawing.Size(108, 44);
            this.addColumnToolStripMenuItem.Text = "Add Column";
            this.addColumnToolStripMenuItem.Click += new System.EventHandler(this.AddColumn_Click);
            // 
            // deleteColumnToolStripMenuItem
            // 
            this.deleteColumnToolStripMenuItem.Name = "deleteColumnToolStripMenuItem";
            this.deleteColumnToolStripMenuItem.Size = new System.Drawing.Size(123, 44);
            this.deleteColumnToolStripMenuItem.Text = "Delete Column";
            this.deleteColumnToolStripMenuItem.Click += new System.EventHandler(this.DeleteColumn_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(60, 44);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.Reset_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.warningsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 44);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // warningsToolStripMenuItem
            // 
            this.warningsToolStripMenuItem.Image = global::RealExcel.Properties.Resources.Warning;
            this.warningsToolStripMenuItem.Name = "warningsToolStripMenuItem";
            this.warningsToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.warningsToolStripMenuItem.Text = "Warnings";
            this.warningsToolStripMenuItem.Click += new System.EventHandler(this.OpenWarningsSettings_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.expressionTextBox);
            this.panel1.Controls.Add(this.evaluateButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 65);
            this.panel1.TabIndex = 11;
            // 
            // expressionTextBox
            // 
            this.expressionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expressionTextBox.BackColor = System.Drawing.Color.Black;
            this.expressionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expressionTextBox.Font = new System.Drawing.Font("Quicksand", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expressionTextBox.ForeColor = System.Drawing.Color.White;
            this.expressionTextBox.Location = new System.Drawing.Point(3, 13);
            this.expressionTextBox.Name = "expressionTextBox";
            this.expressionTextBox.Size = new System.Drawing.Size(825, 36);
            this.expressionTextBox.TabIndex = 5;
            this.expressionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // warningsSettingsPanel
            // 
            this.warningsSettingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.warningsSettingsPanel.Controls.Add(this.exitWarningsSettingButton);
            this.warningsSettingsPanel.Controls.Add(this.disableAllWarningsButton);
            this.warningsSettingsPanel.Controls.Add(this.enableAllWarningsButton);
            this.warningsSettingsPanel.Controls.Add(this.openWarningCheckBox);
            this.warningsSettingsPanel.Controls.Add(this.exitWarningCheckBox);
            this.warningsSettingsPanel.Controls.Add(this.resetWarningCheckBox);
            this.warningsSettingsPanel.Controls.Add(this.deletionOfColumnWarningCheckBox);
            this.warningsSettingsPanel.Controls.Add(this.deletionOfRowWarningCheckBox);
            this.warningsSettingsPanel.Controls.Add(this.warningsSettingsLabel);
            this.warningsSettingsPanel.Location = new System.Drawing.Point(336, 135);
            this.warningsSettingsPanel.Name = "warningsSettingsPanel";
            this.warningsSettingsPanel.Size = new System.Drawing.Size(312, 369);
            this.warningsSettingsPanel.TabIndex = 12;
            this.warningsSettingsPanel.Visible = false;
            this.warningsSettingsPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveWarningsSettingPanel_MouseDown);
            this.warningsSettingsPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveWarningsSettingPanel_MouseMove);
            // 
            // exitWarningsSettingButton
            // 
            this.exitWarningsSettingButton.BackColor = System.Drawing.Color.Red;
            this.exitWarningsSettingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitWarningsSettingButton.Font = new System.Drawing.Font("Bell MT", 10F);
            this.exitWarningsSettingButton.Location = new System.Drawing.Point(274, 7);
            this.exitWarningsSettingButton.Name = "exitWarningsSettingButton";
            this.exitWarningsSettingButton.Size = new System.Drawing.Size(27, 28);
            this.exitWarningsSettingButton.TabIndex = 15;
            this.exitWarningsSettingButton.Text = "X";
            this.exitWarningsSettingButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.exitWarningsSettingButton.UseVisualStyleBackColor = false;
            this.exitWarningsSettingButton.Click += new System.EventHandler(this.CloseWarningsSettings_Click);
            // 
            // disableAllWarningsButton
            // 
            this.disableAllWarningsButton.BackColor = System.Drawing.Color.Black;
            this.disableAllWarningsButton.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.disableAllWarningsButton.FlatAppearance.BorderSize = 3;
            this.disableAllWarningsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.disableAllWarningsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.disableAllWarningsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disableAllWarningsButton.Font = new System.Drawing.Font("Quicksand", 10F);
            this.disableAllWarningsButton.ForeColor = System.Drawing.Color.White;
            this.disableAllWarningsButton.Location = new System.Drawing.Point(165, 59);
            this.disableAllWarningsButton.Name = "disableAllWarningsButton";
            this.disableAllWarningsButton.Size = new System.Drawing.Size(112, 39);
            this.disableAllWarningsButton.TabIndex = 14;
            this.disableAllWarningsButton.Text = "Disable all";
            this.disableAllWarningsButton.UseVisualStyleBackColor = false;
            this.disableAllWarningsButton.Click += new System.EventHandler(this.DisableAllWarnings_Click);
            // 
            // enableAllWarningsButton
            // 
            this.enableAllWarningsButton.BackColor = System.Drawing.Color.Black;
            this.enableAllWarningsButton.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.enableAllWarningsButton.FlatAppearance.BorderSize = 3;
            this.enableAllWarningsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.enableAllWarningsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.enableAllWarningsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enableAllWarningsButton.Font = new System.Drawing.Font("Quicksand", 10F);
            this.enableAllWarningsButton.ForeColor = System.Drawing.Color.White;
            this.enableAllWarningsButton.Location = new System.Drawing.Point(28, 59);
            this.enableAllWarningsButton.Name = "enableAllWarningsButton";
            this.enableAllWarningsButton.Size = new System.Drawing.Size(112, 39);
            this.enableAllWarningsButton.TabIndex = 13;
            this.enableAllWarningsButton.Text = "Enable all";
            this.enableAllWarningsButton.UseVisualStyleBackColor = false;
            this.enableAllWarningsButton.Click += new System.EventHandler(this.EnableAllWarnings_Click);
            // 
            // openWarningCheckBox
            // 
            this.openWarningCheckBox.AutoSize = true;
            this.openWarningCheckBox.Font = new System.Drawing.Font("Quicksand", 9F);
            this.openWarningCheckBox.Location = new System.Drawing.Point(9, 252);
            this.openWarningCheckBox.Name = "openWarningCheckBox";
            this.openWarningCheckBox.Size = new System.Drawing.Size(298, 27);
            this.openWarningCheckBox.TabIndex = 5;
            this.openWarningCheckBox.Text = "Open new table when current unsaved";
            this.openWarningCheckBox.UseVisualStyleBackColor = true;
            this.openWarningCheckBox.CheckedChanged += new System.EventHandler(this.SetOpenWarning_CheckedChanged);
            // 
            // exitWarningCheckBox
            // 
            this.exitWarningCheckBox.AutoSize = true;
            this.exitWarningCheckBox.Font = new System.Drawing.Font("Quicksand", 10F);
            this.exitWarningCheckBox.Location = new System.Drawing.Point(9, 299);
            this.exitWarningCheckBox.Name = "exitWarningCheckBox";
            this.exitWarningCheckBox.Size = new System.Drawing.Size(177, 29);
            this.exitWarningCheckBox.TabIndex = 4;
            this.exitWarningCheckBox.Text = "Exit unsaved table";
            this.exitWarningCheckBox.UseVisualStyleBackColor = true;
            this.exitWarningCheckBox.CheckedChanged += new System.EventHandler(this.SetExitWarning_CheckedChanged);
            // 
            // resetWarningCheckBox
            // 
            this.resetWarningCheckBox.AutoSize = true;
            this.resetWarningCheckBox.Font = new System.Drawing.Font("Quicksand", 10F);
            this.resetWarningCheckBox.Location = new System.Drawing.Point(9, 206);
            this.resetWarningCheckBox.Name = "resetWarningCheckBox";
            this.resetWarningCheckBox.Size = new System.Drawing.Size(192, 29);
            this.resetWarningCheckBox.TabIndex = 3;
            this.resetWarningCheckBox.Text = "Reset unsaved table";
            this.resetWarningCheckBox.UseVisualStyleBackColor = true;
            this.resetWarningCheckBox.CheckStateChanged += new System.EventHandler(this.SetResetWarning_CheckedChanged);
            // 
            // deletionOfColumnWarningCheckBox
            // 
            this.deletionOfColumnWarningCheckBox.AutoSize = true;
            this.deletionOfColumnWarningCheckBox.Font = new System.Drawing.Font("Quicksand", 9.5F);
            this.deletionOfColumnWarningCheckBox.Location = new System.Drawing.Point(9, 162);
            this.deletionOfColumnWarningCheckBox.Name = "deletionOfColumnWarningCheckBox";
            this.deletionOfColumnWarningCheckBox.Size = new System.Drawing.Size(295, 28);
            this.deletionOfColumnWarningCheckBox.TabIndex = 2;
            this.deletionOfColumnWarningCheckBox.Text = "Delete column with non-empty cells";
            this.deletionOfColumnWarningCheckBox.UseVisualStyleBackColor = true;
            this.deletionOfColumnWarningCheckBox.CheckedChanged += new System.EventHandler(this.SetDeletionOfColumnWarning_CheckedChanged);
            // 
            // deletionOfRowWarningCheckBox
            // 
            this.deletionOfRowWarningCheckBox.AutoSize = true;
            this.deletionOfRowWarningCheckBox.BackColor = System.Drawing.Color.White;
            this.deletionOfRowWarningCheckBox.FlatAppearance.BorderSize = 0;
            this.deletionOfRowWarningCheckBox.Font = new System.Drawing.Font("Quicksand", 10F);
            this.deletionOfRowWarningCheckBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.deletionOfRowWarningCheckBox.Location = new System.Drawing.Point(9, 118);
            this.deletionOfRowWarningCheckBox.Name = "deletionOfRowWarningCheckBox";
            this.deletionOfRowWarningCheckBox.Size = new System.Drawing.Size(288, 29);
            this.deletionOfRowWarningCheckBox.TabIndex = 1;
            this.deletionOfRowWarningCheckBox.Text = "Delete row with non-empty cells";
            this.deletionOfRowWarningCheckBox.UseVisualStyleBackColor = false;
            this.deletionOfRowWarningCheckBox.CheckedChanged += new System.EventHandler(this.SetDeletionOfRowWarning_CheckedChanged);
            // 
            // warningsSettingsLabel
            // 
            this.warningsSettingsLabel.AutoSize = true;
            this.warningsSettingsLabel.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningsSettingsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.warningsSettingsLabel.Location = new System.Drawing.Point(64, 13);
            this.warningsSettingsLabel.Name = "warningsSettingsLabel";
            this.warningsSettingsLabel.Size = new System.Drawing.Size(179, 30);
            this.warningsSettingsLabel.TabIndex = 0;
            this.warningsSettingsLabel.Text = "Warnings Settings";
            this.warningsSettingsLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveWarningsSettingPanel_MouseDown);
            this.warningsSettingsLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveWarningsSettingPanel_MouseMove);
            // 
            // RealExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(961, 614);
            this.Controls.Add(this.warningsSettingsPanel);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Quicksand", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "RealExcel";
            this.Text = "RealExcel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExit_Click);
            this.Load += new System.EventHandler(this.RealExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.warningsSettingsPanel.ResumeLayout(false);
            this.warningsSettingsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button evaluateButton;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToDocumentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warningsToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox expressionTextBox;
        private Panel warningsSettingsPanel;
        private Label warningsSettingsLabel;
        private CheckBox resetWarningCheckBox;
        private CheckBox deletionOfColumnWarningCheckBox;
        private CheckBox deletionOfRowWarningCheckBox;
        private CheckBox exitWarningCheckBox;
        private CheckBox openWarningCheckBox;
        private Button disableAllWarningsButton;
        private Button enableAllWarningsButton;
        private Button exitWarningsSettingButton;
    }
}

