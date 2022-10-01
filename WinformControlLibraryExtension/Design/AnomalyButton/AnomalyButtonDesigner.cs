
/*****版权***************************************************************

版权：  唧唧复唧唧木兰当户织
作者：  唧唧复唧唧木兰当户织
日期：  2020-10-28
描述：  禁止删除下面的木兰诗,
        博客 https://www.cnblogs.com/tlmbem/ ,
        源码地址 https://gitee.com/tlmbem/hml ,
        授权使用在 https://gitee.com/tlmbem/hml 上有介绍。
	
              	木兰诗
              	
        唧唧复唧唧，木兰当户织。
        不闻机杼声，唯闻女叹息。 
        问女何所思，问女何所忆。
        女亦无所思，女亦无所忆。
        昨夜见军帖，可汗大点兵，
        军书十二卷，卷卷有爷名。
        阿爷无大儿，木兰无长兄，
        愿为市鞍马，从此替爷征。 
        东市买骏马，西市买鞍鞯，
        南市买辔头，北市买长鞭。
        旦辞爷娘去，暮宿黄河边，
        不闻爷娘唤女声，但闻黄河流水鸣溅溅。
        旦辞黄河去，暮至黑山头，
        不闻爷娘唤女声，但闻燕山胡骑鸣啾啾。 
        万里赴戎机，关山度若飞。
        朔气传金柝，寒光照铁衣。
        将军百战死，壮士十年归。 
        归来见天子，天子坐明堂。
        策勋十二转，赏赐百千强。
        可汗问所欲，木兰不用尚书郎，
        愿驰千里足，送儿还故乡。
        爷娘闻女来，出郭相扶将；
        阿姊闻妹来，当户理红妆；
        小弟闻姊来，磨刀霍霍向猪羊。
        开我东阁门，坐我西阁床，
        脱我战时袍，著我旧时裳。
        当窗理云鬓，对镜帖花黄。
        出门看火伴，火伴皆惊忙，
        同行十二年，不知木兰是女郎。 
        
*********************************************************************/

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Collections.Generic;

namespace WinformControlLibraryExtension.Design
{
    /// <summary>
    /// 不规则形状按钮控件设计模式行为
    /// </summary>
    [Description("不规则形状按钮控件设计模式行为")]
    public class AnomalyButtonDesigner : ControlDesigner
    {
        #region 重写属性

        public DesignerVerbCollection verbs = null;
        /// <summary>
        /// 右键菜单集合
        /// </summary>
        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (this.verbs == null)
                {
                    this.verbs = new DesignerVerbCollection();
                    this.verbs.Add(new DesignerVerb("删除选中编辑点", new EventHandler(this.Delete)) { Enabled = false });
                    this.verbs.Add(new DesignerVerb("向左边新增编辑点", new EventHandler(this.AddToLeft)) { Enabled = false });
                    this.verbs.Add(new DesignerVerb("向右边新增编辑点", new EventHandler(this.AddToRight)) { Enabled = false });
                }
                if (this.rightMenuSelectindex == -1)
                {
                    for (int i = 0; i < this.verbs.Count; i++)
                    {
                        if (this.verbs[i].Text == "删除选中编辑点" || this.verbs[i].Text == "向左边新增编辑点" || this.verbs[i].Text == "向右边新增编辑点")
                        {
                            this.verbs[i].Enabled = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < this.verbs.Count; i++)
                    {
                        if (this.verbs[i].Text == "删除选中编辑点" || this.verbs[i].Text == "向左边新增编辑点" || this.verbs[i].Text == "向右边新增编辑点")
                        {
                            this.verbs[i].Enabled = true;
                        }
                    }
                }

                return this.verbs;
            }
        }

        #endregion

        #region 字段

        /// <summary>
        /// 鼠标在路径圆点按下时鼠标的坐标
        /// </summary>
        private PointF mouseDownPoint = PointF.Empty;
        /// <summary>
        /// 鼠标在路径圆点按下时圆点的坐标
        /// </summary>
        private PointF objectDownPoint = PointF.Empty;

        /// <summary>
        /// 右键菜单属于的路径圆点索引
        /// </summary>
        private int rightMenuSelectindex = -1;

        #endregion

        #region 扩展

