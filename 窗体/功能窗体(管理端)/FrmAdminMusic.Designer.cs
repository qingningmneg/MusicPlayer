namespace 窗体
{
    partial class FrmAdminMusic
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
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar = new DevExpress.XtraBars.Bar();
            this.btnUploadFile = new DevExpress.XtraBars.BarButtonItem();
            this.btnUpdataMusic = new DevExpress.XtraBars.BarButtonItem();
            this.btnEnable = new DevExpress.XtraBars.BarButtonItem();
            this.btnDisable = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.guid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.file_size = new DevExpress.XtraGrid.Columns.GridColumn();
            this.file_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.file_singer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.file_hast = new DevExpress.XtraGrid.Columns.GridColumn();
            this.file_all_path = new DevExpress.XtraGrid.Columns.GridColumn();
            this.title = new DevExpress.XtraGrid.Columns.GridColumn();
            this.singer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.file_image = new DevExpress.XtraGrid.Columns.GridColumn();
            this.file_time = new DevExpress.XtraGrid.Columns.GridColumn();
            this.is_Enable = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnUploadFile,
            this.btnEnable,
            this.btnDisable,
            this.btnUpdataMusic});
            this.barManager.MaxItemId = 4;
            // 
            // bar
            // 
            this.bar.BarName = "Tools";
            this.bar.DockCol = 0;
            this.bar.DockRow = 0;
            this.bar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUploadFile),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUpdataMusic),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEnable),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDisable)});
            this.bar.OptionsBar.UseWholeRow = true;
            this.bar.Text = "Tools";
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.Caption = "上传文件";
            this.btnUploadFile.Id = 0;
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUploadFile_ItemClick);
            // 
            // btnUpdataMusic
            // 
            this.btnUpdataMusic.Caption = "编辑音乐";
            this.btnUpdataMusic.Id = 3;
            this.btnUpdataMusic.Name = "btnUpdataMusic";
            this.btnUpdataMusic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUpdataMusic_ItemClick);
            // 
            // btnEnable
            // 
            this.btnEnable.Caption = "启用音乐";
            this.btnEnable.Id = 1;
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEnable_ItemClick);
            // 
            // btnDisable
            // 
            this.btnDisable.Caption = "禁用音乐";
            this.btnDisable.Id = 2;
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDisable_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlTop.Size = new System.Drawing.Size(933, 21);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 525);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(933, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 21);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 504);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(933, 21);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 504);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl.Location = new System.Drawing.Point(0, 21);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl.MenuManager = this.barManager;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(933, 504);
            this.gridControl.TabIndex = 4;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.gridControl.DoubleClick += new System.EventHandler(this.gridControl_DoubleClick);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.guid,
            this.file_size,
            this.file_id,
            this.file_singer,
            this.file_hast,
            this.file_all_path,
            this.title,
            this.singer,
            this.file_image,
            this.file_time,
            this.is_Enable});
            this.gridView.DetailHeight = 408;
            this.gridView.GridControl = this.gridControl;
            this.gridView.GroupPanelText = "音乐歌单";
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsClipboard.AllowExcelFormat = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsDetail.AllowExpandEmptyDetails = true;
            // 
            // guid
            // 
            this.guid.Caption = "guid";
            this.guid.FieldName = "guid";
            this.guid.Name = "guid";
            this.guid.Width = 87;
            // 
            // file_size
            // 
            this.file_size.Caption = "文件大小";
            this.file_size.FieldName = "file_size";
            this.file_size.Name = "file_size";
            this.file_size.Width = 87;
            // 
            // file_id
            // 
            this.file_id.Caption = "文件id";
            this.file_id.FieldName = "file_id";
            this.file_id.Name = "file_id";
            this.file_id.Width = 87;
            // 
            // file_singer
            // 
            this.file_singer.Caption = "文件后缀";
            this.file_singer.FieldName = "file_singer";
            this.file_singer.Name = "file_singer";
            this.file_singer.Width = 87;
            // 
            // file_hast
            // 
            this.file_hast.Caption = "文件哈希值";
            this.file_hast.FieldName = "file_hast";
            this.file_hast.Name = "file_hast";
            this.file_hast.Width = 87;
            // 
            // file_all_path
            // 
            this.file_all_path.Caption = "文件全路径";
            this.file_all_path.FieldName = "file_all_path";
            this.file_all_path.Name = "file_all_path";
            this.file_all_path.Width = 87;
            // 
            // title
            // 
            this.title.Caption = "标题";
            this.title.FieldName = "title";
            this.title.Name = "title";
            this.title.Visible = true;
            this.title.VisibleIndex = 0;
            this.title.Width = 87;
            // 
            // singer
            // 
            this.singer.Caption = "歌手";
            this.singer.FieldName = "singer";
            this.singer.Name = "singer";
            this.singer.Visible = true;
            this.singer.VisibleIndex = 1;
            this.singer.Width = 87;
            // 
            // file_image
            // 
            this.file_image.Caption = "文件图片";
            this.file_image.FieldName = "file_image";
            this.file_image.Name = "file_image";
            this.file_image.Visible = true;
            this.file_image.VisibleIndex = 2;
            this.file_image.Width = 87;
            // 
            // file_time
            // 
            this.file_time.Caption = "歌曲时间";
            this.file_time.FieldName = "file_time";
            this.file_time.Name = "file_time";
            this.file_time.Visible = true;
            this.file_time.VisibleIndex = 3;
            this.file_time.Width = 87;
            // 
            // is_Enable
            // 
            this.is_Enable.Caption = "是否启用";
            this.is_Enable.FieldName = "is_Enable";
            this.is_Enable.Name = "is_Enable";
            this.is_Enable.Visible = true;
            this.is_Enable.VisibleIndex = 4;
            this.is_Enable.Width = 87;
            // 
            // FrmAdminMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 525);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAdminMusic";
            this.Text = "音乐管理";
            this.Load += new System.EventHandler(this.FrmAdminMusic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar;
        private DevExpress.XtraBars.BarButtonItem btnUploadFile;
        private DevExpress.XtraBars.BarButtonItem btnUpdataMusic;
        private DevExpress.XtraBars.BarButtonItem btnEnable;
        private DevExpress.XtraBars.BarButtonItem btnDisable;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn guid;
        private DevExpress.XtraGrid.Columns.GridColumn title;
        private DevExpress.XtraGrid.Columns.GridColumn singer;
        private DevExpress.XtraGrid.Columns.GridColumn file_size;
        private DevExpress.XtraGrid.Columns.GridColumn file_time;
        private DevExpress.XtraGrid.Columns.GridColumn file_hast;
        private DevExpress.XtraGrid.Columns.GridColumn file_id;
        private DevExpress.XtraGrid.Columns.GridColumn file_all_path;
        private DevExpress.XtraGrid.Columns.GridColumn file_singer;
        private DevExpress.XtraGrid.Columns.GridColumn file_image;
        private DevExpress.XtraGrid.Columns.GridColumn is_Enable;
    }
}