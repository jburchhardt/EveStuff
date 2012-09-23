namespace EveStuff
{
    partial class EveTypeList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.eveTypeInfoDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eveTypeInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.eveTypeInfoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eveTypeInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // eveTypeInfoDataGridView
            // 
            this.eveTypeInfoDataGridView.AllowUserToAddRows = false;
            this.eveTypeInfoDataGridView.AllowUserToDeleteRows = false;
            this.eveTypeInfoDataGridView.AutoGenerateColumns = false;
            this.eveTypeInfoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eveTypeInfoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.eveTypeInfoDataGridView.DataSource = this.eveTypeInfoBindingSource;
            this.eveTypeInfoDataGridView.Location = new System.Drawing.Point(3, 3);
            this.eveTypeInfoDataGridView.Name = "eveTypeInfoDataGridView";
            this.eveTypeInfoDataGridView.RowHeadersVisible = false;
            this.eveTypeInfoDataGridView.RowTemplate.Height = 24;
            this.eveTypeInfoDataGridView.Size = new System.Drawing.Size(450, 300);
            this.eveTypeInfoDataGridView.TabIndex = 0;
            this.eveTypeInfoDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.eveTypeDataGridView_CellClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Group";
            this.dataGridViewTextBoxColumn4.HeaderText = "Group";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Price";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn5.HeaderText = "Price";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // eveTypeInfoBindingSource
            // 
            this.eveTypeInfoBindingSource.DataSource = typeof(EveStuff.EveTypeInfo);
            // 
            // RawMaterialsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.eveTypeInfoDataGridView);
            this.Name = "RawMaterialsList";
            this.Size = new System.Drawing.Size(452, 302);
            ((System.ComponentModel.ISupportInitialize)(this.eveTypeInfoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eveTypeInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource eveTypeInfoBindingSource;
        private System.Windows.Forms.DataGridView eveTypeInfoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

    }
}
