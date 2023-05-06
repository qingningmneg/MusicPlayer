namespace 窗体
{
    partial class FrmMainHome
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
            this.panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.imageWhirligigExt = new WinformControlLibraryExtension.ImageWhirligigExt();
            this.panel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.panel1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(607, 605);
            this.panel.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.gridControl);
            this.panel1.Controls.Add(this.imageWhirligigExt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 605);
            this.panel1.TabIndex = 0;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl.Location = new System.Drawing.Point(0, 217);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(607, 388);
            this.gridControl.TabIndex = 7;
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
            this.gridView.GroupPanelText = "推荐音乐";
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
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
            // file_time
            // 
            this.file_time.Caption = "歌曲时间";
            this.file_time.FieldName = "file_time";
            this.file_time.Name = "file_time";
            this.file_time.Visible = true;
            this.file_time.VisibleIndex = 2;
            this.file_time.Width = 87;
            // 
            // imageWhirligigExt
            // 
            this.imageWhirligigExt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.imageWhirligigExt.Dock = System.Windows.Forms.DockStyle.Top;
            this.imageWhirligigExt.Location = new System.Drawing.Point(0, 0);
            this.imageWhirligigExt.Name = "imageWhirligigExt";
            this.imageWhirligigExt.Size = new System.Drawing.Size(607, 217);
            this.imageWhirligigExt.TabIndex = 0;
            // 
            // FrmMainHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(607, 605);
            this.Controls.Add(this.panel);
            this.Name = "FrmMainHome";
            this.Text = "音乐推荐";
            this.Load += new System.EventHandler(this.FrmMainHome_Load);
            this.panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panel1;
        private WinformControlLibraryExtension.ImageWhirligigExt imageWhirligigExt;
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
    }
}