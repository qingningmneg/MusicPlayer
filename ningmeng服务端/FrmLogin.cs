using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ningmeng服务端
{
    public partial class FrmLogin : XtraForm
    {
        public FrmLogin()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;//让系统不要多管闲事
        }

        Socket socketWatch;
        //开启服务
        private void btnopen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new FrmOpen();
            frm.ShowDialog();
            this.Show();

            try
            {
                #region 创建监听的Socket : new Socket(对应的ip,使用的什么流,使用的协议);
                //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);     //udp协议

                socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);    //tcp协议
                #endregion

                #region 创建IP地址和端口号对象
                //IPAddress ip = IPAddress.Parse("192.168.50.1");
                IPAddress ip = IPAddress.Any;//自动改变IP地址
                IPEndPoint point = new IPEndPoint(ip, 8080);//需要的值,ip和端口号
                #endregion

                #region 负责监听的socket绑定ip和端口
                socketWatch.Bind(point);
                showMsg("开始监听");
                #endregion

                #region 设置一个监听队列,最大同时监听数位100
                socketWatch.Listen(100);
                #endregion

                #region 负责监听的socket 来接受客户端的连接 创建跟客户端通信的socket
                Thread th = new Thread(Listen);
                th.IsBackground = true;
                th.Start(socketWatch);
                #endregion
            }
            catch
            {
                showMsg("出现了异常呢,鹅鹅鹅");
            }
        }


        /// <summary>
        /// 等待客户端连接,并且创建一个负责通讯的Socket
        /// </summary>
        /// <param name="socketWatch"></param>
        void Listen(object o)
        {
            var socketWatchi = o as Socket;

            while (true)
            {
                try
                {
                    Socket socketSend = socketWatchi.Accept();

                    //dictionary存储键和值,键是那个ip和端口,值是那个socketSend
                    dicsocket.Add(socketSend.RemoteEndPoint.ToString(), socketSend);

                    loadData();
                    showMsg(socketSend.RemoteEndPoint.ToString() + "连接成功");//获取别人的IP和端口
                    //开启新线程接受客户端传来的消息
                    Thread th = new Thread(Recive);
                    th.IsBackground = true;
                    th.Start(socketSend);
                }
                catch
                {
                    showMsg("出现了异常呢,鹅鹅鹅");
                }
            }
        }

        Dictionary<string, Socket> dicsocket = new Dictionary<string, Socket>();

        void loadData()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Key");
            foreach (var item in dicsocket)
            {
                var key = item.Key;
                dt.Rows.Add(key);
            }

            gridControl.DataSource = dt;
        }

        /// <summary>
        /// 设置方法,监听服务端传到客户端的值
        /// </summary>
        /// <param name="o"></param>
        void Recive(object o)
        {
            Socket socketSend = o as Socket;
            while (true)
            {
                try
                {
                    //客户端连接成功后,服务端接受客户端发来的消息
                    byte[] buffer = new byte[1024 * 1024 * 2];
                    //实际接受到的有效字节数
                    int r = socketSend.Receive(buffer);
                    if (r == 0)
                    {
                        string stri = (socketSend.RemoteEndPoint).ToString();
                        dicsocket.Remove(stri);
                        loadData();
                        //表示线程结束
                        break;
                    }
                    
                    #region 使用ip查询出来 公共变量dicsocket,Dictionary<string, Socket>类型的值中对应的ip的value值，然后发送给客户端
                    string ip = socketSend.RemoteEndPoint.ToString();
                    #endregion
                    string str = Encoding.UTF8.GetString(buffer, 0, r);
                    string[] sArray = str.Split('_');

                    switch (sArray[0])
                    {
                        case "新增历史信息":
                            {
                                #region 
                                var str_StorePlayback = StorePlayback(sArray[1], sArray[2]);

                                #region 将拿到的值装换成byte[]类型
                                byte[] buffer_is_Enable_Music = Encoding.UTF8.GetBytes(str_StorePlayback);
                                #endregion

                                #region 对转换成byte[]类型的数据的最前面增加一个数字,来当作通讯协议(指双方都遵守的协议)
                                List<byte> list = new List<byte>();
                                list.Add(0);
                                list.AddRange(buffer_is_Enable_Music);
                                byte[] newbuffer = list.ToArray();
                                #endregion

                                if (ip != "")
                                {
                                    #region 向客户发送消息
                                    dicsocket[ip].Send(newbuffer);
                                    #endregion
                                }
                                txtmonitor.Text += "\r\n" + socketSend.RemoteEndPoint.ToString() + "调用了新增历史信息";
                                #endregion
                            }
                            break;
                        case "音乐列表":
                            {
                                #region 
                                var str_StorePlayback = is_Enable_Music();

                                #region 将拿到的值装换成byte[]类型
                                byte[] buffer_is_Enable_Music = str_StorePlayback;
                                #endregion

                                #region 对转换成byte[]类型的数据的最前面增加一个数字,来当作通讯协议(指双方都遵守的协议)
                                List<byte> list = new List<byte>();
                                list.Add(1);
                                list.AddRange(buffer_is_Enable_Music);
                                byte[] newbuffer = list.ToArray();
                                #endregion

                                if (ip != "")
                                {
                                    #region 向客户发送消息
                                    dicsocket[ip].Send(newbuffer);
                                    #endregion
                                }
                                txtmonitor.Text += "\r\n" + socketSend.RemoteEndPoint.ToString() + "调用了音乐列表";
                                #endregion
                            }
                            break;
                        case "FrmFavoriteMusic音乐列表":
                            {
                                #region 
                                var str_StorePlayback = is_Enable_Music();

                                #region 将拿到的值装换成byte[]类型
                                byte[] buffer_is_Enable_Music = str_StorePlayback;
                                #endregion

                                #region 对转换成byte[]类型的数据的最前面增加一个数字,来当作通讯协议(指双方都遵守的协议)
                                List<byte> list = new List<byte>();
                                list.Add(2);
                                list.AddRange(buffer_is_Enable_Music);
                                byte[] newbuffer = list.ToArray();
                                #endregion

                                if (ip != "")
                                {
                                    #region 向客户发送消息
                                    dicsocket[ip].Send(newbuffer);
                                    #endregion
                                }
                                txtmonitor.Text += "\r\n" + socketSend.RemoteEndPoint.ToString() + "调用了FrmFavoriteMusic音乐列表";
                                #endregion
                            }
                            break;
                        case "FrmHistoryPlay音乐列表":
                            {
                                var str_StorePlayback = is_FrmHistoryPlay_Music(sArray[1]);

                                #region 将拿到的值装换成byte[]类型
                                byte[] buffer_is_Enable_Music = str_StorePlayback;
                                #endregion

                                #region 对转换成byte[]类型的数据的最前面增加一个数字,来当作通讯协议(指双方都遵守的协议)
                                List<byte> list = new List<byte>();
                                list.Add(3);
                                list.AddRange(buffer_is_Enable_Music);
                                byte[] newbuffer = list.ToArray();
                                #endregion

                                if (ip != "")
                                {
                                    #region 向客户发送消息
                                    dicsocket[ip].Send(newbuffer);
                                    #endregion
                                }
                                txtmonitor.Text += "\r\n" + socketSend.RemoteEndPoint.ToString() + "调用了FrmHistoryPlay音乐列表";
                            }
                            break;
                        case "FrmHistoryPlay单个删除":
                            {
                                var str_StorePlayback = FrmHistoryPlay_Delete(sArray[1], sArray[2]);

                                #region 将拿到的值装换成byte[]类型
                                byte[] buffer_is_Enable_Music = Encoding.UTF8.GetBytes(str_StorePlayback);
                                #endregion

                                #region 对转换成byte[]类型的数据的最前面增加一个数字,来当作通讯协议(指双方都遵守的协议)
                                List<byte> list = new List<byte>();
                                list.Add(4);
                                list.AddRange(buffer_is_Enable_Music);
                                byte[] newbuffer = list.ToArray();
                                #endregion

                                if (ip != "")
                                {
                                    #region 向客户发送消息
                                    dicsocket[ip].Send(newbuffer);
                                    #endregion
                                }
                                txtmonitor.Text += "\r\n" + socketSend.RemoteEndPoint.ToString() + "调用了FrmHistoryPlay单个删除";
                            }
                            break;
                        case "FrmHistoryPlay全部删除":
                            {
                                var str_StorePlayback = FrmHistoryPlay_Delete_All(sArray[1]);

                                #region 将拿到的值装换成byte[]类型
                                byte[] buffer_is_Enable_Music = Encoding.UTF8.GetBytes(str_StorePlayback);
                                #endregion

                                #region 对转换成byte[]类型的数据的最前面增加一个数字,来当作通讯协议(指双方都遵守的协议)
                                List<byte> list = new List<byte>();
                                list.Add(5);
                                list.AddRange(buffer_is_Enable_Music);
                                byte[] newbuffer = list.ToArray();
                                #endregion

                                #region 使用ip查询出来 公共变量dicsocket,Dictionary<string, Socket>类型的值中对应的ip的value值，然后发送给客户端
                                
                                #endregion

                                if (ip != "")
                                {
                                    #region 向客户发送消息
                                    dicsocket[ip].Send(newbuffer);
                                    #endregion
                                }
                                txtmonitor.Text += "\r\n" + socketSend.RemoteEndPoint.ToString() + "调用了FrmHistoryPlay全部删除";
                            }
                            break;
                        case "FrmMainHome音乐列表":
                            {
                                #region 
                                var str_StorePlayback = is_Enable_Music();

                                #region 将拿到的值装换成byte[]类型
                                byte[] buffer_is_Enable_Music = str_StorePlayback;
                                #endregion

                                #region 对转换成byte[]类型的数据的最前面增加一个数字,来当作通讯协议(指双方都遵守的协议)
                                List<byte> list = new List<byte>();
                                list.Add(6);
                                list.AddRange(buffer_is_Enable_Music);
                                byte[] newbuffer = list.ToArray();
                                #endregion

                                if (ip != "")
                                {
                                    #region 向客户发送消息
                                    dicsocket[ip].Send(newbuffer);
                                    #endregion
                                }
                                txtmonitor.Text += "\r\n" + socketSend.RemoteEndPoint.ToString() + "调用了FrmMainHome音乐列表";
                                #endregion
                            }
                            break;
                        case "确认用户名是否存在":
                            {
                                var str_StorePlayback = FrmLogin_UserInfo(sArray[1]);

                                #region 将拿到的值装换成byte[]类型
                                byte[] buffer_is_Enable_Music = Encoding.UTF8.GetBytes(str_StorePlayback);
                                #endregion

                                #region 对转换成byte[]类型的数据的最前面增加一个数字,来当作通讯协议(指双方都遵守的协议)
                                List<byte> list = new List<byte>();
                                list.Add(7);
                                list.AddRange(buffer_is_Enable_Music);
                                byte[] newbuffer = list.ToArray();
                                #endregion

                                 if (ip != "")
                                {
                                    #region 向客户发送消息
                                    dicsocket[ip].Send(newbuffer);
                                    #endregion
                                }
                                txtmonitor.Text += "\r\n" + ip + "调用了确认用户名是否存在";
                            }
                            break;
                        case "确认是否登录":
                            {
                                var str_StorePlayback = is_Login(sArray[1], sArray[2]);

                                #region 将拿到的值装换成byte[]类型
                                byte[] buffer_is_Enable_Music = str_StorePlayback;
                                #endregion

                                #region 对转换成byte[]类型的数据的最前面增加一个数字,来当作通讯协议(指双方都遵守的协议)
                                List<byte> list = new List<byte>();
                                list.Add(8);
                                list.AddRange(buffer_is_Enable_Music);
                                byte[] newbuffer = list.ToArray();
                                #endregion

                                if (ip != "")
                                {
                                    #region 向客户发送消息
                                    dicsocket[ip].Send(newbuffer);
                                    #endregion
                                }
                                txtmonitor.Text += "\r\n" + socketSend.RemoteEndPoint.ToString() + "调用了音乐列表";
                            }
                            break;
                    }
                }
                catch
                {
                    string stri = (socketSend.RemoteEndPoint).ToString();
                    dicsocket.Remove(stri);
                    break;
                }
            }
        }

        /// <summary>
        /// 存储播放历史
        /// </summary>
        /// <param name="Music_guid">音乐的guid</param>
        /// <param name="user_guid">用户的guid</param>
        public static string StorePlayback(string user_guid, string Music_guid)
        {
            string Result = "成功";
            try
            {
                var dt = SqlHelper.ExecuteQuery($@"select * from UserInfo_Music where UserInfo_guid = '{user_guid}' and Music_guid = '{Music_guid}'");
                if (dt != null && dt.Rows.Count > 0)
                {
                    //修改
                    int max_dt = Convert.ToInt32(SqlHelper.ExecuteQuery($@"select max(ID) as ID from UserInfo_Music").Rows[0]["ID"]);//获取数据中的最大值
                    SqlHelper.ExecuteNonQuery($@"update UserInfo_Music set ID='{max_dt + 1}'where guid='{dt.Rows[0]["guid"]}'");
                }
                else
                {
                    var UserInfo_Music_id = SqlHelper.ExecuteQuery($@"select max(ID) as ID from UserInfo_Music").Rows[0]["ID"];
                    if (UserInfo_Music_id != null && UserInfo_Music_id != DBNull.Value)
                    {
                        int max_dt = Convert.ToInt32(SqlHelper.ExecuteQuery($@"select max(ID) as ID from UserInfo_Music").Rows[0]["ID"]);//获取数据中的最大值
                        string guid = Guid.NewGuid().ToString();
                        //新增
                        SqlHelper.ExecuteNonQuery($@"insert into UserInfo_Music (guid,UserInfo_guid,Music_guid,ID)values('{guid}','{user_guid}','{Music_guid}','{max_dt + 1}')");
                    }
                    else
                    {
                        string guid = Guid.NewGuid().ToString();
                        SqlHelper.ExecuteNonQuery($@"insert into UserInfo_Music (guid,UserInfo_guid,Music_guid,ID)values('{guid}','{user_guid}','{Music_guid}','{0}')");
                    }
                }
            }
            catch
            {
                Result = "失败了";
            }
            return Result;
        }

        /// <summary>
        /// 查询FrmFavoriteMusic音乐列表
        /// </summary>
        /// <returns></returns>
        public static byte[] is_Enable_Music()
        {
            byte[] Result = null;

            Result = SqlHelper.SerializeDataTableToBytes(SqlHelper.ExecuteQuery($@"select * from Music where is_Enable = '启用'"), true);

            return Result;
        }

        /// <summary>
        /// 查询历史记录
        /// </summary>
        /// <param name="user_guid"></param>
        /// <returns></returns>
        public static Byte[] is_FrmHistoryPlay_Music(string user_guid)
        {
            byte[] Result = null;

            Result = SqlHelper.SerializeDataTableToBytes(SqlHelper.ExecuteQuery($@"select UserInfo_Music.guid as UserInfo_Music_guid, Music.guid,Music.file_all_path,Music.file_hast,Music.file_id,Music.file_image,Music.file_singer,Music.file_size,Music.file_time,Music.is_Enable,Music.singer,Music.title  from Music join UserInfo_Music on UserInfo_Music.Music_guid = Music.guid where UserInfo_Music.UserInfo_guid = '{user_guid}'"), true);

            return Result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="user_guid"></param>
        /// <returns></returns>
        public static string FrmHistoryPlay_Delete(string user_guid, string guid)
        {
            string Result = "";

            SqlHelper.ExecuteNonQuery($@"delete from UserInfo_Music where UserInfo_guid = '{user_guid}' and Music_guid = '{guid}'");

            Result = "删除成功";
            return Result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="user_guid"></param>
        /// <returns></returns>
        public static string FrmHistoryPlay_Delete_All(string user_guid)
        {
            string Result = "";

            SqlHelper.ExecuteNonQuery($@"delete from UserInfo_Music where UserInfo_guid = '{user_guid}'");

            Result = "删除成功";
            return Result;
        }

        /// <summary>
        /// 确定用户名是否存在
        /// </summary>
        /// <param name="user_guid"></param>
        /// <returns></returns>
        public static string FrmLogin_UserInfo(string user_no)
        {
            string Result = "用户名不存在";

            var dt = SqlHelper.ExecuteQuery($"select * from UserInfo where user_no = '{user_no}'");

            if (dt != null && dt.Rows.Count > 0)
            {
                Result = "存在";
            }
            return Result;
        }

        /// <summary>
        /// 查看登录是否可以成功
        /// </summary>
        /// <returns></returns>
        public static byte[] is_Login(string user_no, string user_pwd)
        {
            byte[] Result = null;

            Result = SqlHelper.SerializeDataTableToBytes(SqlHelper.ExecuteQuery($@"select * from UserInfo where user_no ='{user_no}'and user_pwd = '{user_pwd}'"), true);

            return Result;
        }


        /// <summary>
        /// 将值显示在txtmonitor上
        /// </summary>
        /// <param name="str"></param>
        void showMsg(string str)
        {
            txtmonitor.AppendText(str + "\r\n");
        }

        private void btnSendamessage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            #region 拿到想要对客户端发送的数据
            string str = txtSend.Text;
            #endregion

            #region 将拿到的值装换成byte[]类型
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            #endregion

            #region 对转换成byte[]类型的数据的最前面增加一个数字,来当作通讯协议(指双方都遵守的协议)
            List<byte> list = new List<byte>();
            list.Add(0);
            list.AddRange(buffer);
            byte[] newbuffer = list.ToArray();
            #endregion

            #region 使用ip查询出来 公共变量dicsocket,Dictionary<string, Socket>类型的值中对应的ip的value值，然后发送给客户端
            string ip = gridView.GetFocusedRowCellValue("Key").ToString();
            #endregion

            if (ip != "")
            {
                #region 向客户发送消息
                dicsocket[ip].Send(newbuffer);
                #endregion
            }
            // socketWatch.Send(buffer);
        }

        private void btnfile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string aa = gridView.GetFocusedRowCellValue("Key").ToString();

            var frm = new Frmsendout(socketWatch, dicsocket, aa);
            frm.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// 震动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            byte[] buffer = new byte[1];

            buffer[0] = 2;
            string ip = gridView.GetFocusedRowCellValue("Key").ToString();

            dicsocket[ip].Send((byte[])buffer);
        }


    }
}