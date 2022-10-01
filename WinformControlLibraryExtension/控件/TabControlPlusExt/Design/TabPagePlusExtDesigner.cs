
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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;

namespace WinformControlLibraryExtension.Design
{
    /// <summary>
    /// TabPagePlusExt设计器
    /// </summary>
    [Description("TabPagePlusExt设计器")]
    internal class TabPagePlusExtDesigner : ScrollableControlDesigner
    {
        #region 重写属性

        public override SelectionRules SelectionRules
        {
            get
            {
                return SelectionRules.Moveable;
            }
        }

        #endregion

        public TabPagePlusExtDesigner()
        {
            this.AutoResizeHandles = false;
        }

        #region 重写方法

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            //清除在父容器停靠的智能标记
            DesignerActionService designerActionService = this.GetService(typeof(DesignerActionService)) as DesignerActionService;
            if (designerActionService != null)
            {
                designerActionService.Clear();
            }

        }

        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            this.DrawBorder(pe.Graphics);

            base.OnPaintAdornments(pe);
        }

        public override bool CanBeParentedTo(IDesigner parentDesigner)
        {
            if (parentDesigner != null)
            {
                return parentDesigner.Component is TabControlPlusExt;
            }

            return false;
        }

        protected override ControlBodyGlyph GetControlGlyph(GlyphSelectionType selectionType)
        {
            this.OnSetCursor();
            return new ControlBodyGlyph(Rectangle.Empty, Cursor.Current, (IComponent)this.Control, (ControlDesigner)this);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 绘制边框
        /// </summary>
        /// <param name="graphics"></param>
        protected virtual void DrawBorder(Graphics graphics)
        {
            TabPagePlusExt page = (TabPagePlusExt)this.Control;
            if (page == null || page.Visible == false)
            {
                return;
            }

            Pen borderPen = new Pen((double)this.Control.BackColor.GetBrightness() < 0.5 ? ControlPaint.Light(this.Control.BackColor) : ControlPaint.Dark(this.Control.BackColor))
            {
                DashStyle = DashStyle.Dash
            };
            Rectangle clientRectangle = this.Control.ClientRectangle;
            --clientRectangle.Width;
            --clientRectangle.Height;
            graphics.DrawRectangle(borderPen, clientRectangle);
            borderPen.Dispose();
        }

        /// <summary>
        /// 公开鼠标拖载数据方法
        /// </summary>
        /// <param name="de"></param>
        internal void OnDragDropInternal(DragEventArgs de)
        {
            this.OnDragDrop(de);
        }
        /// <summary>
        /// 公开鼠标拖载数据方法
        /// </summary>
        /// <param name="de"></param>
        internal void OnDragEnterInternal(DragEventArgs de)
        {
            this.OnDragEnter(de);
        }
        /// <summary>
        /// 公开鼠标拖载数据方法
        /// </summary>
        /// <param name="e"></param>
        internal void OnDragLeaveInternal(EventArgs e)
        {
            this.OnDragLeave(e);
        }
        /// <summary>
        /// 公开鼠标拖载数据方法
        /// </summary>
        /// <param name="e"></param>
        internal void OnDragOverInternal(DragEventArgs e)
        {
            this.OnDragOver(e);
        }
        /// <summary>
        /// 公开鼠标拖载数据方法
        /// </summary>
        /// <param name="e"></param>
        internal void OnGiveFeedbackInternal(GiveFeedbackEventArgs e)
        {
            this.OnGiveFeedback(e);
        }

        #endregion
    }
    /// <summary>
    ///  TabPagePlus集合属性编辑窗口扩展(显示帮助文本)
    /// </summary>
    [Description("TabPagePlus集合属性编辑窗口扩展(显示帮助文本)")]
    internal class TabPagePlusCollectionEditorExt : CollectionEditorExt
    {
        public TabPagePlusCollectionEditorExt(Type type) : base(type)
        {

        }

        protected override string GetDisplayText(object value)
        {
            if (value == null)
                return string.Empty;
            PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(value)["Text"];
            if (propertyDescriptor != null && propertyDescriptor.PropertyType == typeof(string))
            {
                string str = (string)propertyDescriptor.GetValue(value);
                if (str != null && str.Length > 0)
                    return str;
            }
            PropertyDescriptor defaultProperty = TypeDescriptor.GetDefaultProperty(this.CollectionType);
            if (defaultProperty != null && defaultProperty.PropertyType == typeof(string))
            {
                string str = (string)defaultProperty.GetValue(value);
                if (str != null && str.Length > 0)
                    return str;
            }
            string str1 = TypeDescriptor.GetConverter(value).ConvertToString(value);
            if (str1 == null || str1.Length == 0)
                str1 = value.GetType().Name;
            return str1;
        }
    }
}
