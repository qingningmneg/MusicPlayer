namespace 窗体
{
    partial class FrmUploadFile
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
            this.components = new System.ComponentModel.Container();
            this.btnUploadFile = new System.Windows.Forms.Button();
            this.labtitle = new System.Windows.Forms.Label();
            this.labsinger = new System.Windows.Forms.Label();
            this.labfile_time = new System.Windows.Forms.Label();
            this.labfile_image = new System.Windows.Forms.Label();
            this.labis_Enable = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCenCel = new System.Windows.Forms.Button();
            this.txttitle = new System.Windows.Forms.TextBox();
            this.txtsinger = new System.Windows.Forms.TextBox();
            this.txtfile_time = new System.Windows.Forms.TextBox();
            this.radEnable = new System.Windows.Forms.RadioButton();
            this.radNoEnable = new System.Windows.Forms.RadioButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labUploadfile = new System.Windows.Forms.Label();
            this.btn_file_image = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnPreview = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.Location = new System.Drawing.Point(12, 12);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(775, 425);
            this.btnUploadFile.TabIndex = 0;
            this.btnUploadFile.Text = "上传音频文件";
            this.btnUploadFile.UseVisualStyleBackColor = true;
            this.btnUploadFile.Click += new System.EventHandler(this.btnUploadFile_Click);
            // 
            // labtitle
            // 
            this.labtitle.AutoSize = true;
            this.labtitle.Location = new System.Drawing.Point(312, 85);
            this.labtitle.Name = "labtitle";
            this.labtitle.Size = new System.Drawing.Size(47, 14);
            this.labtitle.TabIndex = 1;
            this.labtitle.Text = "标   题:";
            // 
            // labsinger
            // 
            this.labsinger.AutoSize = true;
            this.labsinger.Location = new System.Drawing.Point(312, 126);
            this.labsinger.Name = "labsinger";
            this.labsinger.Size = new System.Drawing.Size(47, 14);
            this.labsinger.TabIndex = 2;
            this.labsinger.Text = "歌   手:";
            // 
            // labfile_time
            // 
            this.labfile_time.AutoSize = true;
            this.labfile_time.Location = new System.Drawing.Point(254, 179);
            this.labfile_time.Name = "labfile_time";
            this.labfile_time.Size = new System.Drawing.Size(105, 14);
            this.labfile_time.TabIndex = 3;
            this.labfile_time.Text = "歌曲时间(非必填):";
            // 
            // labfile_image
            // 
            this.labfile_image.AutoSize = true;
            this.labfile_image.Location = new System.Drawing.Point(254, 225);
            this.labfile_image.Name = "labfile_image";
            this.labfile_image.Size = new System.Drawing.Size(105, 14);
            this.labfile_image.TabIndex = 4;
            this.labfile_image.Text = "音乐图片(非必填):";
            // 
            // labis_Enable
            // 
            this.labis_Enable.AutoSize = true;
            this.labis_Enable.Location = new System.Drawing.Point(300, 260);
            this.labis_Enable.Name = "labis_Enable";
            this.labis_Enable.Size = new System.Drawing.Size(59, 14);
            this.labis_Enable.TabIndex = 5;
            this.labis_Enable.Text = "是否启用:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(412, 319);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCenCel
            // 
            this.btnCenCel.Location = new System.Drawing.Point(519, 319);
            this.btnCenCel.Name = "btnCenCel";
            this.btnCenCel.Size = new System.Drawing.Size(75, 23);
            this.btnCenCel.TabIndex = 7;
            this.btnCenCel.Text = "取消";
            this.btnCenCel.UseVisualStyleBackColor = true;
            this.btnCenCel.Click += new System.EventHandler(this.btnCenCel_Click);
            // 
            // txttitle
            // 
            this.txttitle.Location = new System.Drawing.Point(366, 82);
            this.txttitle.Name = "txttitle";
            this.txttitle.Size = new System.Drawing.Size(343, 22);
            this.txttitle.TabIndex = 8;
            // 
            // txtsinger
            // 
            this.txtsinger.Location = new System.Drawing.Point(366, 123);
            this.txtsinger.Name = "txtsinger";
            this.txtsinger.Size = new System.Drawing.Size(343, 22);
            this.txtsinger.TabIndex = 9;
            // 
            // txtfile_time
            // 
            this.txtfile_time.Location = new System.Drawing.Point(366, 171);
            this.txtfile_time.Name = "txtfile_time";
            this.txtfile_time.Size = new System.Drawing.Size(343, 22);
            this.txtfile_time.TabIndex = 10;
            // 
            // radEnable
            // 
            this.radEnable.AutoSize = true;
            this.radEnable.Checked = true;
            this.radEnable.Location = new System.Drawing.Point(412, 258);
            this.radEnable.Name = "radEnable";
            this.radEnable.Size = new System.Drawing.Size(49, 18);
            this.radEnable.TabIndex = 12;
            this.radEnable.TabStop = true;
            this.radEnable.Text = "启用";
            this.radEnable.UseVisualStyleBackColor = true;
            // 
            // radNoEnable
            // 
            this.radNoEnable.AutoSize = true;
            this.radNoEnable.Location = new System.Drawing.Point(533, 258);
            this.radNoEnable.Name = "radNoEnable";
            this.radNoEnable.Size = new System.Drawing.Size(61, 18);
            this.radNoEnable.TabIndex = 13;
            this.radNoEnable.Text = "不启用";
            this.radNoEnable.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // labUploadfile
            // 
            this.labUploadfile.AutoSize = true;
            this.labUploadfile.Location = new System.Drawing.Point(731, 12);
            this.labUploadfile.Name = "labUploadfile";
            this.labUploadfile.Size = new System.Drawing.Size(43, 14);
            this.labUploadfile.TabIndex = 14;
            this.labUploadfile.Text = "上传中";
            // 
            // btn_file_image
            // 
            this.btn_file_image.Location = new System.Drawing.Point(366, 221);
            this.btn_file_image.Name = "btn_file_image";
            this.btn_file_image.Size = new System.Drawing.Size(343, 23);
            this.btn_file_image.TabIndex = 15;
            this.btn_file_image.Text = "上传图片";
            this.btn_file_image.UseVisualStyleBackColor = true;
            this.btn_file_image.Click += new System.EventHandler(this.btn_file_image_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(56, 82);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(178, 162);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 16;
            this.pictureBox.TabStop = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(94, 260);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(108, 23);
            this.btnPreview.TabIndex = 17;
            this.btnPreview.Text = "预览";
            this.btnPreview.UseVisualStyleBackColor = true;
            // 
            // FrmUploadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btn_file_image);
            this.Controls.Add(this.labUploadfile);
            this.Controls.Add(this.radNoEnable);
            this.Controls.Add(this.radEnable);
            this.Controls.Add(this.txtfile_time);
            this.Controls.Add(this.txtsinger);
            this.Controls.Add(this.txttitle);
            this.Controls.Add(this.btnCenCel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.labis_Enable);
            this.Controls.Add(this.labfile_image);
            this.Controls.Add(this.labfile_time);
            this.Controls.Add(this.labsinger);
            this.Controls.Add(this.labtitle);
            this.Controls.Add(this.btnUploadFile);
            this.Name = "FrmUploadFile";
            this.Text = "上传文件";
            this.Load += new System.EventHandler(this.FrmUploadFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUploadFile;
        private System.Windows.Forms.Label labtitle;
        private System.Windows.Forms.Label labsinger;
        private System.Windows.Forms.Label labfile_time;
        private System.Windows.Forms.Label labfile_image;
        private System.Windows.Forms.Label labis_Enable;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCenCel;
        private System.Windows.Forms.TextBox txttitle;
        private System.Windows.Forms.TextBox txtsinger;
        private System.Windows.Forms.TextBox txtfile_time;
        private System.Windows.Forms.RadioButton radEnable;
        private System.Windows.Forms.RadioButton radNoEnable;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labUploadfile;
        private System.Windows.Forms.Button btn_file_image;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnPreview;
    }
}