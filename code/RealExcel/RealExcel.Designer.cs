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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(22, 78);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(997, 452);
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
            this.addRowButton.Location = new System.Drawing.Point(22, 23);
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
            this.expressionTextBox.Location = new System.Drawing.Point(630, 26);
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
            this.deleteRowButton.Location = new System.Drawing.Point(143, 23);
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
            this.addColumnButton.Location = new System.Drawing.Point(267, 23);
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
            this.deleteColumnButton.Location = new System.Drawing.Point(392, 23);
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
            this.evaluateButton.Location = new System.Drawing.Point(914, 23);
            this.evaluateButton.Name = "evaluateButton";
            this.evaluateButton.Size = new System.Drawing.Size(105, 37);
            this.evaluateButton.TabIndex = 9;
            this.evaluateButton.Text = "Evaluate";
            this.evaluateButton.UseVisualStyleBackColor = false;
            this.evaluateButton.Click += new System.EventHandler(this.Evaluate_Click);
            // 
            // RealExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 553);
            this.Controls.Add(this.evaluateButton);
            this.Controls.Add(this.deleteColumnButton);
            this.Controls.Add(this.addColumnButton);
            this.Controls.Add(this.deleteRowButton);
            this.Controls.Add(this.expressionTextBox);
            this.Controls.Add(this.addRowButton);
            this.Controls.Add(this.dataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RealExcel";
            this.Text = "RealExcel";
            this.Load += new System.EventHandler(this.RealExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
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
    }
}

