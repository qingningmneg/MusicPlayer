namespace WinformDemo
{
    partial class AnomalyButtonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnomalyButtonForm));
            this.anomalyButton3 = new WinformControlLibraryExtension.AnomalyButton();
            this.anomalyButton2 = new WinformControlLibraryExtension.AnomalyButton();
            this.anomalyButton1 = new WinformControlLibraryExtension.AnomalyButton();
            this.SuspendLayout();
            // 
            // anomalyButton3
            // 
            this.anomalyButton3.BackColor = System.Drawing.Color.Transparent;
            this.anomalyButton3.BackGradualEnable = true;
            this.anomalyButton3.BackGradualPoint = new WinformControlLibraryExtension.ComplexityPropertys.PointF(150F, 24F);
            this.anomalyButton3.BackGradualRadius = 165;
            this.anomalyButton3.Cursor = System.Windows.Forms.Cursors.Default;
            this.anomalyButton3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.anomalyButton3.Location = new System.Drawing.Point(783, 28);
            this.anomalyButton3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.anomalyButton3.Name = "anomalyButton3";
            this.anomalyButton3.ShapePathLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.anomalyButton3.ShapePathPointDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.anomalyButton3.ShapePathPointNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.anomalyButton3.ShapePathPointTipColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.anomalyButton3.ShapePoints = resources.GetString("anomalyButton3.ShapePoints");
            this.anomalyButton3.Size = new System.Drawing.Size(893, 569);
            this.anomalyButton3.TabIndex = 12;
            this.anomalyButton3.Text = "猜下我是谁";
            this.anomalyButton3.TextPoint = new WinformControlLibraryExtension.ComplexityPropertys.PointF(237.35F, 77.88F);
            this.anomalyButton3.CheckedChanged += new System.EventHandler(this.anomalyButton3_CheckedChanged);
            // 
            // anomalyButton2
            // 
            this.anomalyButton2.BackColor = System.Drawing.Color.Transparent;
            this.anomalyButton2.BackDownCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(205)))), ((int)(((byte)(217)))));
            this.anomalyButton2.BackDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(208)))), ((int)(((byte)(220)))));
            this.anomalyButton2.BackEnterCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(205)))), ((int)(((byte)(217)))));
            this.anomalyButton2.BackEnterColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(205)))), ((int)(((byte)(217)))));
            this.anomalyButton2.BackGradualEnable = true;
            this.anomalyButton2.BackGradualRadius = 242;
            this.anomalyButton2.BackNormalCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(205)))), ((int)(((byte)(217)))));
            this.anomalyButton2.BackNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(196)))), ((int)(((byte)(212)))));
            this.anomalyButton2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.anomalyButton2.Location = new System.Drawing.Point(35, 504);
            this.anomalyButton2.Margin = new System.Windows.Forms.Padding(4);
            this.anomalyButton2.Name = "anomalyButton2";
            this.anomalyButton2.ShapePathLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.anomalyButton2.ShapePathPointDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.anomalyButton2.ShapePathPointNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.anomalyButton2.ShapePathPointTipColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.anomalyButton2.ShapePoints = "{12.85,38.27} {89.43,102.73} {174.42,39.58} {185.15,105.15} {354.43,22.01} {187.1" +
    "5,186.42} {83.15,186.43}";
            this.anomalyButton2.Size = new System.Drawing.Size(708, 401);
            this.anomalyButton2.TabIndex = 11;
            this.anomalyButton2.Text = "自定义形状";
            this.anomalyButton2.TextPoint = new WinformControlLibraryExtension.ComplexityPropertys.PointF(137.29F, 143F);
            // 
            // anomalyButton1
            // 
            this.anomalyButton1.BackColor = System.Drawing.Color.Transparent;
            this.anomalyButton1.BackGradualEnable = true;
            this.anomalyButton1.BackGradualRadius = 349;
            this.anomalyButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.anomalyButton1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.anomalyButton1.Location = new System.Drawing.Point(35, 28);
            this.anomalyButton1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.anomalyButton1.Name = "anomalyButton1";
            this.anomalyButton1.ShapePathLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.anomalyButton1.ShapePathPointDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.anomalyButton1.ShapePathPointNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.anomalyButton1.ShapePathPointTipColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.anomalyButton1.ShapePoints = "{42.27,28.82} {175.55,111.68} {292.85,57.96} {394.15,165.4} {335.28,211.17} {59.4" +
    "1,147.18} {6.89,75.73}";
            this.anomalyButton1.Size = new System.Drawing.Size(708, 452);
            this.anomalyButton1.TabIndex = 0;
            this.anomalyButton1.Text = "自定义形状";
            this.anomalyButton1.TextPoint = new WinformControlLibraryExtension.ComplexityPropertys.PointF(266.49F, 141.88F);
            this.anomalyButton1.CheckedChanged += new System.EventHandler(this.anomalyButton1_CheckBefore);
            this.anomalyButton1.Click += new System.EventHandler(this.anomalyButton1_Click);
            // 
            // AnomalyButtonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1788, 1088);
            this.Controls.Add(this.anomalyButton3);
            this.Controls.Add(this.anomalyButton2);
            this.Controls.Add(this.anomalyButton1);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "AnomalyButtonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "不规则形状按钮";
            this.Load += new System.EventHandler(this.AnomalyButtonForm_Load);
            this.ResumeLayout(false);

        }









        #endregion

        private WinformControlLibraryExtension.AnomalyButton anomalyButton1;
        private WinformControlLibraryExtension.AnomalyButton anomalyButton2;
        private WinformControlLibraryExtension.AnomalyButton anomalyButton3;
    }
}