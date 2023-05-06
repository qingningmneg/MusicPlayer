namespace 窗体
{
    partial class FrmAdminMainFrom
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.xtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.menuExt1 = new WinformControlLibraryExtension.SlideMenuPanelExt();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabbedMdiManager
            // 
            this.xtraTabbedMdiManager.MdiParent = this;
            // 
            // menuExt1
            // 
            this.menuExt1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuExt1.Location = new System.Drawing.Point(0, 0);
            this.menuExt1.Menu.DisableBackColor = System.Drawing.Color.Empty;
            this.menuExt1.Menu.DisableTextColor = System.Drawing.Color.Empty;
            this.menuExt1.Menu.EnterTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuExt1.Menu.NormalTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuExt1.MenuTab.DisableBackColor = System.Drawing.Color.Empty;
            this.menuExt1.MenuTab.DisableTextColor = System.Drawing.Color.Empty;
            this.menuExt1.MenuTab.EnterTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuExt1.MenuTab.NormalTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuExt1.MenuTab.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuExt1.Name = "menuExt1";
            this.menuExt1.Scroll.SlideDisableBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.menuExt1.Size = new System.Drawing.Size(158, 525);
            this.menuExt1.TabIndex = 0;
            this.menuExt1.TabStop = false;
            this.menuExt1.NodeClick += new WinformControlLibraryExtension.SlideMenuPanelExt.NodeClickEventHandler(this.MenuPanel_NodeClick);
            // 
            // FrmAdminMainFrom
            // 
            this.ActiveGlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(197)))), ((int)(((byte)(175)))));
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 525);
            this.Controls.Add(this.menuExt1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAdminMainFrom";
            this.Text = "柠檬音乐播放器(管理端)";
            this.Load += new System.EventHandler(this.FrmMainFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager;
        private WinformControlLibraryExtension.SlideMenuPanelExt menuExt1;
    }
}

