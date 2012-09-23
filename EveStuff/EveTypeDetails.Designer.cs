namespace EveStuff
{
    partial class EveTypeDetails
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.eveTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.eveTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eveTypeBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(13, 50);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(166, 22);
            this.nameTextBox.TabIndex = 2;
            // 
            // priceTextBox
            // 
            this.priceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eveTypeBindingSource, "Price", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.priceTextBox.Location = new System.Drawing.Point(13, 78);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(166, 22);
            this.priceTextBox.TabIndex = 3;
            // 
            // eveTypeBindingSource
            // 
            this.eveTypeBindingSource.DataSource = typeof(EveStuff.Model.EveType);
            // 
            // RawMaterialDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Name = "RawMaterialDetails";
            this.Size = new System.Drawing.Size(193, 150);
            ((System.ComponentModel.ISupportInitialize)(this.eveTypeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource eveTypeBindingSource;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox priceTextBox;

    }
}
