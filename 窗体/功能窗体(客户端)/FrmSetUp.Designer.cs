namespace 窗体
{
    /// <summary>
    /// 设置窗体
    /// </summary>
    partial class FrmSetUp
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
            this.lblMusicFolderPath = new DevExpress.XtraEditors.LabelControl();
            this.txtMusicPath = new DevExpress.XtraEditors.TextEdit();
            this.btnSetUp = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusicPath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMusicFolderPath
            // 
            this.lblMusicFolderPath.Location = new System.Drawing.Point(12, 12);
            this.lblMusicFolderPath.Name = "lblMusicFolderPath";
            this.lblMusicFolderPath.Size = new System.Drawing.Size(84, 14);
            this.lblMusicFolderPath.TabIndex = 0;
            this.lblMusicFolderPath.Text = "音乐文件夹位置";
            // 
            // txtMusicPath
            // 
            this.txtMusicPath.Location = new System.Drawing.Point(12, 32);
            this.txtMusicPath.Name = "txtMusicPath";
            this.txtMusicPath.Size = new System.Drawing.Size(260, 20);
            this.txtMusicPath.TabIndex = 1;
            // 
            // btnSetUp
            // 
            this.btnSetUp.Location = new System.Drawing.Point(278, 31);
            this.btnSetUp.Name = "btnSetUp";
            this.btnSetUp.Size = new System.Drawing.Size(75, 23);
            this.btnSetUp.TabIndex = 2;
            this.btnSetUp.Text = "设置";
            this.btnSetUp.Click += new System.EventHandler(this.btnSetUp_Click);
            // 
            // FrmSetUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 489);
            this.Controls.Add(this.btnSetUp);
            this.Controls.Add(this.txtMusicPath);
            this.Controls.Add(this.lblMusicFolderPath);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmSetUp";
            this.Text = "设置";
            ((System.ComponentModel.ISupportInitialize)(this.txtMusicPath.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblMusicFolderPath;
        private DevExpress.XtraEditors.TextEdit txtMusicPath;
        private DevExpress.XtraEditors.SimpleButton btnSetUp;
    }
}