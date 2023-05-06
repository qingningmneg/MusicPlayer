using DevExpress.XtraGrid;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 窗体
{
    public partial class FrmFavoriteMusic : Form
    {
        string Musice_Path = "";
        FrmMainFroms frmMainFroms = new FrmMainFroms();
        /// <summary>
        /// 我喜欢的音乐
        /// </summary>
        public FrmFavoriteMusic(FrmMainFroms frmMainFroms)
        {
            InitializeComponent();
            this.frmMainFroms = frmMainFroms;
        }

        /// <summary>
        /// 初始化页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmFavoriteMusic_Load(object sender, EventArgs e)
        {
            is_Enable_Music();
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        public void LoadData(DataTable dataTable)
        {
            gridControl.DataSource = null;

            var path = AppDomain.CurrentDomain.BaseDirectory + "Read_MusicPath.json";//读文件路径  
            if (System.IO.File.Exists(path) == true)
            {
                dynamic json = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(path));
                Musice_Path = json.Musice_Path ?? "";
            }

            Program.FrmFavoriteMusic_dt = dataTable;

            gridControl.DataSource = Program.FrmFavoriteMusic_dt;

            MusicImage.Image = Image.FromFile("C:\\Users\\Administrator\\Pictures\\Camera Roll\\屏幕截图_20221028_121659.png");

            labMusicCount.Text = "歌曲数量: " + Program.FrmFavoriteMusic_dt.Rows.Count.ToString();

            gridView.TopRowIndex = topIndex1;//刷新时gridView的位置不会发生改变
        }

        int music_xuanzhong = 0;
        /// <summary>
        /// 刷新列表
        /// </summary>
        public void LoadData(string File_Hash)
        {
            is_Enable_Music();

            if (Program.FrmHistoryPlay_dt.Columns.Contains("file_hast"))
            {
                gridControl.DataSource = null;

                var path = AppDomain.CurrentDomain.BaseDirectory + "Read_MusicPath.json";//读文件路径  
                if (System.IO.File.Exists(path) == true)
                {
                    dynamic json = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(path));
                    Musice_Path = json.Musice_Path ?? "";
                }

                if (Program.FrmFavoriteMusic_dt != null)
                {
                    if (!Program.FrmFavoriteMusic_dt.Columns.Contains("ID"))
                    {
                        Program.FrmFavoriteMusic_dt.Columns.Add("ID");
                        for (int i = 0; i < Program.FrmFavoriteMusic_dt.Rows.Count; i++)
                        {
                            Program.FrmFavoriteMusic_dt.Rows[i]["ID"] = i;
                        }
                    }
                }

                gridControl.DataSource = Program.FrmFavoriteMusic_dt;

                MusicImage.Image = Image.FromFile("C:\\Users\\Administrator\\Pictures\\Camera Roll\\屏幕截图_20221028_121659.png");

                labMusicCount.Text = "歌曲数量: " + Program.FrmFavoriteMusic_dt.Rows.Count.ToString();

                gridView.TopRowIndex = topIndex1;//刷新时gridView的位置不会发生改变

                if (File_Hash != "")
                {
                    DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                    //添加主键，必须是已经在DataTable里有的列名
                    PrimaryKeyColumns[0] = Program.FrmFavoriteMusic_dt.Columns["file_hast"];
                    //配置主键
                    Program.FrmFavoriteMusic_dt.PrimaryKey = PrimaryKeyColumns;

                    if (Program.FrmFavoriteMusic_dt.Columns.Contains("file_hast"))
                    {
                        var Row_dt = Program.FrmFavoriteMusic_dt.Select($@"file_hast = '{File_Hash}'");
                        if (Row_dt.Count() != 0)
                        {
                            music_xuanzhong = Convert.ToInt32(Row_dt[0]["ID"]);

                            gridView_RowStyle(null, null);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 双击歌曲时播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControl_DoubleClick(object sender, EventArgs e)
        {
            var Row = gridView.GetFocusedDataRow();
            if (Row != null)
            {
                var Paht_Hash = Convert.ToString(Row["file_hast"]);
                this.frmMainFroms.bofang(Paht_Hash, Program.FrmFavoriteMusic_dt);
            }
        }

        /// <summary>
        /// gridView2显示行数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();//显示行号
            }
            else
            {
                e.Info.DisplayText = gridView.RowCount.ToString();//显示总数
            }
        }

        /// <summary>
        /// 播放全部按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlayAll_Click(object sender, EventArgs e)
        {
            if (Program.FrmFavoriteMusic_dt != null && Program.FrmFavoriteMusic_dt.Rows.Count > 0)
            {
                var Paht_Hash = Program.FrmFavoriteMusic_dt.Rows[0]["file_hast"].ToString();
                this.frmMainFroms.bofang(Paht_Hash, Program.FrmFavoriteMusic_dt);
            }
        }

        int topIndex1 = 0;

        /// <summary>
        /// 记录当前滚动条位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_TopRowChanged(object sender, EventArgs e)
        {
            topIndex1 = gridView.TopRowIndex;
        }

        private void gridView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e == null)
            {
                return;
            }
            int hand = e.RowHandle;
            if (hand < 0) return;

            if (hand == music_xuanzhong)
            {
                e.Appearance.ForeColor = Color.FromArgb(240, 128, 128);//改变字体颜色
            }
        }

        /// <summary>
        /// 搜索启用的音乐
        /// </summary>
        /// <returns></returns>
        public void is_Enable_Music()
        {
            try
            {
                string str = "FrmFavoriteMusic音乐列表";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
                PlayMusics.stream.Write(buffer, 0, buffer.Length);
            }
            catch
            {
            }
        }
    }
}
