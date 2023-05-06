using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 窗体
{
    public partial class FrmUploadFile : XtraForm
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();

        string Upload_file = "";//上传是否完成信息

        string str_FrmUploadFile = "";//判断窗体是编辑还是新增
        string Updata_guid;//编辑用的guid
        string Music_image_guid;//编辑用的guid
        public FrmUploadFile(string str_FrmUploadFile, string guid)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;//窗体居中

            if (str_FrmUploadFile == "编辑")
            {
                this.str_FrmUploadFile = str_FrmUploadFile;
                this.Updata_guid = guid;

                this.btnUploadFile.Hide();
                this.labUploadfile.Hide();
                #region 显示控件
                labfile_image.Show();
                labfile_time.Show();
                labis_Enable.Show();
                labsinger.Show();
                labtitle.Show();

                btn_file_image.Show();
                txtfile_time.Show();
                txtsinger.Show();
                txttitle.Show();
                pictureBox.Show();
                btnPreview.Show();

                radEnable.Show();
                radNoEnable.Show();

                btnCenCel.Show();
                btnSubmit.Show();
                #endregion

                var dt = SqlHelper.ExecuteQuery($@"select Music_image.guid as Music_image_guid,Music.guid,Music.file_all_path,Music.file_hast,Music.file_id,Music.file_image,Music.file_singer,Music.file_size,Music.file_time,Music.is_Enable,Music.singer,Music.title,Music_image.Music_image from Music join Music_image on Music.guid = Music_image.Music_guid where Music.guid = '{guid}'");
                txtsinger.Text = dt.Rows[0]["singer"].ToString();
                txttitle.Text = dt.Rows[0]["title"].ToString();
                txtfile_time.Text = dt.Rows[0]["file_time"].ToString();
                var Music_image = (dt.Rows[0]["Music_image"]);
                Music_image_guid = dt.Rows[0]["Music_image_guid"].ToString();

                if (Music_image != null && Music_image != DBNull.Value)
                {
                    txt_file_image = (byte[])(Music_image);
                    var photoByte = Convert.FromBase64String(Music_image.ToString());
                    this.pictureBox.Image = Image.FromStream(new MemoryStream(photoByte));
                    return;
                }
                else
                {
                    txt_file_image = null;
                }

                var is_Enable = dt.Rows[0]["is_Enable"].ToString();
                if (is_Enable == "启用")
                {
                    radEnable.Checked = true;
                }
                else
                {
                    radNoEnable.Checked = true;
                }
            }
        }

        public FrmUploadFile()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;//窗体居中
        }

        /// <summary>
        /// 上传音频文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "文本文件(*.Mp3)|*.Mp3";//设置打开文件的类型
            openFileDialog.ShowDialog();  //打开选择文件对话框

            new Task(() =>
            {
                Path_byte();
                this.Upload_file = "上传完了";
            }, TaskCreationOptions.LongRunning).Start();//线程
            timer.Start();
            this.btnUploadFile.Hide();

            #region 显示控件
            labfile_image.Show();
            labfile_time.Show();
            labis_Enable.Show();
            labsinger.Show();
            labtitle.Show();

            btn_file_image.Show();
            txtfile_time.Show();
            txtsinger.Show();
            txttitle.Show();
            pictureBox.Show();
            btnPreview.Show();

            radEnable.Show();
            radNoEnable.Show();

            btnCenCel.Show();
            btnSubmit.Show();
            #endregion
        }

        /// <summary>
        /// 当前文件的路径
        /// </summary>
        string path = "";//当前文件的路径
        string server_path = "C:\\Users\\Administrator\\Desktop\\花木兰控件库\\柠檬的音乐文件夹\\";//指定的服务器存储音乐路径
        string file_hast_name_suffix = "";//哈希值加name
        byte[] path_byte = null;//文件二进制内容

        /// <summary>
        /// 获取二进制的文件信息
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public void Path_byte()
        {
            if (openFileDialog.FileName == "" || openFileDialog.FileName == null)
            {
                this.Close();
                return;
            }

            FileStream fs = System.IO.File.OpenRead(openFileDialog.FileName);//打开现有文件以进行读取
            path = openFileDialog.FileName;

            BinaryReader r = new BinaryReader(fs);
            path_byte = r.ReadBytes((int)fs.Length);

            string file_name = Path.GetFileNameWithoutExtension(path);//文件名称

            txttitle.Text = file_name;//标题

            fs.Dispose();
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCenCel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        byte[] txt_file_image;//图片二进制数据

        /// <summary>
        /// 提交按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var txt_title = txttitle.Text;//标题
            var txt_singer = txtsinger.Text;//歌手
            var txt_file_time = txtfile_time.Text;//音乐时间
            var is_Enble = radEnable.Checked;//是否启用 true启用,false不启用

            if (txt_title == "")
            {
                MessageBox.Show("标题不能为空");
                return;
            }
            if (txt_singer == "")
            {
                MessageBox.Show("歌手不能为空");
                return;
            }

            if (str_FrmUploadFile != "编辑")
            {//新增代码
                if (Upload_file != "上传完了")
                {
                    MessageBox.Show("请耐心等待读取文件");
                    return;
                }

                System.IO.FileInfo fileInfo = null;

                if (System.IO.File.Exists(path))
                {
                    fileInfo = new System.IO.FileInfo(path);

                    string file_name_suffix = Path.GetExtension(path);//文件后缀
                    string file_hast = FileOperation.GetHash(path); ;//文件哈希值

                    file_hast_name_suffix = file_hast + txt_title + file_name_suffix;

                    var dt = SqlHelper.ExecuteQuery($@"select * from Music where file_hast='{file_hast}'");
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        MessageBox.Show("文件已经存在了,文件代号为" + dt.Rows[0]["guid"].ToString());
                        this.Close();
                        return;
                    }
                    else
                    {

                        var Enble = is_Enble == true ? "启用" : "禁用";//判断是否启用

                        var file_image = txt_file_image == null ? null : txt_file_image;

                        string Music_guid = Guid.NewGuid().ToString();
                        string MusicByte_guid = Guid.NewGuid().ToString();
                        string image_guid = Guid.NewGuid().ToString();

                        SqlHelper.ExecuteNonQuery($@"insert into Music (guid,title,singer,file_time,is_Enable,file_size,file_hast,file_all_path,file_singer,file_image)values('{Music_guid}','{txt_title}','{txt_singer}','{txt_file_time}','{Enble}','{fileInfo.Length}','{file_hast}','服务器路径','{file_name_suffix}','{image_guid}') ");

                        Dictionary<string, object> Exe_parameter = new Dictionary<string, object>();
                        Exe_parameter.Add("@guid", MusicByte_guid);
                        Exe_parameter.Add("@Music_guid", Music_guid);
                        Exe_parameter.Add("@Music_byte", path_byte);
                        SqlHelper.ExecuteNonQuery($@"insert into MusicByte (guid,Music_guid,Music_byte)values(@guid,@Music_guid,@Music_byte)", Exe_parameter);

                        if (file_image != null)
                        {
                            Dictionary<string, object> dic_image = new Dictionary<string, object>();
                            dic_image.Add("@guid", image_guid);
                            dic_image.Add("@Music_guid", Music_guid);
                            dic_image.Add("@Music_image", file_image);
                            SqlHelper.ExecuteNonQuery($@"insert into Music_image (guid,Music_guid,Music_image)values(@guid,@Music_guid,@Music_image)", dic_image);
                        }
                        else
                        {
                            //向数据库输入空数据
                        }


                        MessageBox.Show("上传完成");
                        fileInfo = null;//释放fileInfo
                        this.Close();
                        return;
                    }
                }
            }
            else
            {//编辑代码

                var Enble = is_Enble == true ? "启用" : "禁用";//判断是否启用
                var file_image = txt_file_image == null ? null : txt_file_image;

                var dt = SqlHelper.ExecuteQuery($@"select * from Music where guid='{this.Updata_guid}'");
                var oldStr = server_path + dt.Rows[0]["file_hast"] + dt.Rows[0]["title"] + dt.Rows[0]["file_singer"];

                SqlHelper.ExecuteNonQuery($@"update Music set title='{txt_title}',singer ='{txt_singer}',file_time='{txt_file_time}',is_Enable='{Enble}' where guid='{this.Updata_guid}'");

                if (file_image != null)
                {
                    Dictionary<string, object> dic_image = new Dictionary<string, object>();
                    dic_image.Add("@Music_image_byte", file_image);
                    dic_image.Add("@guid", Music_image_guid);
                    SqlHelper.ExecuteNonQuery($@"update Music_image set Music_image = @Music_image_byte where guid = @guid", dic_image);
                }
                else
                {
                    SqlHelper.ExecuteNonQuery($@"update Music_image set Music_image = '{DBNull.Value}' where guid = '{Music_image_guid}'");
                }

                var newStr = server_path + dt.Rows[0]["file_hast"] + txt_title + dt.Rows[0]["file_singer"];
                FileInfo fi = new FileInfo(oldStr);
                fi.MoveTo(Path.Combine(newStr));

                MessageBox.Show("编辑成功");
                this.Close();
                return;
            }
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmUploadFile_Load(object sender, EventArgs e)
        {
            if (str_FrmUploadFile != "编辑")
            {
                #region 隐藏控件
                labfile_image.Hide();
                labfile_time.Hide();
                labis_Enable.Hide();
                labsinger.Hide();
                labtitle.Hide();
                btn_file_image.Hide();
                txtfile_time.Hide();
                txtsinger.Hide();
                txttitle.Hide();
                radEnable.Hide();
                radNoEnable.Hide();
                pictureBox.Hide();
                btnPreview.Hide();

                btnCenCel.Hide();
                btnSubmit.Hide();
                #endregion
            }
        }

        /// <summary>
        /// 计时器,判断上传操作是否完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            ClassResult_time classResult_time = new ClassResult_time();

            if (Upload_file != "上传完了")
            {
                if (labUploadfile.Text == "上传中")
                {
                    labUploadfile.Text = "上传中.";
                }
                else if (labUploadfile.Text == "上传中.")
                {
                    labUploadfile.Text = "上传中..";
                }
                else if (labUploadfile.Text == "上传中..")
                {
                    labUploadfile.Text = "上传中...";
                }
                else if (labUploadfile.Text == "上传中...")
                {
                    labUploadfile.Text = "上传中.";
                }
            }
            else
            {
                labUploadfile.Text = "上传完了";
                var PlayMusic_millisecond = classResult_time.Result_time(openFileDialog.FileName);//播放

                if (Convert.ToString(PlayMusic_millisecond) != "")
                {
                    var int_PlayMusic_millisecond = Convert.ToInt32(Convert.ToString(PlayMusic_millisecond)) / 1000;
                    var minute = (int_PlayMusic_millisecond / 60).ToString();
                    if (minute.Length == 1)
                    {
                        minute = "0" + minute;
                    }

                    var second = (int_PlayMusic_millisecond % 60).ToString();
                    if (second.Length == 1)
                    {
                        second = "0" + second;
                    }

                    txtfile_time.Text = minute + ":" + second;
                }
                timer.Stop();
            }
        }

        /// <summary>
        /// 用户点击了上传图片按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_file_image_Click(object sender, EventArgs e)
        {
            openFileDialog_image.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.* ";//设置打开文件的类型
            openFileDialog_image.ShowDialog();  //打开选择文件对话框

            new Task(() =>
            {
                Path_image_byte();
                this.Upload_file = "上传完了";
            }, TaskCreationOptions.LongRunning).Start();//线程
            timer.Start();
        }

        OpenFileDialog openFileDialog_image = new OpenFileDialog();

        /// <summary>
        /// 获取图片的二进制数据
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public void Path_image_byte()
        {
            if (openFileDialog_image.FileName == "" || openFileDialog_image.FileName == null)
            {
                return;
            }
            FileStream fs = System.IO.File.OpenRead(openFileDialog_image.FileName);//打开现有文件以进行读取

            BinaryReader r = new BinaryReader(fs);
            txt_file_image = r.ReadBytes((int)fs.Length);

            fs.Dispose();
            pictureBox.ImageLocation = openFileDialog_image.FileName;
        }
    }
}
