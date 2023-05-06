namespace 窗体
{
    partial class FrmVerification
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
            this.slideValidExt = new WinformControlLibraryExtension.JigsawValidExt();
            this.SuspendLayout();
            // 
            // slideValidExt
            // 
            this.slideValidExt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.slideValidExt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.slideValidExt.BorderShow = true;
            this.slideValidExt.CausesValidation = false;
            this.slideValidExt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slideValidExt.Location = new System.Drawing.Point(0, 0);
            this.slideValidExt.Name = "slideValidExt";
            this.slideValidExt.Size = new System.Drawing.Size(446, 329);
            this.slideValidExt.TabIndex = 0;
            this.slideValidExt.TabStop = false;
            this.slideValidExt.Text = "slideValidExt1";
            this.slideValidExt.ValidImage = global::窗体.Properties.Resources.bkg_flower;
            this.slideValidExt.Valided += new WinformControlLibraryExtension.JigsawValidExt.ValidedEventHandler(this.slideValidExt_Valided);
            // 
            // FrmVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 329);
            this.Controls.Add(this.slideValidExt);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmVerification";
            this.Text = "验证码";
            this.Load += new System.EventHandler(this.FrmVerification_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WinformControlLibraryExtension.JigsawValidExt slideValidExt;
    }
}