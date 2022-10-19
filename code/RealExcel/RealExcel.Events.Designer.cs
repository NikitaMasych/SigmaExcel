using System;

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
            this.expressionTextBox = new System.Windows.Forms.TextBox();
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warningsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip.SuspendLayout();
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
            this.dataGridView.Location = new System.Drawing.Point(0, 96);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(961, 525);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UpdateTextBox_CellClick);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.UpdateCell_CellEndEdit);
            // 
            // expressionTextBox
            // 
            this.expressionTextBox.BackColor = System.Drawing.Color.Black;
            this.expressionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expressionTextBox.Font = new System.Drawing.Font("Quicksand", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expressionTextBox.ForeColor = System.Drawing.Color.White;
            this.expressionTextBox.Location = new System.Drawing.Point(0, 51);
            this.expressionTextBox.Name = "expressionTextBox";
            this.expressionTextBox.Size = new System.Drawing.Size(825, 36);
            this.expressionTextBox.TabIndex = 5;
            this.expressionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // evaluateButton
            // 
            this.evaluateButton.AutoSize = true;
            this.evaluateButton.BackColor = System.Drawing.Color.Black;
            this.evaluateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.evaluateButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.evaluateButton.FlatAppearance.BorderSize = 3;
            this.evaluateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.evaluateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.evaluateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.evaluateButton.Font = new System.Drawing.Font("Quicksand", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evaluateButton.ForeColor = System.Drawing.Color.White;
            this.evaluateButton.Location = new System.Drawing.Point(846, 49);
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
            this.menuStrip.Size = new System.Drawing.Size(961, 40);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 36);
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
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
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
            this.addRowToolStripMenuItem.Size = new System.Drawing.Size(84, 36);
            this.addRowToolStripMenuItem.Text = "Add Row";
            this.addRowToolStripMenuItem.Click += new System.EventHandler(this.AddRow_Click);
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(99, 36);
            this.deleteRowToolStripMenuItem.Text = "Delete Row";
            this.deleteRowToolStripMenuItem.Click += new System.EventHandler(this.DeleteRow_Click);
            // 
            // addColumnToolStripMenuItem
            // 
            this.addColumnToolStripMenuItem.Name = "addColumnToolStripMenuItem";
            this.addColumnToolStripMenuItem.Size = new System.Drawing.Size(108, 36);
            this.addColumnToolStripMenuItem.Text = "Add Column";
            this.addColumnToolStripMenuItem.Click += new System.EventHandler(this.AddColumn_Click);
            // 
            // deleteColumnToolStripMenuItem
            // 
            this.deleteColumnToolStripMenuItem.Name = "deleteColumnToolStripMenuItem";
            this.deleteColumnToolStripMenuItem.Size = new System.Drawing.Size(123, 36);
            this.deleteColumnToolStripMenuItem.Text = "Delete Column";
            this.deleteColumnToolStripMenuItem.Click += new System.EventHandler(this.DeleteColumn_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(60, 36);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.Reset_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.warningsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 36);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // warningsToolStripMenuItem
            // 
            this.warningsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disableAllToolStripMenuItem});
            this.warningsToolStripMenuItem.Name = "warningsToolStripMenuItem";
            this.warningsToolStripMenuItem.Size = new System.Drawing.Size(216, 28);
            this.warningsToolStripMenuItem.Text = "Warnings";
            // 
            // disableAllToolStripMenuItem
            // 
            this.disableAllToolStripMenuItem.Name = "disableAllToolStripMenuItem";
            this.disableAllToolStripMenuItem.Size = new System.Drawing.Size(216, 28);
            this.disableAllToolStripMenuItem.Text = "Disable All";
            // 
            // RealExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(961, 614);
            this.Controls.Add(this.evaluateButton);
            this.Controls.Add(this.expressionTextBox);
            this.Controls.Add(this.dataGridView);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox expressionTextBox;
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
        private System.Windows.Forms.ToolStripMenuItem disableAllToolStripMenuItem;
    }
}

