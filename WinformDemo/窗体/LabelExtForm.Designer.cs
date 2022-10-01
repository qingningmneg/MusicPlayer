namespace WinformDemo
{
    partial class LabelExtForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabelExtForm));
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.labelExt1 = new WinformControlLibraryExtension.LabelExt();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.SelectedObject = this.labelExt1;
            this.propertyGrid1.Size = new System.Drawing.Size(642, 886);
            this.propertyGrid1.TabIndex = 12;
            // 
            // labelExt1
            // 
            this.labelExt1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelExt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.labelExt1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelExt1.Location = new System.Drawing.Point(681, 57);
            this.labelExt1.Name = "labelExt1";
            this.labelExt1.ScrollBtnEnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelExt1.ScrollBtnEnterForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelExt1.ScrollBtnNormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelExt1.ScrollBtnShow = true;
            this.labelExt1.Size = new System.Drawing.Size(703, 178);
            this.labelExt1.TabIndex = 13;
            this.labelExt1.Text = resources.GetString("labelExt1.Text");
            // 
            // LabelExtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1478, 887);
            this.Controls.Add(this.labelExt1);
            this.Controls.Add(this.propertyGrid1);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "LabelExtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckBox控件";
            this.ResumeLayout(false);

        }





        #endregion
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private WinformControlLibraryExtension.LabelExt labelExt1;
    }
}