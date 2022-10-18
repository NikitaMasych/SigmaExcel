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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealExcel));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.addRowButton = new System.Windows.Forms.Button();
            this.expressionTextBox = new System.Windows.Forms.TextBox();
            this.deleteRowButton = new System.Windows.Forms.Button();
            this.addColumnButton = new System.Windows.Forms.Button();
            this.deleteColumnButton = new System.Windows.Forms.Button();
            this.evaluateButton = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToDocumentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.resetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 78);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(1007, 601);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UpdateTextBox_CellClick);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.UpdateCell_CellEndEdit);
            // 
            // addRowButton
            // 
            this.addRowButton.AutoSize = true;
            this.addRowButton.BackColor = System.Drawing.SystemColors.Control;
            this.addRowButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addRowButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.addRowButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addRowButton.Location = new System.Drawing.Point(12, 30);
            this.addRowButton.Name = "addRowButton";
            this.addRowButton.Size = new System.Drawing.Size(93, 37);
            this.addRowButton.TabIndex = 1;
            this.addRowButton.Text = "Add Row";
            this.addRowButton.UseVisualStyleBackColor = false;
            this.addRowButton.Click += new System.EventHandler(this.AddRow_Click);
            // 
            // expressionTextBox
            // 
            this.expressionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expressionTextBox.Font = new System.Drawing.Font("Century", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expressionTextBox.Location = new System.Drawing.Point(607, 31);
            this.expressionTextBox.Name = "expressionTextBox";
            this.expressionTextBox.Size = new System.Drawing.Size(247, 36);
            this.expressionTextBox.TabIndex = 5;
            // 
            // deleteRowButton
            // 
            this.deleteRowButton.AutoSize = true;
            this.deleteRowButton.BackColor = System.Drawing.SystemColors.Control;
            this.deleteRowButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteRowButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.deleteRowButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteRowButton.Location = new System.Drawing.Point(123, 30);
            this.deleteRowButton.Name = "deleteRowButton";
            this.deleteRowButton.Size = new System.Drawing.Size(93, 37);
            this.deleteRowButton.TabIndex = 6;
            this.deleteRowButton.Text = "Delete Row";
            this.deleteRowButton.UseVisualStyleBackColor = false;
            this.deleteRowButton.Click += new System.EventHandler(this.DeleteRow_Click);
            // 
            // addColumnButton
            // 
            this.addColumnButton.AutoSize = true;
            this.addColumnButton.BackColor = System.Drawing.SystemColors.Control;
            this.addColumnButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addColumnButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.addColumnButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addColumnButton.Location = new System.Drawing.Point(238, 31);
            this.addColumnButton.Name = "addColumnButton";
            this.addColumnButton.Size = new System.Drawing.Size(94, 37);
            this.addColumnButton.TabIndex = 7;
            this.addColumnButton.Text = "Add Column";
            this.addColumnButton.UseVisualStyleBackColor = false;
            this.addColumnButton.Click += new System.EventHandler(this.AddColumn_Click);
            // 
            // deleteColumnButton
            // 
            this.deleteColumnButton.AutoSize = true;
            this.deleteColumnButton.BackColor = System.Drawing.SystemColors.Control;
            this.deleteColumnButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteColumnButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.deleteColumnButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteColumnButton.Location = new System.Drawing.Point(353, 31);
            this.deleteColumnButton.Name = "deleteColumnButton";
            this.deleteColumnButton.Size = new System.Drawing.Size(110, 37);
            this.deleteColumnButton.TabIndex = 8;
            this.deleteColumnButton.Text = "Delete Column";
            this.deleteColumnButton.UseVisualStyleBackColor = false;
            this.deleteColumnButton.Click += new System.EventHandler(this.DeleteColumn_Click);
            // 
            // evaluateButton
            // 
            this.evaluateButton.AutoSize = true;
            this.evaluateButton.BackColor = System.Drawing.SystemColors.Control;
            this.evaluateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.evaluateButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.evaluateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.evaluateButton.Location = new System.Drawing.Point(914, 30);
            this.evaluateButton.Name = "evaluateButton";
            this.evaluateButton.Size = new System.Drawing.Size(105, 37);
            this.evaluateButton.TabIndex = 9;
            this.evaluateButton.Text = "Evaluate";
            this.evaluateButton.UseVisualStyleBackColor = false;
            this.evaluateButton.Click += new System.EventHandler(this.Evaluate_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1034, 28);
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
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.Save_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.Open_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToDocumentationToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // goToDocumentationToolStripMenuItem
            // 
            this.goToDocumentationToolStripMenuItem.Name = "goToDocumentationToolStripMenuItem";
            this.goToDocumentationToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.goToDocumentationToolStripMenuItem.Text = "Go to documentation";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // resetButton
            // 
            this.resetButton.AutoSize = true;
            this.resetButton.BackColor = System.Drawing.SystemColors.Control;
            this.resetButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.resetButton.Location = new System.Drawing.Point(479, 30);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(110, 37);
            this.resetButton.TabIndex = 11;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.Reset_Click);
            // 
            // RealExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 706);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.evaluateButton);
            this.Controls.Add(this.deleteColumnButton);
            this.Controls.Add(this.addColumnButton);
            this.Controls.Add(this.deleteRowButton);
            this.Controls.Add(this.expressionTextBox);
            this.Controls.Add(this.addRowButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Button addRowButton;
        private System.Windows.Forms.Button deleteRowButton;
        private System.Windows.Forms.Button addColumnButton;
        private System.Windows.Forms.Button deleteColumnButton;
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
        private System.Windows.Forms.Button resetButton;
    }
}

