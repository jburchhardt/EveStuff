namespace EveStuff
{
    partial class MainForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.rawMaterialsTab = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.eveTypeList = new EveStuff.EveTypeList();
            this.eveTypeDetails = new EveStuff.EveTypeDetails();
            this.tabControl.SuspendLayout();
            this.rawMaterialsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.rawMaterialsTab);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(748, 344);
            this.tabControl.TabIndex = 0;
            this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Selecting);
            // 
            // rawMaterialsTab
            // 
            this.rawMaterialsTab.Controls.Add(this.eveTypeList);
            this.rawMaterialsTab.Controls.Add(this.eveTypeDetails);
            this.rawMaterialsTab.Location = new System.Drawing.Point(4, 25);
            this.rawMaterialsTab.Name = "rawMaterialsTab";
            this.rawMaterialsTab.Padding = new System.Windows.Forms.Padding(3);
            this.rawMaterialsTab.Size = new System.Drawing.Size(740, 315);
            this.rawMaterialsTab.TabIndex = 0;
            this.rawMaterialsTab.Text = "Raw Materials";
            this.rawMaterialsTab.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(740, 315);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rawMaterialsList
            // 
            this.eveTypeList.DataObject = null;
            this.eveTypeList.Location = new System.Drawing.Point(277, 6);
            this.eveTypeList.Name = "rawMaterialsList";
            this.eveTypeList.Selected = null;
            this.eveTypeList.Size = new System.Drawing.Size(452, 302);
            this.eveTypeList.TabIndex = 1;
            // 
            // rawMaterialDetails
            // 
            this.eveTypeDetails.Location = new System.Drawing.Point(8, 6);
            this.eveTypeDetails.Name = "rawMaterialDetails";
            this.eveTypeDetails.Size = new System.Drawing.Size(193, 150);
            this.eveTypeDetails.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 344);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "EveStuff";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.rawMaterialsTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage rawMaterialsTab;
        private EveTypeList eveTypeList;
        private EveTypeDetails eveTypeDetails;
        private System.Windows.Forms.TabPage tabPage2;

    }
}

