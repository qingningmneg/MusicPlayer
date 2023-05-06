using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.DataFormats;

namespace 窗体
{
    public partial class FrmLogin : FormBase
    {
        #region Field
        //窗体圆角矩形半径
        private int _radius = 5;

        //是否允许窗体改变大小
        private bool _canResize = true;

        private Image _fringe = Image.FromFile(@"Res\fringe_bkg.png");

        //窗体背景
        private Image _formBkg = Image.FromFile(@"Res\FormBkg\previews.jpg");
        private Label lblUserNo;
        private Label lblUserPwd;
        private Button btnLogin;
        private Button btnRegister;
        private CheckBox cmdautomatic;
        private CheckBox cmdremember;
        private LinkLabel lblPWd;
        private DevExpress.XtraEditors.TextEdit txtUserNo;
        private DevExpress.XtraEditors.TextEdit txtUserPwd;

        //系统按钮管理器
        private SystemButtonManager _systemButtonManager;
        #endregion

        #region Constructor

        public FrmLogin()
        {

            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;
            FormExIni();
            _systemButtonManager = new SystemButtonManager(this);

            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            this.Location = new Point(x, y);
        }

        #endregion

        #region Properties

        [DefaultValue(typeof(byte), "5")]
        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                if (_radius != value)
                {
                    _radius = value;
                    this.Invalidate();
                }
            }
        }

        public bool CanResize
        {
            get
            {
                return _canResize;
            }
            set
            {
                if (_canResize != value)
                {
                    _canResize = value;
                }
            }
        }

        public override Image BackgroundImage
        {
            get
            {
                return _formBkg;
            }
            set
            {
                if (_formBkg != value)
                {
                    _formBkg = value;
                    Invalidate();
                }
            }
        }

        internal Rectangle IconRect
        {
            get
            {
                if (base.ShowIcon && base.Icon != null)
                {
                    return new Rectangle(8, 6, SystemInformation.SmallIconSize.Width, SystemInformation.SmallIconSize.Width);
                }
                return Rectangle.Empty;
            }
        }

        internal Rectangle TextRect
        {
            get
            {
                if (base.Text.Length != 0)
                {
                    return new Rectangle(IconRect.Right + 2, 4, Width - (8 + IconRect.Width + 2), Font.Height);
                }
                return Rectangle.Empty;
            }
        }

        internal SystemButtonManager SystemButtonManager
        {
            get
            {
                if (_systemButtonManager == null)
                {
                    _systemButtonManager = new SystemButtonManager(this);
                }
                return _systemButtonManager;
            }
        }

        #endregion

        #region Overrides

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (!DesignMode)
                {
                    if (MaximizeBox) { cp.Style |= (int)WindowStyle.WS_MAXIMIZEBOX; }
                    if (MinimizeBox) { cp.Style |= (int)WindowStyle.WS_MINIMIZEBOX; }
                    //cp.ExStyle |= (int)WindowStyle.WS_CLIPCHILDREN;  //防止因窗体控件太多出现闪烁
                    cp.ClassStyle |= (int)ClassStyle.CS_DropSHADOW;  //实现窗体边框阴影效果
                }
                return cp;
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            RenderHelper.SetFormRoundRectRgn(this, Radius);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            RenderHelper.SetFormRoundRectRgn(this, Radius);
            UpdateSystemButtonRect();
            UpdateMaxButton();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case Win32.WM_ERASEBKGND:
                    m.Result = IntPtr.Zero;
                    break;
                case Win32.WM_NCHITTEST:
                    WmNcHitTest(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            SystemButtonManager.ProcessMouseOperate(e.Location, MouseOperate.Move);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                SystemButtonManager.ProcessMouseOperate(e.Location, MouseOperate.Down);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                SystemButtonManager.ProcessMouseOperate(e.Location, MouseOperate.Up);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            SystemButtonManager.ProcessMouseOperate(Point.Empty, MouseOperate.Leave);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //draw BackgroundImage
            e.Graphics.DrawImage(_formBkg, ClientRectangle, new Rectangle(0, 0, _formBkg.Width, _formBkg.Height), GraphicsUnit.Pixel);

            //draw form main part
            RenderHelper.DrawFromAlphaMainPart(this, e.Graphics);

            //draw system buttons
            SystemButtonManager.DrawSystemButtons(e.Graphics);

            //draw fringe
            RenderHelper.DrawFormFringe(this, e.Graphics, _fringe, Radius);

            //draw icon
            if (Icon != null && ShowIcon)
            {
                e.Graphics.DrawIcon(Icon, IconRect);
            }

            //draw text
            if (Text.Length != 0)
            {
                TextRenderer.DrawText(
                    e.Graphics,
                    Text, Font,
                    TextRect,
                    Color.White,
                    TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (_systemButtonManager != null)
                {
                    _systemButtonManager.Dispose();
                    _systemButtonManager = null;
                    _formBkg.Dispose();
                    _formBkg = null;
                    _fringe.Dispose();
                    _fringe = null;
                }
            }
        }
        #endregion

        #region Private Methods
        private void InitializeComponent()
        {
            this.txtUserPwd = new DevExpress.XtraEditors.TextEdit();
            this.txtUserNo = new DevExpress.XtraEditors.TextEdit();
            this.lblPWd = new System.Windows.Forms.LinkLabel();
            this.cmdremember = new System.Windows.Forms.CheckBox();
            this.cmdautomatic = new System.Windows.Forms.CheckBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblUserPwd = new System.Windows.Forms.Label();
            this.lblUserNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.EditValue = "";
            this.txtUserPwd.Location = new System.Drawing.Point(192, 206);
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.Size = new System.Drawing.Size(175, 20);
            this.txtUserPwd.TabIndex = 13;
            // 
            // txtUserNo
            // 
            this.txtUserNo.EditValue = "";
            this.txtUserNo.Location = new System.Drawing.Point(192, 129);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Size = new System.Drawing.Size(175, 20);
            this.txtUserNo.TabIndex = 12;
            // 
            // lblPWd
            // 
            this.lblPWd.AutoSize = true;
            this.lblPWd.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPWd.Font = new System.Drawing.Font("微软雅黑 Light", 8.25F);
            this.lblPWd.ForeColor = System.Drawing.Color.Black;
            this.lblPWd.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPWd.Location = new System.Drawing.Point(394, 264);
            this.lblPWd.Name = "lblPWd";
            this.lblPWd.Size = new System.Drawing.Size(51, 16);
            this.lblPWd.TabIndex = 10;
            this.lblPWd.TabStop = true;
            this.lblPWd.Text = "忘记密码";
            // 
            // cmdremember
            // 
            this.cmdremember.AutoSize = true;
            this.cmdremember.Font = new System.Drawing.Font("微软雅黑 Light", 9.75F);
            this.cmdremember.Location = new System.Drawing.Point(262, 257);
            this.cmdremember.Name = "cmdremember";
            this.cmdremember.Size = new System.Drawing.Size(80, 23);
            this.cmdremember.TabIndex = 7;
            this.cmdremember.Text = "记住密码";
            this.cmdremember.UseVisualStyleBackColor = true;
            // 
            // cmdautomatic
            // 
            this.cmdautomatic.AutoSize = true;
            this.cmdautomatic.Font = new System.Drawing.Font("微软雅黑 Light", 9.75F);
            this.cmdautomatic.Location = new System.Drawing.Point(148, 257);
            this.cmdautomatic.Name = "cmdautomatic";
            this.cmdautomatic.Size = new System.Drawing.Size(80, 23);
            this.cmdautomatic.TabIndex = 6;
            this.cmdautomatic.Text = "自动登录";
            this.cmdautomatic.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("微软雅黑 Light", 9.75F);
            this.btnRegister.ForeColor = System.Drawing.Color.Black;
            this.btnRegister.Location = new System.Drawing.Point(277, 308);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(90, 32);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "注册";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            this.btnRegister.MouseLeave += new System.EventHandler(this.btnRegister_MouseLeave);
            this.btnRegister.MouseHover += new System.EventHandler(this.btnRegister_MouseHover);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑 Light", 9.75F);
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLogin.Location = new System.Drawing.Point(125, 309);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(90, 30);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.MouseLeave += new System.EventHandler(this.btnLogin_MouseLeave);
            this.btnLogin.MouseHover += new System.EventHandler(this.btnLogin_MouseHover);
            // 
            // lblUserPwd
            // 
            this.lblUserPwd.AutoSize = true;
            this.lblUserPwd.Font = new System.Drawing.Font("微软雅黑 Light", 9.75F);
            this.lblUserPwd.Location = new System.Drawing.Point(125, 206);
            this.lblUserPwd.Name = "lblUserPwd";
            this.lblUserPwd.Size = new System.Drawing.Size(50, 19);
            this.lblUserPwd.TabIndex = 1;
            this.lblUserPwd.Text = "密   码:";
            // 
            // lblUserNo
            // 
            this.lblUserNo.AutoSize = true;
            this.lblUserNo.Font = new System.Drawing.Font("微软雅黑 Light", 9.75F);
            this.lblUserNo.Location = new System.Drawing.Point(125, 129);
            this.lblUserNo.Name = "lblUserNo";
            this.lblUserNo.Size = new System.Drawing.Size(61, 19);
            this.lblUserNo.TabIndex = 0;
            this.lblUserNo.Text = "用户名：";
            // 
            // FrmLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(544, 445);
            this.Controls.Add(this.txtUserPwd);
            this.Controls.Add(this.txtUserNo);
            this.Controls.Add(this.lblPWd);
            this.Controls.Add(this.cmdremember);
            this.Controls.Add(this.cmdautomatic);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblUserPwd);
            this.Controls.Add(this.lblUserNo);
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogin_FormClosed);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void FormExIni()
        {
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

            SetStyles();
        }

        private void SetStyles()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
        }

        private void WmNcHitTest(ref Message m)  //调整窗体大小
        {
            int wparam = m.LParam.ToInt32();
            Point mouseLocation = new Point(RenderHelper.LOWORD(wparam), RenderHelper.HIWORD(wparam));
            mouseLocation = PointToClient(mouseLocation);

            if (WindowState != FormWindowState.Maximized)
            {
                if (CanResize == true)
                {
                    if (mouseLocation.X < 5 && mouseLocation.Y < 5)
                    {
                        m.Result = new IntPtr(Win32.HTTOPLEFT);
                        return;
                    }

                    if (mouseLocation.X > Width - 5 && mouseLocation.Y < 5)
                    {
                        m.Result = new IntPtr(Win32.HTTOPRIGHT);
                        return;
                    }

                    if (mouseLocation.X < 5 && mouseLocation.Y > Height - 5)
                    {
                        m.Result = new IntPtr(Win32.HTBOTTOMLEFT);
                        return;
                    }

                    if (mouseLocation.X > Width - 5 && mouseLocation.Y > Height - 5)
                    {
                        m.Result = new IntPtr(Win32.HTBOTTOMRIGHT);
                        return;
                    }

                    if (mouseLocation.Y < 3)
                    {
                        m.Result = new IntPtr(Win32.HTTOP);
                        return;
                    }

                    if (mouseLocation.Y > Height - 3)
                    {
                        m.Result = new IntPtr(Win32.HTBOTTOM);
                        return;
                    }

                    if (mouseLocation.X < 3)
                    {
                        m.Result = new IntPtr(Win32.HTLEFT);
                        return;
                    }

                    if (mouseLocation.X > Width - 3)
                    {
                        m.Result = new IntPtr(Win32.HTRIGHT);
                        return;
                    }
                }
            }
            m.Result = new IntPtr(Win32.HTCLIENT);
        }

        private void UpdateMaxButton()  //根据窗体的状态更换最大(还原)系统按钮
        {
            bool isMax = WindowState == FormWindowState.Maximized;
            if (isMax)
            {
                SystemButtonManager.SystemButtonArray[1].NormalImg = Image.FromFile(@".\Res\SystemButton\restore_normal.png");
                SystemButtonManager.SystemButtonArray[1].HighLightImg = Image.FromFile(@".\Res\SystemButton\restore_highlight.png");
                SystemButtonManager.SystemButtonArray[1].PressedImg = Image.FromFile(@".\Res\SystemButton\restore_press.png");
                SystemButtonManager.SystemButtonArray[1].ToolTip = "还原";
            }
            else
            {
                SystemButtonManager.SystemButtonArray[1].NormalImg = Image.FromFile(@".\Res\SystemButton\max_normal.png");
                SystemButtonManager.SystemButtonArray[1].HighLightImg = Image.FromFile(@".\Res\SystemButton\max_highlight.png");
                SystemButtonManager.SystemButtonArray[1].PressedImg = Image.FromFile(@".\Res\SystemButton\max_press.png");
                SystemButtonManager.SystemButtonArray[1].ToolTip = "最大化";
            }
        }

        protected void UpdateSystemButtonRect()
        {
            bool isShowMaxButton = MaximizeBox;
            bool isShowMinButton = MinimizeBox;
            Rectangle closeRect = new Rectangle(
                    Width - SystemButtonManager.SystemButtonArray[0].NormalImg.Width,
                    -1,
                    SystemButtonManager.SystemButtonArray[0].NormalImg.Width,
                    SystemButtonManager.SystemButtonArray[0].NormalImg.Height);

            //update close button location rect.
            SystemButtonManager.SystemButtonArray[0].LocationRect = closeRect;

            //Max
            if (isShowMaxButton)
            {
                SystemButtonManager.SystemButtonArray[1].LocationRect = new Rectangle(
                    closeRect.X - SystemButtonManager.SystemButtonArray[1].NormalImg.Width,
                    -1,
                    SystemButtonManager.SystemButtonArray[1].NormalImg.Width,
                    SystemButtonManager.SystemButtonArray[1].NormalImg.Height);
            }
            else
            {
                SystemButtonManager.SystemButtonArray[1].LocationRect = Rectangle.Empty;
            }

            //Min
            if (!isShowMinButton)
            {
                SystemButtonManager.SystemButtonArray[2].LocationRect = Rectangle.Empty;
                return;
            }
            if (isShowMaxButton)
            {
                SystemButtonManager.SystemButtonArray[2].LocationRect = new Rectangle(
                    SystemButtonManager.SystemButtonArray[1].LocationRect.X - SystemButtonManager.SystemButtonArray[2].NormalImg.Width,
                    -1,
                    SystemButtonManager.SystemButtonArray[2].NormalImg.Width,
                    SystemButtonManager.SystemButtonArray[2].NormalImg.Height);
            }
            else
            {
                SystemButtonManager.SystemButtonArray[2].LocationRect = new Rectangle(
                   closeRect.X - SystemButtonManager.SystemButtonArray[2].NormalImg.Width,
                   -1,
                   SystemButtonManager.SystemButtonArray[2].NormalImg.Width,
                   SystemButtonManager.SystemButtonArray[2].NormalImg.Height);
            }
        }

        #endregion

        public static bool FrmLogin_Recive = true;
        FrmHistoryPlay frm_HistoryPlay = null;
        FrmMusicList frm_Musiclist = null;
        FrmFavoriteMusic frm_FavoriteMusic = null;
        FrmMainHome frm_FrmMainHome = null;
        FrmMainFroms frm_FrmMainFroms = null;



        private void FrmLogin_Load(object sender, EventArgs e)
        {
            #region
            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;//让系统不要多管闲事


                // 创建客户端Socket，连接服务器的IP地址和端口
                PlayMusics.client = new TcpClient("127.0.0.1", 8080);

                byte[] buffer = new byte[1024];

                // 获取客户端的输入输出流
                PlayMusics.stream = PlayMusics.client.GetStream();

                //创建一个负责通讯的socket
                #region 创建一个负责通讯的socket

                #endregion

                //开启新线程
                #region 开启新线程,不停接收服务器是否传过来消息
                FrmLogin_Recive = true;
                Task.Factory.StartNew(() => { Recives(PlayMusics.stream); });
                #endregion
            }
            catch
            {
                MessageBox.Show("服务器异常");
                return;
            }
            #endregion

            this.Opacity = 0.9;

            btnLogin.FlatStyle = FlatStyle.Flat;//样式
            //btnLogin.ForeColor = Color.Transparent;//前景
            btnLogin.BackColor = Color.Transparent;//去背景
            btnLogin.FlatAppearance.BorderSize = 0;//去边线
            btnLogin.FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标经过
            btnLogin.FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下

            btnRegister.FlatStyle = FlatStyle.Flat;//样式
            //btnRegister.ForeColor = Color.Transparent;//前景
            btnRegister.BackColor = Color.Transparent;//去背景
            btnRegister.FlatAppearance.BorderSize = 0;//去边线
            btnRegister.FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标经过
            btnRegister.FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下


            #region 设置label控件背景颜色
            lblUserNo.BackColor = Color.Transparent;//透明
            lblUserPwd.BackColor = Color.Transparent;
            cmdautomatic.BackColor = Color.Transparent;
            cmdremember.BackColor = Color.Transparent;
            lblPWd.BackColor = Color.Transparent;
            btnLogin.BackColor = Color.Transparent;
            btnRegister.BackColor = Color.Transparent;
            #endregion

            txtUserNo.Focus();

            #region 进入管理窗体
            //txtUserNo.Text = "admin";
            //txtUserPwd.Text = "123456";
            //btnLogin_Click(null, null);
            //this.Close();
            #endregion

            #region 进入普通
            //txtUserNo.Text = "ningmeng";
            //txtUserPwd.Text = "123456";
            //btnLogin_Click(null, null);
            #endregion
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatAppearance.BorderSize = 1;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatAppearance.BorderSize = 0;
        }

        private void btnRegister_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatAppearance.BorderSize = 1;
        }

        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatAppearance.BorderSize = 0;
        }

        static DataTable dt = new DataTable();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user_no = txtUserNo.Text.Trim();
            var user_pwd = txtUserPwd.Text.Trim();
            if (user_no == "")
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            if (user_pwd == "")
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            StorePlayback(user_no);

            if (Login_state == "用户名不存在")
            {
                MessageBox.Show("用户名不存在");
                return;
            }
            is_Login(user_no, user_pwd);
            var dt = SqlHelper.ExecuteQuery($"select * from UserInfo where user_no = '{user_no}'and user_pwd = '{user_pwd}'");

            if (dt != null && dt.Rows.Count > 0)
            {
                var dt_user_jurisdiction = dt.Rows[0]["user_jurisdiction"].ToString();
                Program.user_guid = dt.Rows[0]["guid"].ToString();
                if (dt_user_jurisdiction == "1")
                {
                    this.Hide();
                    var frm = new FrmAdminMainFrom();
                    frm.ShowDialog();
                    this.Show();
                }
                if (dt_user_jurisdiction == "0")
                {
                    this.Hide();
                    frm_FrmMainFroms = new FrmMainFroms();
                    frm_FrmMainFroms.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("用户名不存在");
                return;
            }
        }

        /// <summary>
        /// 跳转注册窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new FrmRegister();
            frm.ShowDialog();
            this.Show();
        }

        public static string Login_state = "无状态";

        /// <summary>
        /// 接受消息
        /// </summary>
        public void Recives(NetworkStream stream)
        {
            while (FrmLogin_Recive)
            {
                try
                {
                    // 读取服务器发送的数据


                    byte[] buffer = new byte[1024 * 1024 * 3];

                    int count = stream.Read(buffer, 0, buffer.Length);
                    if (count == 0)
                    {
                        break;
                    }

                    #region 判断输入值是否为空,用户永远不可能发空给我,当发空的时候表示断开连接

                    #endregion

                    #region 拿到第一个值 判断他是那个方法的返回值
                    int n = buffer[0];
                    switch (n)
                    {
                        case 0:
                            {
                                #region 新增历史记录
                                string s = Encoding.UTF8.GetString(buffer, 1, count - 1);
                                #endregion
                            }
                            break;
                        case 1:
                            {
                                #region 搜索启用的音乐
                                DataTable dt = new DataTable();
                                dt = Program.DeserializeDataTableFromBytes(buffer, true, count);
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    var Paht_Hash = dt.Rows[0]["file_hast"].ToString();
                                    Invoke(new Action(() =>
                                    {
                                        frm_FrmMainFroms.bofang(Paht_Hash, dt);
                                    }));//返回主线程
                                }
                                else
                                {
                                    MessageBox.Show("没有歌单");
                                    return;
                                }
                                #endregion
                            }

                            break;
                        case 2:
                            {
                                #region FrmFavoriteMusic音乐列表
                                DataTable dt = new DataTable();
                                dt = Program.DeserializeDataTableFromBytes(buffer, true, count);
                                this.Invoke(new Action(() =>
                                {
                                    this.frm_FavoriteMusic = frm_FrmMainFroms.frm_FavoriteMusic;

                                    this.frm_FavoriteMusic.LoadData(dt);
                                }));//返回主线程
                                #endregion
                            }
                            break;
                        case 3:
                            {
                                #region FrmHistoryPlay音乐列表
                                DataTable dt = new DataTable();
                                dt = Program.DeserializeDataTableFromBytes(buffer, true, count);
                                this.Invoke(new Action(() =>
                                {
                                    this.frm_HistoryPlay = frm_FrmMainFroms.frm_HistoryPlay;
                                    this.frm_HistoryPlay.LoadData(dt);
                                }));//返回主线程
                                #endregion
                            }
                            break;
                        case 4:
                            {
                                #region FrmHistoryPlay单个删除
                                string s = Encoding.UTF8.GetString(buffer, 1, count - 1);
                                MessageBox.Show(s);
                                this.Invoke(new Action(() =>
                                {
                                    this.frm_HistoryPlay = frm_FrmMainFroms.frm_HistoryPlay;
                                    this.frm_HistoryPlay.is_Enable_Music();
                                }));//返回主线程

                                #endregion
                            }
                            break;
                        case 5:
                            {
                                #region FrmHistoryPlay全部删除
                                string s = Encoding.UTF8.GetString(buffer, 1, count - 1);
                                MessageBox.Show(s);
                                this.Invoke(new Action(() =>
                                {
                                    this.frm_HistoryPlay = frm_FrmMainFroms.frm_HistoryPlay;
                                    frm_HistoryPlay.is_Enable_Music();
                                }));//返回主线程
                                #endregion
                            }
                            break;
                        case 6:
                            {
                                #region FrmMainHome刷新
                                DataTable dt = new DataTable();
                                dt = Program.DeserializeDataTableFromBytes(buffer, true, count);
                                this.Invoke(new Action(() =>
                                {
                                    this.frm_FrmMainHome = frm_FrmMainFroms.frm_FrmMainHome;
                                    this.frm_FrmMainHome.LoadData(dt);
                                }));//返回主线程
                                #endregion
                            }
                            break;
                        case 7:
                            {
                                string message = Encoding.UTF8.GetString(buffer, 0, count);


                                if (message != "")
                                {
                                    Login_state = message;
                                }
                            }
                            break;

                        case 8:
                            {
                                dt = Program.DeserializeDataTableFromBytes(buffer, true, count);

                                Login_state = "完成了";
                            }
                            break;
                    }
                    #endregion
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="user_no"></param>
        public void StorePlayback(string user_no)
        {
            try
            {
                string str = $"确认用户名是否存在_{user_no}";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);

                try
                {
                    PlayMusics.stream.Write(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("好像和服务器断开连接了呢,呃呃呃");
                }

                Login_state = "无状态";
            }
            catch
            {
            }
        }

        /// <summary>
        /// 登录是否可以登录 
        /// </summary>
        /// <param name="user_guid"></param>
        public void is_Login(string user_no, string user_pwd)
        {
            Login_state = "无状态";
            try
            {
                string str = $"确认是否登录_{user_no}_{user_pwd}";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
                PlayMusics.stream.Write(buffer, 0, buffer.Length);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 强行关闭所有资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }
    }
}
