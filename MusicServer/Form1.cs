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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicServer
{
    public partial class FrmMusicServer : XtraForm
    {
        public FrmMusicServer()
        {
            InitializeComponent();
        }

        Socket socketWatch;

        private void FrmMusicServer_Load(object sender, EventArgs e)
        {
            #region 创建监听的Socket : new Socket(对应的ip,使用的什么流,使用的协议);
            //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);     //udp协议

            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);    //tcp协议
            #endregion

            #region 创建IP地址和端口号对象
            //IPAddress ip = IPAddress.Parse("192.168.50.1");
            IPAddress ip = IPAddress.Any;//自动改变IP地址
            IPEndPoint point = new IPEndPoint(ip, 50000);//需要的值,ip和端口号
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

        // 检查一个Socket是否可连接
        private bool IsSocketConnected(Socket client)
        {
            bool blockingState = client.Blocking;
            try
            {
                byte[] tmp = new byte[1];
                client.Blocking = false;
                client.Send(tmp, 0, 0);
                return false;
            }
            catch (SocketException e)
            {
                // 产生 10035 == WSAEWOULDBLOCK 错误，说明被阻止了，但是还是连接的
                if (e.NativeErrorCode.Equals(10035))
                    return false;
                else
                    return true;
            }
            finally
            {
                client.Blocking = blockingState;    // 恢复状态
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
                        //表示线程结束
                        break;
                    }
                    string str = Encoding.UTF8.GetString(buffer, 0, r);
                    showMsg(socketSend.RemoteEndPoint + ":" + str);//socketSend.RemoteEndPoint等于IP加端口
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
        /// 将值显示在txtmonitor上
        /// </summary>
        /// <param name="str"></param>
        void showMsg(string str)
        {
            txtmonitor.AppendText(str + "\r\n");
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            #region 使用ip查询出来 公共变量dicsocket,Dictionary<string, Socket>类型的值中对应的ip的value值，然后发送给客户端
            string ip = gridView.GetFocusedRowCellValue("Key").ToString();
            #endregion

            try
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

                if (ip != "")
                {
                    #region 向客户发送消息
                    dicsocket[ip].Send(newbuffer);
                    #endregion
                }
                // socketWatch.Send(buffer);
            }
            catch
            {
                string stri = (ip).ToString();
                dicsocket.Remove(stri);
            }
        }

        /// <summary>
        /// 获取文件架
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 关闭窗体时释放资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearMemory();
        }

        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion

        private void btninspect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = IsSocketConnected(socketWatch);
            if (a == true)
            {
                MessageBox.Show("这个地方可以连接呢");
                return;
            }
            else
            {
                MessageBox.Show("无法正常连接,可能服务端出现状况了把");
            }
        }
    }
}
