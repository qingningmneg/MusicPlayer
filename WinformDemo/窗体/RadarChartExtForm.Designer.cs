namespace WinformDemo
{
    partial class RadarChartExtForm
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
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine1 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine2 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine3 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine4 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine5 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine6 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine7 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine8 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine9 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine10 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine11 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine12 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine13 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine14 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.radarChartExt1 = new WinformControlLibraryExtension.RadarChartExt();
            this.radarChartExt2 = new WinformControlLibraryExtension.RadarChartExt();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.SelectedObject = this.radarChartExt1;
            this.propertyGrid1.Size = new System.Drawing.Size(642, 1225);
            this.propertyGrid1.TabIndex = 14;
            // 
            // radarChartExt1
            // 
            this.radarChartExt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.radarChartExt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radarChartExt1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radarChartExt1.BorderShow = true;
            this.radarChartExt1.CausesValidation = false;
            chartLine1.LineText = "星期一";
            chartLine2.LineText = "星期二";
            chartLine3.LineText = "星期三";
            chartLine4.LineText = "星期四";
            chartLine5.LineText = "星期五";
            chartLine6.LineText = "星期六";
            chartLine7.LineText = "星期日";
            this.radarChartExt1.ChartLineItems.Add(chartLine1);
            this.radarChartExt1.ChartLineItems.Add(chartLine2);
            this.radarChartExt1.ChartLineItems.Add(chartLine3);
            this.radarChartExt1.ChartLineItems.Add(chartLine4);
            this.radarChartExt1.ChartLineItems.Add(chartLine5);
            this.radarChartExt1.ChartLineItems.Add(chartLine6);
            this.radarChartExt1.ChartLineItems.Add(chartLine7);
            this.radarChartExt1.Location = new System.Drawing.Point(695, 47);
            this.radarChartExt1.LoopBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radarChartExt1.LoopEvenBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.radarChartExt1.LoopLineMaxValueShow = true;
            this.radarChartExt1.LoopLineMinValueShow = true;
            this.radarChartExt1.LoopLineMinValueTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.radarChartExt1.LoopOddBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radarChartExt1.LoopScaleTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.radarChartExt1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.radarChartExt1.Name = "radarChartExt1";
            this.radarChartExt1.OptionAreaWidth = 100;
            this.radarChartExt1.OptionTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.radarChartExt1.OptionTipTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radarChartExt1.Padding = new System.Windows.Forms.Padding(18);
            this.radarChartExt1.Size = new System.Drawing.Size(735, 556);
            this.radarChartExt1.TabIndex = 0;
            this.radarChartExt1.TabStop = false;
            this.radarChartExt1.Title = "实时分析图";
            this.radarChartExt1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(112)))), ((int)(((byte)(147)))));
            // 
            // radarChartExt2
            // 
            this.radarChartExt2.AnimationTime = 500;
            this.radarChartExt2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.radarChartExt2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radarChartExt2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radarChartExt2.CausesValidation = false;
            chartLine8.LineText = "星期一";
            chartLine9.LineText = "星期二";
            chartLine10.LineText = "星期三";
            chartLine11.LineText = "星期四";
            chartLine12.LineText = "星期五";
            chartLine13.LineText = "星期六";
            chartLine14.LineText = "星期日";
            this.radarChartExt2.ChartLineItems.Add(chartLine8);
            this.radarChartExt2.ChartLineItems.Add(chartLine9);
            this.radarChartExt2.ChartLineItems.Add(chartLine10);
            this.radarChartExt2.ChartLineItems.Add(chartLine11);
            this.radarChartExt2.ChartLineItems.Add(chartLine12);
            this.radarChartExt2.ChartLineItems.Add(chartLine13);
            this.radarChartExt2.ChartLineItems.Add(chartLine14);
            this.radarChartExt2.ChartType = WinformControlLibraryExtension.RadarChartExt.ChartTypes.Rhombus;
            this.radarChartExt2.Location = new System.Drawing.Point(695, 614);
            this.radarChartExt2.LoopBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radarChartExt2.LoopEvenBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.radarChartExt2.LoopLineMinValueTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.radarChartExt2.LoopOddBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radarChartExt2.LoopScaleTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.radarChartExt2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.radarChartExt2.Name = "radarChartExt2";
            this.radarChartExt2.OptionAreaWidth = 100;
            this.radarChartExt2.OptionTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.radarChartExt2.OptionTipTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radarChartExt2.Padding = new System.Windows.Forms.Padding(18);
            this.radarChartExt2.Size = new System.Drawing.Size(735, 556);
            this.radarChartExt2.TabIndex = 0;
            this.radarChartExt2.TabStop = false;
            this.radarChartExt2.Text = "分析图";
            this.radarChartExt2.Title = "静态分析图";
            this.radarChartExt2.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(112)))), ((int)(((byte)(147)))));
            // 
            // RadarChartExtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1469, 1225);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.radarChartExt2);
            this.Controls.Add(this.radarChartExt1);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "RadarChartExtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "雷达分析图控件";
            this.Load += new System.EventHandler(this.RadarChartForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WinformControlLibraryExtension.RadarChartExt radarChartExt1;
        private WinformControlLibraryExtension.RadarChartExt radarChartExt2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}