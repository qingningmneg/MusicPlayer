using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.DataFormats;

namespace 窗体
{
    public partial class FrmRegister : FormBase
    {
        #region Field
        //窗体圆角矩形半径
        private int _radius = 5;

        //是否允许窗体改变大小
        private bool _canResize = true;

        private Image _fringe = Image.FromFile(@"Res\fringe_bkg.png");

        //窗体背景
        private Image _formBkg = Image.FromFile(@"Res\FormBkg\preview.gif");
        private Label lblUserNo;
        private Label lblUserPwd;
        private Button btnCancel;
        private Button btnRegister;
        private DevExpress.XtraEditors.TextEdit txtUserNo;
        private DevExpress.XtraEditors.TextEdit txtUserPwd;
        private DevExpress.XtraEditors.TextEdit txtNumber;
        private Label labNumber;
        private DevExpress.XtraEditors.TextEdit txtVerification;
        private Label labVerification;
        private Button btnSendOut;
        private DevExpress.XtraEditors.TextEdit txtReUserPwd;
        private Label labReUserPwd;

        //系统按钮管理器
        private SystemButtonManager _systemButtonManager;
        #endregion

        #region Constructor

        public FrmRegister()
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
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblUserPwd = new System.Windows.Forms.Label();
            this.lblUserNo = new System.Windows.Forms.Label();
            this.labNumber = new System.Windows.Forms.Label();
            this.labVerification = new System.Windows.Forms.Label();
            this.btnSendOut = new System.Windows.Forms.Button();
            this.txtVerification = new DevExpress.XtraEditors.TextEdit();
            this.txtNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtUserPwd = new DevExpress.XtraEditors.TextEdit();
            this.txtUserNo = new DevExpress.XtraEditors.TextEdit();
            this.txtReUserPwd = new DevExpress.XtraEditors.TextEdit();
            this.labReUserPwd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtVerification.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReUserPwd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("微软雅黑 Light", 9.75F);
            this.btnRegister.ForeColor = System.Drawing.Color.Black;
            this.btnRegister.Location = new System.Drawing.Point(157, 318);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(90, 32);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "注册";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            this.btnRegister.MouseLeave += new System.EventHandler(this.btnRegister_MouseLeave);
            this.btnRegister.MouseHover += new System.EventHandler(this.btnRegister_MouseHover);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑 Light", 9.75F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(275, 318);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btnCancel_MouseLeave);
            this.btnCancel.MouseHover += new System.EventHandler(this.btnCancel_MouseHover);
            // 
            // lblUserPwd
            // 
            this.lblUserPwd.AutoSize = true;
            this.lblUserPwd.Font = new System.Drawing.Font("微软雅黑 Light", 9.75F);
            this.lblUserPwd.Location = new System.Drawing.Point(139, 113);
            this.lblUserPwd.Name = "lblUserPwd";
            this.lblUserPwd.Size = new System.Drawing.Size(50, 19);
            this.lblUserPwd.TabIndex = 1;
            this.lblUserPwd.Text = "密   码:";
            // 
            // lblUserNo
            // 
            this.lblUserNo.AutoSize = true;
            this.lblUserNo.Font = new System.Drawing.Font("微软雅黑 Light", 9.75F);
            this.lblUserNo.Location = new System.Drawing.Point(138, 69);
            this.lblUserNo.Name = "lblUserNo";
            this.lblUserNo.Size = new System.Drawing.Size(61, 19);
            this.lblUserNo.TabIndex = 0;
            this.lblUserNo.Text = "用户名：";
            // 
            // labNumber
            // 
            this.labNumber.AutoSize = true;
            this.labNumber.Font = new System.Drawing.Font("微软雅黑 Light", 9.75F);
            this.labNumber.Location = new System.Drawing.Point(139, 202);
            this.labNumber.Name = "labNumber";
            this.labNumber.Size = new System.Drawing.Size(51, 19);
            this.labNumber.TabIndex = 14;
            this.labNumber.Text = "手机号:";
            // 
            // labVerification
            // 
            this.labVerification.AutoSize = true;
            this.labVerification.Font = new System.Drawing.Font("微软雅黑 Light", 9.75F);
            this.labVerification.Location = new System.Drawing.Point(139, 255);
            this.labVerification.Name = "labVerification";
            this.labVerification.Size = new System.Drawing.Size(51, 19);
            this.labVerification.TabIndex = 16;
            this.labVerification.Text = "验证码:";
            // 
            // btnSendOut
            // 
            this.btnSendOut.Font = new System.Drawing.Font("微软雅黑 Light", 9.75F);
            this.btnSendOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSendOut.Location = new System.Drawing.Point(387, 196);
            this.btnSendOut.Name = "btnSendOut";
            this.btnSendOut.Size = new System.Drawing.Size(90, 30);
            this.btnSendOut.TabIndex = 5;
            this.btnSendOut.Text = "发送";
            this.btnSendOut.UseVisualStyleBackColor = true;
            this.btnSendOut.Click += new System.EventHandler(this.btnSendOut_Click);
            this.btnSendOut.MouseLeave += new System.EventHandler(this.btnSendOut_MouseLeave);
            this.btnSendOut.MouseHover += new System.EventHandler(this.btnSendOut_MouseHover);
            // 
            // txtVerification
            // 
            this.txtVerification.Location = new System.Drawing.Point(206, 255);
            this.txtVerification.Name = "txtVerification";
            this.txtVerification.Size = new System.Drawing.Size(175, 20);
            this.txtVerification.TabIndex = 6;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(206, 202);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(175, 20);
            this.txtNumber.TabIndex = 4;
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.Location = new System.Drawing.Point(206, 113);
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.Size = new System.Drawing.Size(175, 20);
            this.txtUserPwd.TabIndex = 2;
            // 
            // txtUserNo
            // 
            this.txtUserNo.Location = new System.Drawing.Point(205, 69);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Size = new System.Drawing.Size(175, 20);
            this.txtUserNo.TabIndex = 1;
            // 
            // txtReUserPwd
            // 
            this.txtReUserPwd.Location = new System.Drawing.Point(206, 156);
            this.txtReUserPwd.Name = "txtReUserPwd";
            this.txtReUserPwd.Size = new System.Drawing.Size(175, 20);
            this.txtReUserPwd.TabIndex = 3;
            // 
            // labReUserPwd
            // 
            this.labReUserPwd.AutoSize = true;
            this.labReUserPwd.Font = new System.Drawing.Font("微软雅黑 Light", 9.75F);
            this.labReUserPwd.Location = new System.Drawing.Point(139, 156);
            this.labReUserPwd.Name = "labReUserPwd";
            this.labReUserPwd.Size = new System.Drawing.Size(64, 19);
            this.labReUserPwd.TabIndex = 19;
            this.labReUserPwd.Text = "确认密码:";
            // 
            // FrmRegister
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(544, 445);
            this.Controls.Add(this.txtReUserPwd);
            this.Controls.Add(this.labReUserPwd);
            this.Controls.Add(this.btnSendOut);
            this.Controls.Add(this.txtVerification);
            this.Controls.Add(this.labVerification);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.labNumber);
            this.Controls.Add(this.txtUserPwd);
            this.Controls.Add(this.txtUserNo);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblUserPwd);
            this.Controls.Add(this.lblUserNo);
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册";
            this.Load += new System.EventHandler(this.FrmResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtVerification.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReUserPwd.Properties)).EndInit();
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

        string str_RandomCode = "";

        private void FrmResult_Load(object sender, EventArgs e)
        {
            #region 美化窗体
            this.Opacity = 0.9;

            btnCancel.FlatStyle = FlatStyle.Flat;//样式
            //btnLogin.ForeColor = Color.Transparent;//前景
            btnCancel.BackColor = Color.Transparent;//去背景
            btnCancel.FlatAppearance.BorderSize = 0;//去边线
            btnCancel.FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标经过
            btnCancel.FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下

            btnRegister.FlatStyle = FlatStyle.Flat;//样式
            //btnRegister.ForeColor = Color.Transparent;//前景
            btnRegister.BackColor = Color.Transparent;//去背景
            btnRegister.FlatAppearance.BorderSize = 0;//去边线
            btnRegister.FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标经过
            btnRegister.FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下

            btnSendOut.FlatStyle = FlatStyle.Flat;//样式
            //btnRegister.ForeColor = Color.Transparent;//前景
            btnSendOut.BackColor = Color.Transparent;//去背景
            btnSendOut.FlatAppearance.BorderSize = 0;//去边线
            btnSendOut.FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标经过
            btnSendOut.FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下


            #region 设置label控件背景颜色
            lblUserNo.BackColor = Color.Transparent;//透明
            lblUserPwd.BackColor = Color.Transparent;
            labNumber.BackColor = Color.Transparent;
            labReUserPwd.BackColor = Color.Transparent;
            labVerification.BackColor = Color.Transparent;
            btnCancel.BackColor = Color.Transparent;
            btnRegister.BackColor = Color.Transparent;
            btnSendOut.BackColor = Color.Transparent;
            #endregion

            txtUserNo.Focus();
            #endregion

            this.str_RandomCode = GenerateRandomCode(6);
        }

        /// <summary>
        ///生成制定位数的随机码（数字）
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string GenerateRandomCode(int length)
        {
            var result = new StringBuilder();
            result.Append(136);

            for (var i = 0; i < length; i++)
            {
                var r = new Random(Guid.NewGuid().GetHashCode());
                result.Append(r.Next(1, 10));
            }
            return result.ToString();
        }

        private void btnCancel_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatAppearance.BorderSize = 1;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
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

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            var user_no = txtUserNo.Text.Trim();//用户名
            var user_pwd = txtUserPwd.Text.Trim();//密码
            var user_re_pwd = txtReUserPwd.Text.Trim();//确认密码
            var user_Number = txtNumber.Text.Trim();//手机号
            var user_Verification = txtVerification.Text.Trim();//验证码

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
            if (user_pwd != user_re_pwd)
            {
                MessageBox.Show("两次密码不一致");
                return;
            }
            if (user_Number == "")
            {
                MessageBox.Show("手机号不能为空");
                return;
            }
            if (user_Verification != str_RandomCode)
            {
                MessageBox.Show("验证码错误");
                return;
            }

            var dt = SqlHelper.ExecuteQuery($@"select * from UserInfo where user_no = '${user_no}'");
            if (dt != null && dt.Rows.Count > 0)
            {
                MessageBox.Show("用户名已存在");
                return;
            }
            else
            {
                string guid = Guid.NewGuid().ToString();
                SqlHelper.ExecuteNonQuery($@"insert into UserInfo (guid,user_no,user_pwd,user_Number,user_jurisdiction)values('{guid}','{user_no}','{user_pwd}','{user_Number}','0')");
                MessageBox.Show("注册成功");
                this.Close();
            }
        }

        /// <summary>
        /// 验证页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendOut_Click(object sender, EventArgs e)
        {
            var frm = new FrmVerification();
            frm.ShowDialog();
            this.Show();
            if (Program.e_Pass_yanzheng == "通过")
            {
                txtVerification.Text = str_RandomCode;
            }
        }

        private void btnSendOut_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatAppearance.BorderSize = 1;
        }

        private void btnSendOut_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatAppearance.BorderSize = 0;
        }
    }
}
