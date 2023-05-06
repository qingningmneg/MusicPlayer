namespace ningmeng服务端
{
    partial class Frmsendout
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
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btn = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClonse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(76, 2);
            this.txtFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFile.Multiline = true;
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(480, 35);
            this.txtFile.TabIndex = 0;
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(564, 2);
            this.btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(107, 35);
            this.btn.TabIndex = 1;
            this.btn.Text = "选择文件位置";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(13, 9);
            this.lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(55, 14);
            this.lbl.TabIndex = 2;
            this.lbl.Text = "文件目录";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(180, 82);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(88, 27);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClonse
            // 
            this.btnClonse.Location = new System.Drawing.Point(375, 82);
            this.btnClonse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClonse.Name = "btnClonse";
            this.btnClonse.Size = new System.Drawing.Size(88, 27);
            this.btnClonse.TabIndex = 4;
            this.btnClonse.Text = "取消";
            this.btnClonse.UseVisualStyleBackColor = true;
            // 
            // Frmsendout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 143);
            this.Controls.Add(this.btnClonse);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.txtFile);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Frmsendout";
            this.Text = "发送文件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClonse;
    }
}