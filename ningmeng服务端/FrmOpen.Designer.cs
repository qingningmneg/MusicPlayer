namespace ningmeng服务端
{
    partial class FrmOpen
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
            this.lblIP = new System.Windows.Forms.Label();
            this.lblport = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnopen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(50, 44);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(46, 14);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "IP地址:";
            // 
            // lblport
            // 
            this.lblport.AutoSize = true;
            this.lblport.Location = new System.Drawing.Point(50, 133);
            this.lblport.Name = "lblport";
            this.lblport.Size = new System.Drawing.Size(35, 14);
            this.lblport.TabIndex = 1;
            this.lblport.Text = "端口:";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(102, 41);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(232, 22);
            this.txtIp.TabIndex = 2;
            this.txtIp.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(102, 130);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(232, 22);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "50000";
            // 
            // btnopen
            // 
            this.btnopen.Location = new System.Drawing.Point(152, 231);
            this.btnopen.Name = "btnopen";
            this.btnopen.Size = new System.Drawing.Size(75, 23);
            this.btnopen.TabIndex = 4;
            this.btnopen.Text = "开启服务";
            this.btnopen.UseVisualStyleBackColor = true;
            this.btnopen.Click += new System.EventHandler(this.btnopen_Click);
            // 
            // FrmOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 327);
            this.Controls.Add(this.btnopen);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.lblport);
            this.Controls.Add(this.lblIP);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmOpen";
            this.Text = "开启服务";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblport;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnopen;
    }
}