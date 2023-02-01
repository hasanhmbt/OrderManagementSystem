namespace OrderManagementSystem
{
    partial class FrmReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dateFinishproduct = new System.Windows.Forms.DateTimePicker();
            this.datebeginproduct = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tblProductReport = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductReport)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(539, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Begin date";
            // 
            // dateFinishproduct
            // 
            this.dateFinishproduct.AccessibleDescription = "";
            this.dateFinishproduct.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFinishproduct.Location = new System.Drawing.Point(668, 53);
            this.dateFinishproduct.Name = "dateFinishproduct";
            this.dateFinishproduct.Size = new System.Drawing.Size(123, 27);
            this.dateFinishproduct.TabIndex = 2;
            this.dateFinishproduct.ValueChanged += new System.EventHandler(this.dateTimePicker4_ValueChanged);
            // 
            // datebeginproduct
            // 
            this.datebeginproduct.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datebeginproduct.Location = new System.Drawing.Point(500, 53);
            this.datebeginproduct.Name = "datebeginproduct";
            this.datebeginproduct.Size = new System.Drawing.Size(123, 27);
            this.datebeginproduct.TabIndex = 1;
            this.datebeginproduct.ValueChanged += new System.EventHandler(this.dateTimePicker3_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(721, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "End date";
            // 
            // tblProductReport
            // 
            this.tblProductReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblProductReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblProductReport.Location = new System.Drawing.Point(-8, 101);
            this.tblProductReport.Name = "tblProductReport";
            this.tblProductReport.RowHeadersWidth = 51;
            this.tblProductReport.RowTemplate.Height = 29;
            this.tblProductReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblProductReport.Size = new System.Drawing.Size(813, 344);
            this.tblProductReport.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Reports";
            // 
            // FrmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(803, 440);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tblProductReport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateFinishproduct);
            this.Controls.Add(this.datebeginproduct);
            this.MaximizeBox = false;
            this.Name = "FrmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReports";
            this.Load += new System.EventHandler(this.FrmReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblProductReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DateTimePicker dateFinishproduct;
        private DateTimePicker datebeginproduct;
        private Label label1;
        private Label label2;
        private DataGridView tblProductReport;
        private Label label3;
    }
}