        private const int WM_LBUTTONDOWN = 0x0201; //按下鼠标左键 
        private const int WM_LBUTTONUP = 0x0202; //释放鼠标左键
        private const int WM_RBUTTONDOWN = 0x0204; //按下鼠标右键 
        public const int WM_RBUTTONUP = 0x0205; //释放鼠标右键 
        private const int WM_MOUSEMOVE = 0x0200;//鼠标移动

        #endregion

        public AnomalyButtonDesigner()
        {
            this.AutoResizeHandles = true;
        }

        #region 

        /// <summary>
        /// 当设计器正在管理的控件绘制了它的图面时接收调用，这样设计器就可以在控件顶部绘制任意附加装饰
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            Pen border_pen = new Pen((double)this.Control.BackColor.GetBrightness() < 0.5 ? ControlPaint.Light(this.Control.BackColor) : ControlPaint.Dark(this.Control.BackColor)) { DashStyle = DashStyle.Dash };
            pe.Graphics.DrawRectangle(border_pen, new Rectangle(this.Control.ClientRectangle.X, this.Control.ClientRectangle.Y, this.Control.ClientRectangle.Width - 1, this.Control.ClientRectangle.Height - 1));
            border_pen.Dispose();

            base.OnPaintAdornments(pe);
        }

        /// <summary>
        /// 指示该控件是否应处理在指定点单击鼠标的操作
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        protected override bool GetHitTest(Point point)
        {
            return false;
        }

        /// <summary>
        /// 在每次需要设置光标时接收调用
        /// </summary>
        protected override void OnSetCursor()
        {
            base.OnSetCursor();

            if (Cursor.Current != Cursors.Arrow)
            {
                Cursor.Current = Cursors.Arrow;
            }
        }

        /// <summary>
        /// 创建控件
        /// </summary>
        protected override void OnCreateHandle()
        {
            base.OnCreateHandle();

            this.Control.LostFocus += this.Control_LostFocus;
        }

        /// <summary>
        /// 处理 Windows 消息，并可以选择将其路由到控件。
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN)
            {
                this.OnMouseLeftDown();
            }
            else if (m.Msg == WM_LBUTTONUP)
            {
                this.OnMouseLeftUp();
            }
            else if (m.Msg == WM_RBUTTONUP)
            {
                this.OnMouseRightUp();
            }
            else if (m.Msg == WM_MOUSEMOVE)
            {
                this.OnMouseMove();
                AnomalyButton ab = (AnomalyButton)this.Control;
                if (ab.shapePathPointMouseDownIndex > -1 && ab.shapePathPointMouseDownIndex < ab.shapePathPointObjectList.Count)
                {
                    return;
                }
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// 控件失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_LostFocus(object sender, EventArgs e)
        {
            AnomalyButton ab = (AnomalyButton)this.Control;

            if (ab.shapePathPointMouseDownIndex != -1)
            {
                ab.shapePathPointMouseDownIndex = -1;
                ab.Invalidate();
            }
        }

        /// <summary>
        /// 鼠标进入控件可视区域
        /// </summary>
        protected override void OnMouseEnter()
        {
            base.OnMouseEnter();

            AnomalyButton ab = (AnomalyButton)this.Control;
            PointF point = ab.PointToClient(Control.MousePosition);

            int index = -1;
            for (int i = 0; i < ab.shapePathPointObjectList.Count; i++)
            {
                if (ab.shapePathPointObjectList[i].RealityRect.Contains(point))
                {
                    index = i;
                    break;
                }
            }

            if (ab.shapePathPointMouseEnterIndex != index)
            {
                ab.shapePathPointMouseEnterIndex = index;
                ab.Invalidate();
            }
        }

        /// <summary>
        /// 鼠标离开控件可视区域
        /// </summary>
        protected override void OnMouseLeave()
        {
            base.OnMouseEnter();

            AnomalyButton ab = (AnomalyButton)this.Control;
            if (ab.shapePathPointMouseEnterIndex != -1)
            {
                ab.shapePathPointMouseEnterIndex = -1;
                ab.Invalidate();
            }
        }

        /// <summary>
        /// 鼠标在控件可视区域按下左键
        /// </summary>
        protected virtual void OnMouseLeftDown()
        {
            AnomalyButton ab = (AnomalyButton)this.Control;
            PointF point = ab.PointToClient(Control.MousePosition);

            int index = -1;
            for (int i = 0; i < ab.shapePathPointObjectList.Count; i++)
            {
                if (ab.shapePathPointObjectList[i].RealityRect.Contains(point))
                {
                    index = i;
                    break;
                }
            }

            if (ab.shapePathPointMouseDownIndex != index)
            {
                ab.shapePathPointMouseDownIndex = index;
                if (index != -1)
                {
                    this.objectDownPoint = ab.shapePathPointObjectList[ab.shapePathPointMouseDownIndex].RealityPoint;
                    this.mouseDownPoint = point;
                    ab.Invalidate();
                }
            }

            this.rightMenuSelectindex = -1;
            if (this.verbs != null)
            {
                for (int i = 0; i < this.verbs.Count; i++)
                {
                    if (this.verbs[i].Text == "删除选中编辑点" || this.verbs[i].Text == "向左边新增编辑点" || this.verbs[i].Text == "向右边新增编辑点")
                    {
                        this.verbs[i].Enabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// 鼠标在控件可视区域按下左键后释放
        /// </summary>
        protected virtual void OnMouseLeftUp()
        {
            AnomalyButton ab = (AnomalyButton)this.Control;
            if (ab.shapePathPointMouseDownIndex != -1)
            {
                ab.shapePathPointMouseDownIndex = -1;
                ab.Invalidate();
            }
        }

        /// <summary>
        /// 鼠标在控件可视区域按下右键后释放
        /// </summary>
        protected virtual void OnMouseRightUp()
        {
            AnomalyButton ab = (AnomalyButton)this.Control;
            PointF point = ab.PointToClient(Control.MousePosition);

            this.rightMenuSelectindex = -1;
            for (int i = 0; i < ab.shapePathPointObjectList.Count; i++)
            {
                if (ab.shapePathPointObjectList[i].RealityRect.Contains(point))
                {
                    this.rightMenuSelectindex = i;
                    break;
                }
            }

            if (this.rightMenuSelectindex == -1)
            {
                if (this.verbs != null)
                {
                    for (int i = 0; i < this.verbs.Count; i++)
                    {
                        if (this.verbs[i].Text == "删除选中编辑点" || this.verbs[i].Text == "向左边新增编辑点" || this.verbs[i].Text == "向右边新增编辑点")
                        {
                            this.verbs[i].Enabled = false;
                        }
                    }
                }
            }
            else
            {
                if (this.verbs != null)
                {
                    for (int i = 0; i < this.verbs.Count; i++)
                    {
                        if (this.verbs[i].Text == "删除选中编辑点" || this.verbs[i].Text == "向左边新增编辑点" || this.verbs[i].Text == "向右边新增编辑点")
                        {
                            this.verbs[i].Enabled = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 鼠标移动
        /// </summary>
        protected virtual void OnMouseMove()
        {
            AnomalyButton ab = (AnomalyButton)this.Control;
            PointF point = ab.PointToClient(Control.MousePosition);

            //鼠标移动某一个点
            if (ab.shapePathPointMouseDownIndex > -1 && ab.shapePathPointMouseDownIndex < ab.shapePathPointObjectList.Count)
            {
                float x = point.X - this.mouseDownPoint.X;
                float y = point.Y - this.mouseDownPoint.Y;
                if (x != 0 || y != 0)
                {
                    PointF[] tmpArr = ab.GetShapePoints();
                    tmpArr[ab.shapePathPointMouseDownIndex] = new PointF((float)Math.Round((this.objectDownPoint.X + x) / DotsPerInchHelper.DPIScale.XScale, 2), (float)Math.Round((this.objectDownPoint.Y + y) / DotsPerInchHelper.DPIScale.XScale, 2));

                    PropertyDescriptor pd = TypeDescriptor.GetProperties(ab)["ShapePoints"];
                    pd.SetValue(ab, ab.SerializeShapePoints(tmpArr));
                }
            }
            //鼠标进入某一个点
            else
            {
                int index = -1;
                for (int i = 0; i < ab.shapePathPointObjectList.Count; i++)
                {
                    if (ab.shapePathPointObjectList[i].RealityRect.Contains(point))
                    {
                        index = i;
                    }
                }

                if (ab.shapePathPointMouseEnterIndex != index)
                {
                    ab.shapePathPointMouseEnterIndex = index;
                    ab.Invalidate();
                }
            }

        }

        #endregion

        #region 右键菜单事件

        /// <summary>
        /// 删除选中路径点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete(object sender, EventArgs e)
        {
            AnomalyButton ab = (AnomalyButton)this.Control;
            PointF[] pointArr_old = ab.GetShapePoints();
            PointF[] pointArr_new = new PointF[pointArr_old.Length - 1];

            if (pointArr_old.Length > 1)
            {
                for (int i = 0; i < pointArr_old.Length; i++)
                {
                    if (i != this.rightMenuSelectindex)
                    {
                        pointArr_new[(i < this.rightMenuSelectindex) ? i : i - 1] = pointArr_old[i];
                    }
                }
            }

            PropertyDescriptor pd = TypeDescriptor.GetProperties(ab)["ShapePoints"];
            pd.SetValue(ab, ab.SerializeShapePoints(pointArr_new));

            this.rightMenuSelectindex = -1;
        }

        /// <summary>
        /// 新增一个点到选中的路径点的左边
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddToLeft(object sender, EventArgs e)
        {
            AnomalyButton ab = (AnomalyButton)this.Control;
            PointF[] pointArr_old = ab.GetShapePoints();
            PointF[] pointArr_new = new PointF[pointArr_old.Length + 1];

            for (int i = 0; i < pointArr_old.Length; i++)
            {
                if (i < this.rightMenuSelectindex)
                {
                    pointArr_new[i] = pointArr_old[i];
                }
                else if (i == this.rightMenuSelectindex)
                {
                    float x = 0;
                    float y = 0;
                    if (i == 0)
                    {
                        x = pointArr_old[i].X + (pointArr_old[pointArr_old.Length - 1].X - pointArr_old[i].X) / 2;
                        y = pointArr_old[i].Y + (pointArr_old[pointArr_old.Length - 1].Y - pointArr_old[i].Y) / 2;
                    }
                    else if (pointArr_old.Length < 2)
                    {
                        x = pointArr_old[i].X - ab.ShapePathPointRadius * 3;
                        y = pointArr_old[i].Y;
                    }
                    else if (i > 0)
                    {
                        x = pointArr_old[i].X - (pointArr_old[i].X - pointArr_old[i - 1].X) / 2;
                        y = pointArr_old[i].Y - (pointArr_old[i].Y - pointArr_old[i - 1].Y) / 2;
                    }
                    pointArr_new[i] = new PointF(x, y);
                    pointArr_new[i + 1] = pointArr_old[i];
                }
                else
                {
                    pointArr_new[i + 1] = pointArr_old[i];
                }
            }

            PropertyDescriptor pd = TypeDescriptor.GetProperties(ab)["ShapePoints"];
            pd.SetValue(ab, ab.SerializeShapePoints(pointArr_new));
        }

        /// <summary>
        /// 新增一个点到选中的路径点的右边
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddToRight(object sender, EventArgs e)
        {
            AnomalyButton ab = (AnomalyButton)this.Control;
            PointF[] pointArr_old = ab.GetShapePoints();
            PointF[] pointArr_new = new PointF[pointArr_old.Length + 1];

            for (int i = 0; i < pointArr_old.Length; i++)
            {
                if (i < this.rightMenuSelectindex)
                {
                    pointArr_new[i] = pointArr_old[i];
                }
                else if (i == this.rightMenuSelectindex)
                {
                    float x = 0;
                    float y = 0;
                    if (pointArr_old.Length < 2)
                    {
                        x = pointArr_old[i].X + ab.ShapePathPointRadius * 3;
                        y = pointArr_old[i].Y;
                    }
                    else if (i < pointArr_old.Length - 1)
                    {
                        x = pointArr_old[i].X + (pointArr_old[i + 1].X - pointArr_old[i].X) / 2;
                        y = pointArr_old[i].Y + (pointArr_old[i + 1].Y - pointArr_old[i].Y) / 2;
                    }
                    else if (i == pointArr_old.Length - 1)
                    {
                        x = pointArr_old[i].X - (pointArr_old[i].X - pointArr_old[0].X) / 2;
                        y = pointArr_old[i].Y - (pointArr_old[i].Y - pointArr_old[0].Y) / 2;
                    }
                    pointArr_new[i] = pointArr_old[i];
                    pointArr_new[i + 1] = new PointF(x, y);
                }
                else
                {
                    pointArr_new[i + 1] = pointArr_old[i];
                }
            }

            PropertyDescriptor pd = TypeDescriptor.GetProperties(ab)["ShapePoints"];
            pd.SetValue(ab, ab.SerializeShapePoints(pointArr_new));
        }

        #endregion
    }

}
