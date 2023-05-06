using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 窗体
{
    public partial class FrmHistoryPlay : XtraForm
    {
        FrmMainFroms frmMainFroms = new FrmMainFroms();

        public FrmHistoryPlay(FrmMainFroms frmMainFroms)
        {
            InitializeComponent();

            this.frmMainFroms = frmMainFroms;

            gridView.OptionsSelection.MultiSelect = true;
        }

        /// <summary>
        /// 进入窗体事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmHistoryPlay_Load(object sender, EventArgs e)
        {
            is_Enable_Music();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        public void LoadData(DataTable dataTable)
        {
            Program.FrmHistoryPlay_dt = dataTable;

            gridControl.DataSource = Program.FrmHistoryPlay_dt;

            var dt_Count = Program.FrmHistoryPlay_dt.Rows.Count;
            gridView.GroupPanelText = "歌曲数量:" + dt_Count.ToString();

            gridView.TopRowIndex = topIndex1;//刷新时gridView的位置不会发生改变
        }

        int music_xuanzhong = 0;//当前音乐播放行数

        /// <summary>
        /// 刷新
        /// </summary>
        public void LoadData(string File_Hash)
        {
            is_Enable_Music();

            if (Program.FrmHistoryPlay_dt.Columns.Contains("file_hast"))
            {
                if (Program.FrmHistoryPlay_dt == null)
                {
                    return;
                }
                gridControl.DataSource = null;
                if (Program.FrmHistoryPlay_dt != null)
                {
                    gridControl.DataSource = Program.FrmHistoryPlay_dt;
                    if (!Program.FrmHistoryPlay_dt.Columns.Contains("ID"))
                    {
                        Program.FrmHistoryPlay_dt.Columns.Add("ID");
                        Program.FrmHistoryPlay_dt.Columns.Add("FileOperation");
                        for (int i = 0; i < Program.FrmHistoryPlay_dt.Rows.Count; i++)
                        {
                            Program.FrmHistoryPlay_dt.Rows[i]["ID"] = i;
                        }
                    }
                }
                var dt_Count = Program.FrmHistoryPlay_dt.Rows.Count;
                gridView.GroupPanelText = "歌曲数量:" + dt_Count.ToString();

                gridView.TopRowIndex = topIndex1;//刷新时gridView的位置不会发生改变

                if (File_Hash != "")
                {
                    DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                    //添加主键，必须是已经在DataTable里有的列名
                    PrimaryKeyColumns[0] = Program.FrmHistoryPlay_dt.Columns["file_hast"];
                    //配置主键
                    Program.FrmHistoryPlay_dt.PrimaryKey = PrimaryKeyColumns;

                    var Row_dt = Program.FrmHistoryPlay_dt.Select($@"file_hast = '{File_Hash}'");
                    if (Row_dt.Count() != 0)
                    {
                        music_xuanzhong = Convert.ToInt32(Row_dt[0]["ID"]);

                        gridView_RowStyle(null, null);
                    }
                }
            }
        }

        /// <summary>
        /// 播放音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControl_DoubleClick(object sender, EventArgs e)
        {
            var Row = gridView.GetFocusedDataRow();
            if (Row != null)
            {
                var Paht_Hash = Convert.ToString(Row["file_hast"]);
                this.frmMainFroms.bofang(Paht_Hash, Program.FrmHistoryPlay_dt);
            }
        }

        /// <summary>
        /// 播放全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlayAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Paht_Hash = Program.FrmHistoryPlay_dt.Rows[0]["file_hast"].ToString();
            this.frmMainFroms.bofang(Paht_Hash, Program.FrmHistoryPlay_dt);
        }

        /// <summary>
        /// 删除当前选中行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Row = gridView.GetFocusedDataRow();
            if (Row != null)
            {
                if (MessageBox.Show("确认删除？", "删除后数据将无法恢复哦", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    var guid = Convert.ToString(Row["guid"]);
                    Delete_Music(guid);
                    is_Enable_Music();
                }
            }

        }

        /// <summary>
        /// 删除全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Row = gridView.GetFocusedDataRow();
            if (Row != null)
            {
                if (MessageBox.Show("确认删除？", "删除后数据将无法恢复哦", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    var guid = Convert.ToString(Row["guid"]);
                    this.Delete_Music_All();
                    is_Enable_Music();
                }
            }
        }

        int topIndex1 = 0;//滚动条位置

        /// <summary>
        /// 记录当前滚动条位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_TopRowChanged(object sender, EventArgs e)
        {
            topIndex1 = gridView.TopRowIndex;
        }

        /// <summary>
        /// 改变字体颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 刷新最近播放页面
        /// </summary>
        /// <returns></returns>
        public void is_Enable_Music()
        {
            try
            {
                string str = $"FrmHistoryPlay音乐列表_{Program.user_guid}";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
                PlayMusics.stream.Write(buffer, 0, buffer.Length);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 搜索启用的音乐
        /// </summary>
        /// <returns></returns>
        public void Delete_Music(string guid)
        {
            try
            {
                string str = $"FrmHistoryPlay单个删除_{Program.user_guid}_{guid}";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
                PlayMusics.stream.Write(buffer, 0, buffer.Length);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 搜索启用的音乐
        /// </summary>
        /// <returns></returns>
        public void Delete_Music_All()
        {
            try
            {
                string str = $"FrmHistoryPlay全部删除_{Program.user_guid}";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
                PlayMusics.stream.Write(buffer, 0, buffer.Length);
            }
            catch
            {
            }
        }
    }
}
