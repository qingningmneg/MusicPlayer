
/*****��Ȩ***************************************************************

��Ȩ��  ��������ľ������֯
���ߣ�  ��������ľ������֯
���ڣ�  2020-10-28
������  ��ֹɾ�������ľ��ʫ,
        ���� https://www.cnblogs.com/tlmbem/ ,
        Դ���ַ https://gitee.com/tlmbem/hml ,
        ��Ȩʹ���� https://gitee.com/tlmbem/hml ���н��ܡ�
	
              	ľ��ʫ
              	
        ��������ľ������֯��
        ���Ż�������Ψ��Ů̾Ϣ�� 
        ��Ů����˼����Ů�����䡣
        Ů������˼��Ů�������䡣
        ��ҹ���������ɺ�������
        ����ʮ���������ү����
        ��ү�޴����ľ���޳��֣�
        ԸΪ�а����Ӵ���ү���� 
        ������������������
        ��������ͷ�������򳤱ޡ�
        ����ү��ȥ��ĺ�޻ƺӱߣ�
        ����ү�﻽Ů�������Żƺ���ˮ��������
        ���ǻƺ�ȥ��ĺ����ɽͷ��
        ����ү�﻽Ů����������ɽ�������ౡ� 
        ���︰�ֻ�����ɽ�����ɡ�
        ˷�������أ����������¡�
        ������ս����׳ʿʮ��顣 
        ���������ӣ����������á�
        ��ѫʮ��ת���ʹͰ�ǧǿ��
        �ɺ���������ľ�����������ɣ�
        Ը��ǧ���㣬�Ͷ������硣
        ү����Ů���������������
        ������������������ױ��
        С���������ĥ������������
        ���Ҷ����ţ��������󴲣�
        ����սʱ�ۣ����Ҿ�ʱ�ѡ�
        ���������ޣ��Ծ������ơ�
        ���ſ���飬���Ծ�æ��
        ͬ��ʮ���꣬��֪ľ����Ů�ɡ� 
        
*********************************************************************/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WinformControlLibraryExtension.Design
{
    /// <summary>
    /// ��������״��ť·���ƶ��༭��
    /// </summary>
    [Description("��������״��ť·���ƶ��༭��")]
    public class AnomalyButtonShapePointsAnchorEditor : UITypeEditor
    {
        #region �ֶ�

        private AnomalyButton ab = null;
        /// <summary>
        /// ·����Ҫ�ƶ�����
        /// </summary>
        private string move_type = "";
        /// <summary>
        /// ��갴��ʱ·���㼯��
        /// </summary>
        private PointF[] move_objectpoint = null;
        /// <summary>
        /// ��갴�µ�����
        /// </summary>
        private PointF move_mousepoint = PointF.Empty;

        #endregion

        #region ��д

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            //ָ��Ϊģʽ�������Ա༭������
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            ShapePathPointsAnchorEditorForm spaef = new ShapePathPointsAnchorEditorForm() { AutoScaleMode = AutoScaleMode.None, Size = new Size(160, 160) };

            spaef.Leave += this.Apef_Leave;

            spaef.Anchor_Left_Btn.Click += this.Anchor_Left_Btn_Click;
            spaef.Anchor_Right_Btn.Click += this.Anchor_Right_Btn_Click;
            spaef.Anchor_Top_Btn.Click += this.Anchor_Top_Btn_Click;
            spaef.Anchor_Bottom_Btn.Click += this.Anchor_Bottom_Btn_Click;

            spaef.Anchor_LeftTop_Btn.Click += this.Anchor_LeftTop_Btn_Click;
            spaef.Anchor_RightTop_Btn.Click += this.Anchor_RightTop_Btn_Click;
            spaef.Anchor_LeftBottom_Btn.Click += this.Anchor_LeftBottom_Btn_Click;
            spaef.Anchor_RightBottom_Btn.Click += this.Anchor_RightBottom_Btn_Click;

            spaef.Move_Left_Btn.Tag = "Move_Left";
            spaef.Move_Left_Btn.MouseDown += this.Move_Left_Btn_MouseDown;
            spaef.Move_Left_Btn.MouseUp += this.Move_Right_Btn_MouseUp;
            spaef.Move_Left_Btn.MouseMove += this.Move_Left_Btn_MouseMove;
            spaef.Move_Right_Btn.Tag = "Move_Right";
            spaef.Move_Right_Btn.MouseDown += this.Move_Left_Btn_MouseDown;
            spaef.Move_Right_Btn.MouseUp += this.Move_Right_Btn_MouseUp;
            spaef.Move_Right_Btn.MouseMove += this.Move_Left_Btn_MouseMove;
            spaef.Move_Top_Btn.Tag = "Move_Top";
            spaef.Move_Top_Btn.MouseDown += this.Move_Left_Btn_MouseDown;
            spaef.Move_Top_Btn.MouseUp += this.Move_Right_Btn_MouseUp;
            spaef.Move_Top_Btn.MouseMove += this.Move_Left_Btn_MouseMove;
            spaef.Move_Bottom_Btn.Tag = "Move_Bottom";
            spaef.Move_Bottom_Btn.MouseDown += this.Move_Left_Btn_MouseDown;
            spaef.Move_Bottom_Btn.MouseUp += this.Move_Right_Btn_MouseUp;
            spaef.Move_Bottom_Btn.MouseMove += this.Move_Left_Btn_MouseMove;
            spaef.Move_Center_Btn.Tag = "Move_Center";
            spaef.Move_Center_Btn.MouseDown += this.Move_Left_Btn_MouseDown;
            spaef.Move_Center_Btn.MouseUp += this.Move_Right_Btn_MouseUp;
            spaef.Move_Center_Btn.MouseMove += this.Move_Left_Btn_MouseMove;

            this.ab = context.Instance as AnomalyButton;

            IWindowsFormsEditorService editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            editorService.DropDownControl(spaef);

            return base.EditValue(context, provider, value);
        }

        #endregion

        #region ˽�з���

        private void Anchor_Left_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_Left");
        }
        private void Anchor_Right_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_Right");
        }
        private void Anchor_Top_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_Top");
        }
        private void Anchor_Bottom_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_Bottom");
        }
        private void Anchor_Center_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("AnchorCenter");
        }

        private void Anchor_LeftTop_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_LeftTop");
        }
        private void Anchor_RightTop_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_RightTop");
        }
        private void Anchor_LeftBottom_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_LeftBottom");
        }
        private void Anchor_RightBottom_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_RightBottom");
        }

        private void Apef_Leave(object sender, EventArgs e)
        {
            this.move_type = "";
            this.move_objectpoint = null;
            this.move_mousepoint = PointF.Empty;
        }
        private void Move_Left_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            PointF[] points = this.ab.GetShapeRealityPoints();

            GraphicsPath gp = new GraphicsPath();
            gp.AddClosedCurve(points);
            RectangleF rectf = gp.GetBounds();
            gp.Dispose();

            this.move_type = ((Button)sender).Tag.ToString();
            this.move_objectpoint = points;
            this.move_mousepoint = this.ab.PointToClient(Control.MousePosition);

        }
        private void Move_Right_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            this.move_type = "";
            this.move_objectpoint = null;
            this.move_mousepoint = PointF.Empty;
        }
        private void Move_Left_Btn_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.move_objectpoint != null && this.move_type != "")
            {
                PointF point = this.ab.PointToClient(Control.MousePosition);
                PointF p = new PointF(point.X - move_mousepoint.X, point.Y - move_mousepoint.Y);
                PointF[] tmp = new PointF[this.move_objectpoint.Length];

                if (this.move_type == "Move_Left" || this.move_type == "Move_Right")
                {
                    for (int i = 0; i < this.move_objectpoint.Length; i++)
                    {
                        tmp[i] = new PointF((float)Math.Round((this.move_objectpoint[i].X + p.X) / DotsPerInchHelper.DPIScale.XScale, 2), (float)Math.Round((this.move_objectpoint[i].Y) / DotsPerInchHelper.DPIScale.XScale, 2));
                    }
                }
                else if (this.move_type == "Move_Top" || this.move_type == "Move_Bottom")
                {

                    for (int i = 0; i < this.move_objectpoint.Length; i++)
                    {
                        tmp[i] = new PointF((float)Math.Round((this.move_objectpoint[i].X) / DotsPerInchHelper.DPIScale.XScale, 2), (float)Math.Round((this.move_objectpoint[i].Y + p.Y) / DotsPerInchHelper.DPIScale.XScale, 2));
                    }
                }
                else if (this.move_type == "Move_Center")
                {
                    for (int i = 0; i < this.move_objectpoint.Length; i++)
                    {
                        tmp[i] = new PointF((float)Math.Round((this.move_objectpoint[i].X + p.X) / DotsPerInchHelper.DPIScale.XScale, 2), (float)Math.Round((this.move_objectpoint[i].Y + p.Y) / DotsPerInchHelper.DPIScale.XScale, 2));
                    }
                }

                PropertyDescriptor pd = TypeDescriptor.GetProperties(ab)["ShapePoints"];
                pd.SetValue(ab, ab.SerializeShapePoints(tmp));
            }

        }

        /// <summary>
        /// ͣ����λ
        /// </summary>
        /// <param name="type">ͣ����λ����</param>
        private void Anchor_Points(string type)
        {
            PointF[] points = this.ab.GetShapeRealityPoints();

            GraphicsPath gp = new GraphicsPath();
            gp.AddClosedCurve(points);
            RectangleF rectf = gp.GetBounds();
            gp.Dispose();

            if (type == "Anchor_Left")
            {
                float x = 0;
                this.UpdatePointsXY(x - rectf.X, 0);
            }
            else if (type == "Anchor_Right")
            {
                float x = this.ab.ClientRectangle.Right - rectf.Width;
                this.UpdatePointsXY(x - rectf.X, 0);
            }
            else if (type == "Anchor_Top")
            {
                float y = 0;
                this.UpdatePointsXY(0, y - rectf.Y);
            }
            else if (type == "Anchor_Bottom")
            {
                float y = this.ab.ClientRectangle.Bottom - rectf.Height;
                this.UpdatePointsXY(0, y - rectf.Y);
            }

            else if (type == "Anchor_LeftTop")
            {
                float x = this.ab.ClientRectangle.X;
                float y = this.ab.ClientRectangle.Y;
                this.UpdatePointsXY(x - rectf.X, y - rectf.Y);
            }
            else if (type == "Anchor_RightTop")
            {
                float x = this.ab.ClientRectangle.Right - rectf.Width;
                float y = this.ab.ClientRectangle.Y;
                this.UpdatePointsXY(x - rectf.X, y - rectf.Y);
            }
            else if (type == "Anchor_LeftBottom")
            {
                float x = this.ab.ClientRectangle.X;
                float y = this.ab.ClientRectangle.Bottom - rectf.Height;
                this.UpdatePointsXY(x - rectf.X, y - rectf.Y);
            }
            else if (type == "Anchor_RightBottom")
            {
                float x = this.ab.ClientRectangle.Right - rectf.Width;
                float y = this.ab.ClientRectangle.Bottom - rectf.Height;
                this.UpdatePointsXY(x - rectf.X, y - rectf.Y);
            }

            else if (type == "Anchor_Center")
            {
                float x = (this.ab.ClientRectangle.Width - rectf.Width) / 2;
                float y = (this.ab.ClientRectangle.Height - rectf.Height) / 2;

                this.UpdatePointsXY(x - rectf.X, y - rectf.Y);
            }
        }

        /// <summary>
        /// �޸�·�����е�ƫ����
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void UpdatePointsXY(float x, float y)
        {
            if (this.ab == null)
                return;

            PointF[] points = this.ab.GetShapeRealityPoints();
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X = (float)Math.Round((points[i].X + x) / DotsPerInchHelper.DPIScale.XScale, 2);
                points[i].Y = (float)Math.Round((points[i].Y + y) / DotsPerInchHelper.DPIScale.XScale, 2);
            }
            PropertyDescriptor pd = TypeDescriptor.GetProperties(ab)["ShapePoints"];
            pd.SetValue(ab, ab.SerializeShapePoints(points));
        }

        #endregion

    }

    /// <summary>
    /// �ı����������ƶ��༭��
    /// </summary>
    [Description("�ı����������ƶ��༭��")]
    public class AnomalyButtonTextCenterPointEditor : UITypeEditor
    {
        #region �ֶ�

        private AnomalyButton ab = null;
        /// <summary>
        /// Ҫ������������
        /// </summary>
        private string fieldStr = "";
        /// <summary>
        /// �ı�Ҫ�ƶ�����
        /// </summary>
        private string move_type = "";
        /// <summary>
        /// ��갴��ʱ�ı�����
        /// </summary>
        private ComplexityPropertys.PointF move_objectpoint = ComplexityPropertys.PointF.Empty;
        /// <summary>
        /// ��갴�µ�����
        /// </summary>
        private ComplexityPropertys.PointF move_mousepoint = ComplexityPropertys.PointF.Empty;

        #endregion

        #region ��д

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            //ָ��Ϊģʽ�������Ա༭������
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            this.fieldStr = context.PropertyDescriptor.Name;

            ShapePathPointsAnchorEditorForm spaef = new ShapePathPointsAnchorEditorForm() { AutoScaleMode = AutoScaleMode.None, Size = new Size(160, 160) };

            spaef.Leave += this.Apef_Leave;

            spaef.Anchor_Left_Btn.Click += this.Anchor_Left_Btn_Click;
            spaef.Anchor_Right_Btn.Click += this.Anchor_Right_Btn_Click;
            spaef.Anchor_Top_Btn.Click += this.Anchor_Top_Btn_Click;
            spaef.Anchor_Bottom_Btn.Click += this.Anchor_Bottom_Btn_Click;

            spaef.Anchor_LeftTop_Btn.Click += this.Anchor_LeftTop_Btn_Click;
            spaef.Anchor_RightTop_Btn.Click += this.Anchor_RightTop_Btn_Click;
            spaef.Anchor_LeftBottom_Btn.Click += this.Anchor_LeftBottom_Btn_Click;
            spaef.Anchor_RightBottom_Btn.Click += this.Anchor_RightBottom_Btn_Click;

            spaef.Move_Left_Btn.Tag = "Move_Left";
            spaef.Move_Left_Btn.MouseDown += this.Move_Left_Btn_MouseDown;
            spaef.Move_Left_Btn.MouseUp += this.Move_Right_Btn_MouseUp;
            spaef.Move_Left_Btn.MouseMove += this.Move_Left_Btn_MouseMove;
            spaef.Move_Right_Btn.Tag = "Move_Right";
            spaef.Move_Right_Btn.MouseDown += this.Move_Left_Btn_MouseDown;
            spaef.Move_Right_Btn.MouseUp += this.Move_Right_Btn_MouseUp;
            spaef.Move_Right_Btn.MouseMove += this.Move_Left_Btn_MouseMove;
            spaef.Move_Top_Btn.Tag = "Move_Top";
            spaef.Move_Top_Btn.MouseDown += this.Move_Left_Btn_MouseDown;
            spaef.Move_Top_Btn.MouseUp += this.Move_Right_Btn_MouseUp;
            spaef.Move_Top_Btn.MouseMove += this.Move_Left_Btn_MouseMove;
            spaef.Move_Bottom_Btn.Tag = "Move_Bottom";
            spaef.Move_Bottom_Btn.MouseDown += this.Move_Left_Btn_MouseDown;
            spaef.Move_Bottom_Btn.MouseUp += this.Move_Right_Btn_MouseUp;
            spaef.Move_Bottom_Btn.MouseMove += this.Move_Left_Btn_MouseMove;
            spaef.Move_Center_Btn.Tag = "Move_Center";
            spaef.Move_Center_Btn.MouseDown += this.Move_Left_Btn_MouseDown;
            spaef.Move_Center_Btn.MouseUp += this.Move_Right_Btn_MouseUp;
            spaef.Move_Center_Btn.MouseMove += this.Move_Left_Btn_MouseMove;

            this.ab = context.Instance as AnomalyButton;

            IWindowsFormsEditorService editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            editorService.DropDownControl(spaef);

            return base.EditValue(context, provider, value);
        }

        #endregion

        #region ˽�з���

        private void Anchor_Left_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_Left");
        }
        private void Anchor_Right_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_Right");
        }
        private void Anchor_Top_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_Top");
        }
        private void Anchor_Bottom_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_Bottom");
        }
        private void Anchor_Center_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("AnchorCenter");
        }

        private void Anchor_LeftTop_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_LeftTop");
        }
        private void Anchor_RightTop_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_RightTop");
        }
        private void Anchor_LeftBottom_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_LeftBottom");
        }
        private void Anchor_RightBottom_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_RightBottom");
        }

        private void Apef_Leave(object sender, EventArgs e)
        {
            this.move_type = "";
            this.move_objectpoint = ComplexityPropertys.PointF.Empty;
            this.move_mousepoint = ComplexityPropertys.PointF.Empty;
        }
        private void Move_Left_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            this.move_type = ((Button)sender).Tag.ToString();
            this.move_objectpoint = new ComplexityPropertys.PointF(this.ab.TextPoint.X * DotsPerInchHelper.DPIScale.XScale, this.ab.TextPoint.Y * DotsPerInchHelper.DPIScale.XScale);
            this.move_mousepoint = ComplexityPropertys.PointF.ConvertFrom(this.ab.PointToClient(Control.MousePosition));
        }
        private void Move_Right_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            this.move_type = "";
            this.move_objectpoint = ComplexityPropertys.PointF.Empty;
            this.move_mousepoint = ComplexityPropertys.PointF.Empty;
        }
        private void Move_Left_Btn_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.move_type != "")
            {
                ComplexityPropertys.PointF point = ComplexityPropertys.PointF.ConvertFrom(this.ab.PointToClient(Control.MousePosition));
                ComplexityPropertys.PointF p = new ComplexityPropertys.PointF(point.X - move_mousepoint.X, point.Y - move_mousepoint.Y);
                ComplexityPropertys.PointF tmp = ComplexityPropertys.PointF.Empty;

                if (this.move_type == "Move_Left" || this.move_type == "Move_Right")
                {
                    tmp = new ComplexityPropertys.PointF((float)Math.Round((this.move_objectpoint.X + p.X) / DotsPerInchHelper.DPIScale.XScale, 2), (float)Math.Round((this.move_objectpoint.Y) / DotsPerInchHelper.DPIScale.XScale, 2));
                }
                else if (this.move_type == "Move_Top" || this.move_type == "Move_Bottom")
                {
                    tmp = new ComplexityPropertys.PointF((float)Math.Round((this.move_objectpoint.X) / DotsPerInchHelper.DPIScale.XScale, 2), (float)Math.Round((this.move_objectpoint.Y + p.Y) / DotsPerInchHelper.DPIScale.XScale, 2));
                }
                else if (this.move_type == "Move_Center")
                {
                    tmp = new ComplexityPropertys.PointF((float)Math.Round((this.move_objectpoint.X + p.X) / DotsPerInchHelper.DPIScale.XScale, 2), (float)Math.Round((this.move_objectpoint.Y + p.Y) / DotsPerInchHelper.DPIScale.XScale, 2));
                }

                PropertyDescriptor pd = TypeDescriptor.GetProperties(ab)[this.fieldStr];
                pd.SetValue(ab, tmp);
            }

        }

        /// <summary>
        /// ͣ����λ
        /// </summary>
        /// <param name="type">ͣ����λ����</param>
        private void Anchor_Points(string type)
        {
            this.move_objectpoint = new ComplexityPropertys.PointF(this.ab.TextPoint.X * DotsPerInchHelper.DPIScale.XScale, this.ab.TextPoint.Y * DotsPerInchHelper.DPIScale.XScale);

            IntPtr hDC = IntPtr.Zero;
            Graphics g = null;
            ControlCommom.GetWindowClientGraphics(this.ab.Handle, out g, out hDC);
            Size text_size = Size.Ceiling(g.MeasureString(this.ab.Text, this.ab.Font, int.MaxValue, StringFormat.GenericDefault));
            g.Dispose();
            WindowNavigate.ReleaseDC(this.ab.Handle, hDC);

            if (type == "Anchor_Left")
            {
                int x = text_size.Width / 2;
                this.UpdatePointsXY(x - this.move_objectpoint.X, 0);
            }
            else if (type == "Anchor_Right")
            {
                int x = this.ab.ClientRectangle.Right - text_size.Width / 2;
                this.UpdatePointsXY(x - this.move_objectpoint.X, 0);
            }
            else if (type == "Anchor_Top")
            {
                int y = text_size.Height / 2;
                this.UpdatePointsXY(0, y - this.move_objectpoint.Y);
            }
            else if (type == "Anchor_Bottom")
            {
                int y = this.ab.ClientRectangle.Bottom - text_size.Height / 2;
                this.UpdatePointsXY(0, y - this.move_objectpoint.Y);
            }

            else if (type == "Anchor_LeftTop")
            {
                int x = text_size.Width / 2;
                int y = text_size.Height / 2;
                this.UpdatePointsXY(x - this.move_objectpoint.X, y - this.move_objectpoint.Y);
            }
            else if (type == "Anchor_RightTop")
            {
                int x = this.ab.ClientRectangle.Right - text_size.Width / 2;
                int y = text_size.Height / 2;
                this.UpdatePointsXY(x - this.move_objectpoint.X, y - this.move_objectpoint.Y);
            }
            else if (type == "Anchor_LeftBottom")
            {
                int x = text_size.Width / 2;
                int y = this.ab.ClientRectangle.Bottom - text_size.Height / 2;
                this.UpdatePointsXY(x - this.move_objectpoint.X, y - this.move_objectpoint.Y);
            }
            else if (type == "Anchor_RightBottom")
            {
                int x = this.ab.ClientRectangle.Right - text_size.Width / 2;
                int y = this.ab.ClientRectangle.Bottom - text_size.Height / 2;
                this.UpdatePointsXY(x - this.move_objectpoint.X, y - this.move_objectpoint.Y);
            }

            else if (type == "Anchor_Center")
            {
                int x = (this.ab.ClientRectangle.Width - text_size.Width) / 2;
                int y = (this.ab.ClientRectangle.Height - text_size.Height) / 2;
                this.UpdatePointsXY(x - this.move_objectpoint.X, y - this.move_objectpoint.Y);
            }
        }

        /// <summary>
        /// �޸��ı�ƫ����
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void UpdatePointsXY(float x, float y)
        {
            if (this.ab == null)
                return;
            ComplexityPropertys.PointF tmp = new ComplexityPropertys.PointF((float)Math.Round((this.move_objectpoint.X + x) / DotsPerInchHelper.DPIScale.XScale, 2), (float)Math.Round((this.move_objectpoint.Y + y) / DotsPerInchHelper.DPIScale.XScale, 2));
            PropertyDescriptor pd = TypeDescriptor.GetProperties(this.ab)[this.fieldStr];
            pd.SetValue(this.ab, tmp);
        }

        #endregion

    }

    /// <summary>
    /// Rectangle���������ƶ��༭��
    /// </summary>
    [Description("Rectangle���������ƶ��༭��")]
    public class AnomalyButtonRectangleCenterPointEditor : UITypeEditor
    {
        #region �ֶ�

        private AnomalyButton ab = null;
        /// <summary>
        /// Ҫ������������
        /// </summary>
        private string fieldStr = "";
        /// <summary>
        /// �ı�Ҫ�ƶ�����
        /// </summary>
        private string move_type = "";
        /// <summary>
        /// ��갴��ʱRectangle����
        /// </summary>
        private ComplexityPropertys.PointF move_objectpoint = ComplexityPropertys.PointF.Empty;
        /// <summary>
        /// ��갴�µ�����
        /// </summary>
        private ComplexityPropertys.PointF move_mousepoint = ComplexityPropertys.PointF.Empty;

        #endregion

        #region ��д

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            //ָ��Ϊģʽ�������Ա༭������
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            this.ab = context.Instance as AnomalyButton;
            this.fieldStr = context.PropertyDescriptor.Name;

            ShapePathPointsAnchorEditorForm spaef = new ShapePathPointsAnchorEditorForm() { AutoScaleMode = AutoScaleMode.None, Size = new Size(160, 160) };

            spaef.Leave += this.Apef_Leave;

            spaef.Anchor_Left_Btn.Click += this.Anchor_Left_Btn_Click;
            spaef.Anchor_Right_Btn.Click += this.Anchor_Right_Btn_Click;
            spaef.Anchor_Top_Btn.Click += this.Anchor_Top_Btn_Click;
            spaef.Anchor_Bottom_Btn.Click += this.Anchor_Bottom_Btn_Click;

            spaef.Anchor_LeftTop_Btn.Click += this.Anchor_LeftTop_Btn_Click;
            spaef.Anchor_RightTop_Btn.Click += this.Anchor_RightTop_Btn_Click;
            spaef.Anchor_LeftBottom_Btn.Click += this.Anchor_LeftBottom_Btn_Click;
            spaef.Anchor_RightBottom_Btn.Click += this.Anchor_RightBottom_Btn_Click;

            spaef.Move_Left_Btn.Tag = "Move_Left";
            spaef.Move_Left_Btn.MouseDown += this.Move_Left_Btn_MouseDown;
            spaef.Move_Left_Btn.MouseUp += this.Move_Right_Btn_MouseUp;
            spaef.Move_Left_Btn.MouseMove += this.Move_Left_Btn_MouseMove;
            spaef.Move_Right_Btn.Tag = "Move_Right";
            spaef.Move_Right_Btn.MouseDown += this.Move_Left_Btn_MouseDown;
            spaef.Move_Right_Btn.MouseUp += this.Move_Right_Btn_MouseUp;
            spaef.Move_Right_Btn.MouseMove += this.Move_Left_Btn_MouseMove;
            spaef.Move_Top_Btn.Tag = "Move_Top";
            spaef.Move_Top_Btn.MouseDown += this.Move_Left_Btn_MouseDown;
            spaef.Move_Top_Btn.MouseUp += this.Move_Right_Btn_MouseUp;
            spaef.Move_Top_Btn.MouseMove += this.Move_Left_Btn_MouseMove;
            spaef.Move_Bottom_Btn.Tag = "Move_Bottom";
            spaef.Move_Bottom_Btn.MouseDown += this.Move_Left_Btn_MouseDown;
            spaef.Move_Bottom_Btn.MouseUp += this.Move_Right_Btn_MouseUp;
            spaef.Move_Bottom_Btn.MouseMove += this.Move_Left_Btn_MouseMove;
            spaef.Move_Center_Btn.Tag = "Move_Center";
            spaef.Move_Center_Btn.MouseDown += this.Move_Left_Btn_MouseDown;
            spaef.Move_Center_Btn.MouseUp += this.Move_Right_Btn_MouseUp;
            spaef.Move_Center_Btn.MouseMove += this.Move_Left_Btn_MouseMove;

            IWindowsFormsEditorService editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            editorService.DropDownControl(spaef);

            return base.EditValue(context, provider, value);
        }

        #endregion

        #region ˽�з���

        private void Anchor_Left_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_Left");
        }
        private void Anchor_Right_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_Right");
        }
        private void Anchor_Top_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_Top");
        }
        private void Anchor_Bottom_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_Bottom");
        }
        private void Anchor_Center_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("AnchorCenter");
        }

        private void Anchor_LeftTop_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_LeftTop");
        }
        private void Anchor_RightTop_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_RightTop");
        }
        private void Anchor_LeftBottom_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_LeftBottom");
        }
        private void Anchor_RightBottom_Btn_Click(object sender, EventArgs e)
        {
            this.Anchor_Points("Anchor_RightBottom");
        }

        private void Apef_Leave(object sender, EventArgs e)
        {
            this.move_type = "";
            this.move_objectpoint = ComplexityPropertys.PointF.Empty;
            this.move_mousepoint = ComplexityPropertys.PointF.Empty;
        }
        private void Move_Left_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            this.move_type = ((Button)sender).Tag.ToString();
            this.move_objectpoint = new ComplexityPropertys.PointF(this.ab.BackGradualPoint.X * DotsPerInchHelper.DPIScale.XScale, this.ab.BackGradualPoint.Y * DotsPerInchHelper.DPIScale.XScale);
            this.move_mousepoint = ComplexityPropertys.PointF.ConvertFrom(this.ab.PointToClient(Control.MousePosition));
        }
        private void Move_Right_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            this.move_type = "";
            this.move_objectpoint = ComplexityPropertys.PointF.Empty;
            this.move_mousepoint = ComplexityPropertys.PointF.Empty;
        }
        private void Move_Left_Btn_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.move_type != "")
            {
                ComplexityPropertys.PointF point = ComplexityPropertys.PointF.ConvertFrom(this.ab.PointToClient(Control.MousePosition));
                ComplexityPropertys.PointF p = new ComplexityPropertys.PointF(point.X - move_mousepoint.X, point.Y - move_mousepoint.Y);
                ComplexityPropertys.PointF tmp = ComplexityPropertys.PointF.Empty;

                if (this.move_type == "Move_Left" || this.move_type == "Move_Right")
                {
                    tmp = new ComplexityPropertys.PointF((float)Math.Round((this.move_objectpoint.X + p.X) / DotsPerInchHelper.DPIScale.XScale, 2), (float)Math.Round((this.move_objectpoint.Y) / DotsPerInchHelper.DPIScale.XScale, 2));
                }
                else if (this.move_type == "Move_Top" || this.move_type == "Move_Bottom")
                {
                    tmp = new ComplexityPropertys.PointF((float)Math.Round((this.move_objectpoint.X) / DotsPerInchHelper.DPIScale.XScale, 2), (float)Math.Round((this.move_objectpoint.Y + p.Y) / DotsPerInchHelper.DPIScale.XScale, 2));
                }
                else if (this.move_type == "Move_Center")
                {
                    tmp = new ComplexityPropertys.PointF((float)Math.Round((this.move_objectpoint.X + p.X) / DotsPerInchHelper.DPIScale.XScale, 2), (float)Math.Round((this.move_objectpoint.Y + p.Y) / DotsPerInchHelper.DPIScale.XScale, 2));
                }

                PropertyDescriptor pd = TypeDescriptor.GetProperties(ab)[this.fieldStr];
                pd.SetValue(ab, tmp);
            }

        }

        /// <summary>
        /// ͣ����λ
        /// </summary>
        /// <param name="type">ͣ����λ����</param>
        private void Anchor_Points(string type)
        {
            this.move_objectpoint = new ComplexityPropertys.PointF(this.ab.BackGradualPoint.X * DotsPerInchHelper.DPIScale.XScale, this.ab.BackGradualPoint.Y * DotsPerInchHelper.DPIScale.XScale);

            IntPtr hDC = IntPtr.Zero;
            Graphics g = null;
            ControlCommom.GetWindowClientGraphics(this.ab.Handle, out g, out hDC);
            float r = this.ab.BackGradualRadius * DotsPerInchHelper.DPIScale.XScale;
            Size rect_size = Size.Ceiling(new SizeF(r * 2, r * 2));
            g.Dispose();
            WindowNavigate.ReleaseDC(this.ab.Handle, hDC);

            if (type == "Anchor_Left")
            {
                float x = rect_size.Width / 2;
                this.UpdatePointsXY(x - this.move_objectpoint.X, 0);
            }
            else if (type == "Anchor_Right")
            {
                float x = this.ab.ClientRectangle.Right - rect_size.Width / 2;
                this.UpdatePointsXY(x - this.move_objectpoint.X, 0);
            }
            else if (type == "Anchor_Top")
            {
                float y = rect_size.Height / 2;
                this.UpdatePointsXY(0, y - this.move_objectpoint.Y);
            }
            else if (type == "Anchor_Bottom")
            {
                float y = this.ab.ClientRectangle.Bottom - rect_size.Height / 2;
                this.UpdatePointsXY(0, y - this.move_objectpoint.Y);
            }

            else if (type == "Anchor_LeftTop")
            {
                float x = rect_size.Width / 2;
                float y = rect_size.Height / 2;
                this.UpdatePointsXY(x - this.move_objectpoint.X, y - this.move_objectpoint.Y);
            }
            else if (type == "Anchor_RightTop")
            {
                float x = this.ab.ClientRectangle.Right - rect_size.Width / 2;
                float y = rect_size.Height / 2;
                this.UpdatePointsXY(x - this.move_objectpoint.X, y - this.move_objectpoint.Y);
            }
            else if (type == "Anchor_LeftBottom")
            {
                float x = rect_size.Width / 2;
                float y = this.ab.ClientRectangle.Bottom - rect_size.Height / 2;
                this.UpdatePointsXY(x - this.move_objectpoint.X, y - this.move_objectpoint.Y);
            }
            else if (type == "Anchor_RightBottom")
            {
                float x = this.ab.ClientRectangle.Right - rect_size.Width / 2;
                float y = this.ab.ClientRectangle.Bottom - rect_size.Height / 2;
                this.UpdatePointsXY(x - this.move_objectpoint.X, y - this.move_objectpoint.Y);
            }

            else if (type == "Anchor_Center")
            {
                float x = (this.ab.ClientRectangle.Width - rect_size.Width) / 2;
                float y = (this.ab.ClientRectangle.Height - rect_size.Height) / 2;
                this.UpdatePointsXY(x - this.move_objectpoint.X, y - this.move_objectpoint.Y);
            }
        }

        /// <summary>
        /// �޸��ı�ƫ����
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void UpdatePointsXY(float x, float y)
        {
            if (this.ab == null)
                return;

            ComplexityPropertys.PointF tmp = new ComplexityPropertys.PointF((float)Math.Round((this.move_objectpoint.X + x) / DotsPerInchHelper.DPIScale.XScale, 2), (float)Math.Round((this.move_objectpoint.Y + y) / DotsPerInchHelper.DPIScale.XScale, 2));
            PropertyDescriptor pd = TypeDescriptor.GetProperties(this.ab)[this.fieldStr];
            pd.SetValue(this.ab, tmp);
        }

        #endregion

    }

    /// <summary>
    /// ��������״��ť��Ӱ�뾶�������ӱ༭
    /// </summary>
    [Description("��������״��ť��Ӱ�뾶�������ӱ༭")]
    public class AnomalyButtonBackGradualRadiusPositionsEditor : UITypeEditor
    {
        #region �ֶ�

        private AnomalyButtonBackGradualRadiusPositionsEditorForm abbgrpef = null;

        private AnomalyButton ab = null;
        /// <summary>
        /// Ҫ������������
        /// </summary>
        private string fieldStr = "";

        #endregion

        #region ��д

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            //ָ��Ϊģʽ�������Ա༭������
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            this.ab = context.Instance as AnomalyButton;
            this.fieldStr = context.PropertyDescriptor.Name;

            this.abbgrpef = new AnomalyButtonBackGradualRadiusPositionsEditorForm() { AutoScaleMode = AutoScaleMode.None, Size = new Size(200, 24) };

            this.abbgrpef.RadiusPositionsTb.Minimum = 0;
            this.abbgrpef.RadiusPositionsTb.Maximum = (int)Math.Sqrt(Math.Pow(this.ab.Width, 2) + Math.Pow(this.ab.Height, 2)); ;
            this.abbgrpef.RadiusPositionsTb.Value = (int)value;
            this.abbgrpef.RadiusPositionsTb.ValueChanged += this.RadiusPositionsTb_ValueChanged;

            IWindowsFormsEditorService editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            editorService.DropDownControl(this.abbgrpef);

            return base.EditValue(context, provider, value);
        }

        private void RadiusPositionsTb_ValueChanged(object sender, EventArgs e)
        {
            PropertyDescriptor pd = TypeDescriptor.GetProperties(ab)[this.fieldStr];
            pd.SetValue(ab, this.abbgrpef.RadiusPositionsTb.Value);
        }

        #endregion

    }
    /// <summary>
    /// ��������״��ť·���ƶ��༭������
    /// </summary>
    [Description("��������״��ť·���ƶ��༭������")]
    internal class ShapePathPointsAnchorEditorForm : UserControl
    {
        public Button Anchor_Top_Btn;
        public Button Anchor_Bottom_Btn;
        public Button Anchor_Left_Btn;
        public Button Anchor_Right_Btn;

        public Button Anchor_LeftTop_Btn;
        public Button Anchor_RightTop_Btn;
        public Button Anchor_LeftBottom_Btn;
        public Button Anchor_RightBottom_Btn;

        public Button Move_Left_Btn;
        public Button Move_Right_Btn;
        public Button Move_Top_Btn;
        public Button Move_Bottom_Btn;
        public Button Move_Center_Btn;

        public ShapePathPointsAnchorEditorForm()
        {
            this.Anchor_Top_Btn = new Button() { Size = new Size(100, 30), Location = new Point(30, 0), BackColor = Color.FromArgb(205, 220, 57) };
            this.Anchor_Bottom_Btn = new Button() { Size = new Size(100, 30), Location = new Point(30, 130), BackColor = Color.FromArgb(205, 220, 57) };
            this.Anchor_Left_Btn = new Button() { Size = new Size(30, 100), Location = new Point(0, 30), BackColor = Color.FromArgb(205, 220, 57) };
            this.Anchor_Right_Btn = new Button() { Size = new Size(30, 100), Location = new Point(130, 30), BackColor = Color.FromArgb(205, 220, 57) };

            this.Anchor_LeftBottom_Btn = new Button() { Size = new Size(30, 30), Location = new Point(0, 130), BackColor = Color.FromArgb(95, 165, 192) };
            this.Anchor_RightBottom_Btn = new Button() { Size = new Size(30, 30), Location = new Point(130, 130), BackColor = Color.FromArgb(95, 165, 192) };
            this.Anchor_LeftTop_Btn = new Button() { Size = new Size(30, 30), Location = new Point(0, 0), BackColor = Color.FromArgb(95, 165, 192) };
            this.Anchor_RightTop_Btn = new Button() { Size = new Size(30, 30), Location = new Point(130, 0), BackColor = Color.FromArgb(95, 165, 192) };

            this.Move_Left_Btn = new Button() { Size = new Size(30, 30), Location = new Point(30, 65), BackColor = Color.FromArgb(95, 165, 192) };
            this.Move_Right_Btn = new Button() { Size = new Size(30, 30), Location = new Point(100, 65), BackColor = Color.FromArgb(95, 165, 192) };
            this.Move_Top_Btn = new Button() { Size = new Size(30, 30), Location = new Point(65, 30), BackColor = Color.FromArgb(95, 165, 192) };
            this.Move_Bottom_Btn = new Button() { Size = new Size(30, 30), Location = new Point(65, 100), BackColor = Color.FromArgb(95, 165, 192) };
            this.Move_Center_Btn = new Button() { Size = new Size(40, 40), Location = new Point(60, 60), BackColor = Color.FromArgb(205, 220, 57) };

            this.SuspendLayout();

            this.Controls.Add(this.Anchor_RightBottom_Btn);
            this.Controls.Add(this.Anchor_LeftBottom_Btn);
            this.Controls.Add(this.Anchor_RightTop_Btn);
            this.Controls.Add(this.Anchor_LeftTop_Btn);
            this.Controls.Add(this.Move_Bottom_Btn);
            this.Controls.Add(this.Move_Top_Btn);
            this.Controls.Add(this.Move_Right_Btn);
            this.Controls.Add(this.Move_Left_Btn);
            this.Controls.Add(this.Move_Center_Btn);
            this.Controls.Add(this.Anchor_Bottom_Btn);
            this.Controls.Add(this.Anchor_Top_Btn);
            this.Controls.Add(this.Anchor_Right_Btn);
            this.Controls.Add(this.Anchor_Left_Btn);

            this.BackColor = System.Drawing.Color.White;
            this.Margin = new Padding(0);
            this.Padding = new Padding(0);
            this.MaximumSize = new Size(160, 160);
            this.MinimumSize = new Size(160, 160);
            this.Size = new Size(160, 160);

            this.ResumeLayout(false);
        }

    }

    /// <summary>
    /// ��������״��ť��Ӱ�뾶�������ӱ༭������
    /// </summary>
    [Description("��������״��ť��Ӱ�뾶�������ӱ༭������")]
    internal class AnomalyButtonBackGradualRadiusPositionsEditorForm : UserControl
    {
        public TrackBar RadiusPositionsTb;

        public AnomalyButtonBackGradualRadiusPositionsEditorForm()
        {
            this.RadiusPositionsTb = new TrackBar() { Dock = DockStyle.Fill, TickStyle = TickStyle.None };

            this.SuspendLayout();

            this.Controls.Add(this.RadiusPositionsTb);

            this.BackColor = System.Drawing.Color.White;
            this.Margin = new Padding(0);
            this.Padding = new Padding(0);
            this.MaximumSize = new Size(160, 160);
            this.MinimumSize = new Size(160, 160);
            this.Size = new Size(200, 24);

            this.ResumeLayout(false);
        }

    }


}
