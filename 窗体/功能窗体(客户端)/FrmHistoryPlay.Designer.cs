namespace 窗体
{
    partial class FrmHistoryPlay
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.guid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.file_size = new DevExpress.XtraGrid.Columns.GridColumn();
            this.file_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.file_singer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.file_hast = new DevExpress.XtraGrid.Columns.GridColumn();
            this.file_all_path = new DevExpress.XtraGrid.Columns.GridColumn();
            this.is_Enable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.file_image = new DevExpress.XtraGrid.Columns.GridColumn();
            this.title = new DevExpress.XtraGrid.Columns.GridColumn();
            this.singer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.file_time = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnPlayAll = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeleteAll = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.01695F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(973, 569);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl.Location = new System.Drawing.Point(4, 4);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl.Size = new System.Drawing.Size(965, 561);
            this.gridControl.TabIndex = 6;
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
            this.is_Enable,
            this.file_image,
            this.title,
            this.singer,
            this.file_time});
            this.gridView.DetailHeight = 408;
            this.gridView.GridControl = this.gridControl;
            this.gridView.GroupPanelText = "历史播放";
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView_RowStyle);
            this.gridView.TopRowChanged += new System.EventHandler(this.gridView_TopRowChanged);
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
            // is_Enable
            // 
            this.is_Enable.Caption = "是否启用";
            this.is_Enable.FieldName = "is_Enable";
            this.is_Enable.Name = "is_Enable";
            this.is_Enable.Width = 87;
            // 
            // file_image
            // 
            this.file_image.Caption = "文件图片";
            this.file_image.FieldName = "file_image";
            this.file_image.Name = "file_image";
            this.file_image.Width = 87;
            // 
            // title
            // 
            this.title.Caption = "标题";
            this.title.FieldName = "title";
            this.title.Name = "title";
            this.title.Visible = true;
            this.title.VisibleIndex = 0;
            this.title.Width = 243;
            // 
            // singer
            // 
            this.singer.Caption = "歌手";
            this.singer.FieldName = "singer";
            this.singer.Name = "singer";
            this.singer.Visible = true;
            this.singer.VisibleIndex = 1;
            this.singer.Width = 243;
            // 
            // file_time
            // 
            this.file_time.Caption = "歌曲时间";
            this.file_time.FieldName = "file_time";
            this.file_time.Name = "file_time";
            this.file_time.Visible = true;
            this.file_time.VisibleIndex = 2;
            this.file_time.Width = 385;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnPlayAll,
            this.btnDelete,
            this.btnDeleteAll});
            this.barManager.MainMenu = this.bar2;
            this.barManager.MaxItemId = 3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPlayAll),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDeleteAll)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnPlayAll
            // 
            this.btnPlayAll.Caption = "播放全部";
            this.btnPlayAll.Id = 0;
            this.btnPlayAll.Name = "btnPlayAll";
            this.btnPlayAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPlayAll_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "删除当前选中行";
            this.btnDelete.Id = 1;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Caption = "删除全部";
            this.btnDeleteAll.Id = 2;
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeleteAll_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(973, 21);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 590);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(973, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 21);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 569);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(973, 21);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 569);
            // 
            // FrmHistoryPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 590);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmHistoryPlay";
            this.Text = "最近播放";
            this.Load += new System.EventHandler(this.FrmHistoryPlay_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn guid;
        private DevExpress.XtraGrid.Columns.GridColumn file_size;
        private DevExpress.XtraGrid.Columns.GridColumn file_id;
        private DevExpress.XtraGrid.Columns.GridColumn file_singer;
        private DevExpress.XtraGrid.Columns.GridColumn file_hast;
        private DevExpress.XtraGrid.Columns.GridColumn file_all_path;
        private DevExpress.XtraGrid.Columns.GridColumn is_Enable;
        private DevExpress.XtraGrid.Columns.GridColumn file_image;
        private DevExpress.XtraGrid.Columns.GridColumn title;
        private DevExpress.XtraGrid.Columns.GridColumn singer;
        private DevExpress.XtraGrid.Columns.GridColumn file_time;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnPlayAll;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnDeleteAll;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}