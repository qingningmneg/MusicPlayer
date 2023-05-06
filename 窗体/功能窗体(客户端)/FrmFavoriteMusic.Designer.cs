namespace 窗体
{
    /// <summary>
    /// 我喜欢的音乐
    /// </summary>
    partial class FrmFavoriteMusic
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MusicImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFavoriteMusic = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPlayAll = new WinformControlLibraryExtension.ButtonExt();
            this.labMusicCount = new DevExpress.XtraEditors.LabelControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MusicImage)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 135;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.125F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.875F));
            this.tableLayoutPanel.Controls.Add(this.MusicImage, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(800, 135);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // MusicImage
            // 
            this.MusicImage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MusicImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MusicImage.Location = new System.Drawing.Point(3, 3);
            this.MusicImage.Name = "MusicImage";
            this.MusicImage.Size = new System.Drawing.Size(139, 129);
            this.MusicImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MusicImage.TabIndex = 0;
            this.MusicImage.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblFavoriteMusic, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(148, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.25581F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.74419F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(649, 129);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblFavoriteMusic
            // 
            this.lblFavoriteMusic.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFavoriteMusic.Appearance.Options.UseFont = true;
            this.lblFavoriteMusic.Location = new System.Drawing.Point(3, 3);
            this.lblFavoriteMusic.Name = "lblFavoriteMusic";
            this.lblFavoriteMusic.Size = new System.Drawing.Size(126, 22);
            this.lblFavoriteMusic.TabIndex = 0;
            this.lblFavoriteMusic.Text = "我喜欢的音乐";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnPlayAll, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labMusicCount, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 32);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.31915F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.68085F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(643, 94);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnPlayAll
            // 
            this.btnPlayAll.Animation.Options.AllTransformTime = 250D;
            this.btnPlayAll.Animation.Options.Data = null;
            this.btnPlayAll.BackColor = System.Drawing.Color.OliveDrab;
            this.btnPlayAll.FlatAppearance.BorderSize = 0;
            this.btnPlayAll.Location = new System.Drawing.Point(3, 3);
            this.btnPlayAll.Name = "btnPlayAll";
            this.btnPlayAll.Size = new System.Drawing.Size(155, 34);
            this.btnPlayAll.TabIndex = 2;
            this.btnPlayAll.Text = "播放全部";
            this.btnPlayAll.UseVisualStyleBackColor = true;
            this.btnPlayAll.Click += new System.EventHandler(this.btnPlayAll_Click);
            // 
            // labMusicCount
            // 
            this.labMusicCount.Appearance.Font = new System.Drawing.Font("Yu Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMusicCount.Appearance.Options.UseFont = true;
            this.labMusicCount.Location = new System.Drawing.Point(3, 55);
            this.labMusicCount.Name = "labMusicCount";
            this.labMusicCount.Size = new System.Drawing.Size(51, 16);
            this.labMusicCount.TabIndex = 3;
            this.labMusicCount.Text = "歌曲数量:";
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(800, 311);
            this.gridControl.TabIndex = 5;
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
            this.gridView.GroupPanelText = "我喜欢的音乐";
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView.OptionsView.EnableAppearanceOddRow = true;
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
            // FrmFavoriteMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmFavoriteMusic";
            this.Text = "我喜欢的音乐";
            this.Load += new System.EventHandler(this.FrmFavoriteMusic_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MusicImage)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox MusicImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl lblFavoriteMusic;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private WinformControlLibraryExtension.ButtonExt btnPlayAll;
        private DevExpress.XtraEditors.LabelControl labMusicCount;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn guid;
        private DevExpress.XtraGrid.Columns.GridColumn file_size;
        private DevExpress.XtraGrid.Columns.GridColumn file_id;
        private DevExpress.XtraGrid.Columns.GridColumn file_singer;
        private DevExpress.XtraGrid.Columns.GridColumn file_hast;
        private DevExpress.XtraGrid.Columns.GridColumn file_all_path;
        private DevExpress.XtraGrid.Columns.GridColumn title;
        private DevExpress.XtraGrid.Columns.GridColumn singer;
        private DevExpress.XtraGrid.Columns.GridColumn file_image;
        private DevExpress.XtraGrid.Columns.GridColumn file_time;
        private DevExpress.XtraGrid.Columns.GridColumn is_Enable;
    }
}