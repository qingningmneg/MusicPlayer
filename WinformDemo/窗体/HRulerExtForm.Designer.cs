namespace WinformDemo
{
    partial class HRulerExtForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.vRulerExt1 = new WinformControlLibraryExtension.VRulerExt();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.hRulerExt1 = new WinformControlLibraryExtension.HRulerExt();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.vRulerExt1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.hRulerExt1);
            this.panel1.Location = new System.Drawing.Point(686, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 698);
            this.panel1.TabIndex = 16;
            // 
            // vRulerExt1
            // 
            this.vRulerExt1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.vRulerExt1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.vRulerExt1.Location = new System.Drawing.Point(0, 40);
            this.vRulerExt1.MasterDivideMagnification = 10F;
            this.vRulerExt1.Name = "vRulerExt1";
            this.vRulerExt1.Size = new System.Drawing.Size(40, 646);
            this.vRulerExt1.TabIndex = 0;
            this.vRulerExt1.TabStop = false;
            this.vRulerExt1.Text = "vRulerExt1";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(41, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(736, 654);
            this.panel2.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.YellowGreen;
            this.panel3.Location = new System.Drawing.Point(211, 171);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 200);
            this.panel3.TabIndex = 0;
            this.panel3.Leave += new System.EventHandler(this.panel3_Leave);
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseMove);
            this.panel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseUp);
            // 
            // hRulerExt1
            // 
            this.hRulerExt1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hRulerExt1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.hRulerExt1.Location = new System.Drawing.Point(40, 0);
            this.hRulerExt1.MasterDivideMagnification = 10F;
            this.hRulerExt1.Name = "hRulerExt1";
            this.hRulerExt1.Size = new System.Drawing.Size(732, 40);
            this.hRulerExt1.TabIndex = 0;
            this.hRulerExt1.TabStop = false;
            this.hRulerExt1.Text = "hRulerExt1";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.SelectedObject = this.hRulerExt1;
            this.propertyGrid1.Size = new System.Drawing.Size(642, 885);
            this.propertyGrid1.TabIndex = 12;
            // 
            // HRulerExtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1473, 886);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.propertyGrid1);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "HRulerExtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckBox控件";
            this.Load += new System.EventHandler(this.HRulerExtForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }





        #endregion
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private WinformControlLibraryExtension.HRulerExt hRulerExt1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private WinformControlLibraryExtension.VRulerExt vRulerExt1;
    }
}