namespace OrderManagementSystem
{
    partial class FrmSales
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
            this.btnSave = new System.Windows.Forms.Button();
            this.tblSales = new System.Windows.Forms.DataGridView();
            this.brnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblSales)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(472, 38);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 36);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tblSales
            // 
            this.tblSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSales.Location = new System.Drawing.Point(0, 102);
            this.tblSales.Name = "tblSales";
            this.tblSales.RowHeadersWidth = 51;
            this.tblSales.RowTemplate.Height = 29;
            this.tblSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblSales.Size = new System.Drawing.Size(863, 342);
            this.tblSales.TabIndex = 10;
            // 
            // brnDelete
            // 
            this.brnDelete.Location = new System.Drawing.Point(735, 38);
            this.brnDelete.Name = "brnDelete";
            this.brnDelete.Size = new System.Drawing.Size(106, 36);
            this.brnDelete.TabIndex = 11;
            this.brnDelete.Text = "Delete";
            this.brnDelete.UseVisualStyleBackColor = true;
            this.brnDelete.Click += new System.EventHandler(this.brnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(605, 38);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(106, 36);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(22, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 37);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sales";
            // 
            // FrmSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(862, 443);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.brnDelete);
            this.Controls.Add(this.tblSales);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.Name = "FrmSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSales";
            this.Load += new System.EventHandler(this.FrmSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblSales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnSave;
        private DataGridView tblSales;
        private Button brnDelete;
        private Button btnEdit;
        private Label label3;
    }
}