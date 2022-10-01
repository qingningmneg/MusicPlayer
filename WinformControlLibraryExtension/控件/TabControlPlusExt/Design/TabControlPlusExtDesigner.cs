
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WinformControlLibraryExtension.Design
{
    /// <summary>
    /// TabControlPlusExt设计器
    /// </summary>
    [Description("TabControlPlusExt设计器")]
    internal class TabControlPlusExtDesigner : ParentControlDesigner
    {
        #region 字段

        private bool tabControlSelected;//TabControlPlusExt在设计器是否已选中
        private bool forwardOnDrag;//是否在拖动控件
        private bool addingOnInitialize;//通知 System.ComponentModel.Design.IComponentChangeService 此组件即将被更改

        private DesignerVerbCollection verbs;//智能标记
        private DesignerVerb removeVerb;//添加选项卡
        private DesignerVerb addVerb;//移除选项卡

        #endregion

        #region 重写属性

        /// <summary>
        /// 获取一个值，该值指示选择的控件是否重新设置为父级。
        /// </summary>
        protected override bool AllowControlLasso
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 获取一个值，该值指示在拖动操作期间 System.Windows.Forms.Design.ControlDesigner 是否允许按对齐线对齐。
        /// </summary>
        public override bool ParticipatesWithSnapLines
        {
            get
            {
                if (!this.forwardOnDrag)
                {
                    return false;
                }
                TabPagePlusExtDesigner selectedTabPageDesigner = this.GetSelectedTabPageDesigner();
                if (selectedTabPageDesigner != null)
                {
                    return selectedTabPageDesigner.ParticipatesWithSnapLines;
                }
                return true;
            }
        }

        /// <summary>
        /// 智能标记
        /// </summary>
        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (this.verbs == null)
                {
                    this.addVerb = new DesignerVerb("添加选项卡", new EventHandler(this.OnAdd));
                    this.removeVerb = new DesignerVerb("移除选项卡", new EventHandler(this.OnRemove));

                    this.verbs = new DesignerVerbCollection();
                    this.verbs.Add(this.addVerb);
                    this.verbs.Add(this.removeVerb);
                }
                if (this.Control != null)
                {
                    this.removeVerb.Enabled = this.Control.Controls.Count > 0;
                }
                return this.verbs;
            }
        }

        #endregion

        #region 重写方法

        /// <summary>
        /// 指示指定的控件是否可以是由此设计器管理的控件的子级。
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public override bool CanParent(Control control)
        {
            if (control is TabPagePlusExt)
            {
                return !this.Control.Contains(control);
            }
            return false;
        }

        /// <summary>
        /// 指示该控件是否应处理在指定点单击鼠标的操作。
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        protected override bool GetHitTest(Point point)
        {
            if (this.tabControlSelected == false)
            {
                return false;
            }

            TabControlPlusExt tabControl = (TabControlPlusExt)this.Control;

            Point pt = this.Control.PointToClient(point);
            if (tabControl.JudgePointInItem(pt) || tabControl.JudgePointNavigationButton(pt))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 视图设计器创建TabControlPlusExt控件
        /// </summary>
        /// <param name="tool"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="hasLocation"></param>
        /// <param name="hasSize"></param>
        /// <returns></returns>
        protected override IComponent[] CreateToolCore(ToolboxItem tool, int x, int y, int width, int height, bool hasLocation, bool hasSize)
        {
            TabControlPlusExt tabControl = (TabControlPlusExt)this.Control;
            if (tabControl.SelectedTab == null)
            {
                throw new ArgumentException(String.Format("不能添加\'{0}\'到TabControlPlusExt。只有TabPagePlusExt可以直接添加到TabControlPlusExt中。", tool.DisplayName));
            }

            IDesignerHost designerHost = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            if (designerHost != null)
            {
                ParentControlDesigner.InvokeCreateTool((ParentControlDesigner)designerHost.GetDesigner((IComponent)tabControl.SelectedTab), tool);
            }
            return (IComponent[])null;
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            this.AutoResizeHandles = true;

            ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
            if (selectionService != null)
            {
                selectionService.SelectionChanged += new EventHandler(this.OnSelectionChanged);
            }

            IComponentChangeService componentChangeService = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
            if (componentChangeService != null)
            {
                componentChangeService.ComponentChanged += new ComponentChangedEventHandler(this.OnComponentChanged);
            }

            TabControlPlusExt tabControl = component as TabControlPlusExt;
            if (tabControl != null)
            {
                tabControl.SelectedIndexChanged += new TabControlPlusExt.TabItemOperatedEventHandler(this.OnTabSelectedIndexChanged);
            }

        }

        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);

            try
            {
                this.addingOnInitialize = true;
                this.OnAdd((object)this, EventArgs.Empty);
                this.OnAdd((object)this, EventArgs.Empty);
            }
            finally
            {
                this.addingOnInitialize = false;
            }
            MemberDescriptor member = (MemberDescriptor)TypeDescriptor.GetProperties((object)this.Component)["Controls"];
            this.RaiseComponentChanging(member);
            this.RaiseComponentChanged(member, (object)null, (object)null);

            TabControlPlusExt tabControl = (TabControlPlusExt)this.Component;
            if (tabControl != null)
            {
                if (tabControl.TabCount > 0)
                {
                    tabControl.SelectedIndex = 0;
                }
                else
                {
                    tabControl.SelectedIndex = -1;
                }
            }
        }

        /// <summary>
        /// 绘制边框
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            TabControlPlusExt tabControl = (TabControlPlusExt)this.Control;
            if (tabControl == null || tabControl.Visible == false || tabControl.TabCount > 0)
                return;

            Pen borderPen = new Pen((double)this.Control.BackColor.GetBrightness() < 0.5 ? ControlPaint.Light(this.Control.BackColor) : ControlPaint.Dark(this.Control.BackColor)) { DashStyle = DashStyle.Dash };
            Rectangle clientRectangle = this.Control.ClientRectangle;
            --clientRectangle.Width;
            --clientRectangle.Height;
            pe.Graphics.DrawRectangle(borderPen, clientRectangle);
            borderPen.Dispose();

            base.OnPaintAdornments(pe);
        }

        #endregion

        #region 方法

        /// <summary>
        /// 组件更改后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
        {
            // 修改智能标记的启用状态
            if (this.removeVerb != null)
            {
                this.removeVerb.Enabled = this.Control.Controls.Count > 0;
            }
        }

        /// <summary>
        /// 视图设计器选中控件更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectionChanged(object sender, EventArgs e)
        {
            this.tabControlSelected = false;
            ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
            if (selectionService == null)
            {
                return;
            }

            System.Collections.ICollection selectedComponents = selectionService.GetSelectedComponents();//获取设计器所有选中的控件
            TabControlPlusExt parent = (TabControlPlusExt)this.Component;
            foreach (object comp in (System.Collections.IEnumerable)selectedComponents)
            {
                if (comp == parent)
                {
                    this.tabControlSelected = true;
                }
                TabPagePlusExt tabPageOfComponent = TabControlPlusExtDesigner.GetTabPageOfComponent(parent, comp);//获取视图设计器TabControlPlusExt选中的TabPagePlusExt
                if (tabPageOfComponent != null && tabPageOfComponent.Parent == parent)
                {
                    this.tabControlSelected = false;
                    parent.SelectedTab = tabPageOfComponent;

                    tabPageOfComponent.Refresh();
                    break;
                }
            }
        }

        /// <summary>
        /// TabControlPlusExt选项卡选中更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTabSelectedIndexChanged(object sender, EventArgs e)
        {
            ISelectionService selectionService1 = (ISelectionService)this.GetService(typeof(ISelectionService));
            if (selectionService1 == null)
            {
                return;
            }

            System.Collections.ICollection selectedComponents = selectionService1.GetSelectedComponents();
            TabControlPlusExt parent = (TabControlPlusExt)this.Component;
            bool flag = false;
            foreach (object comp in (System.Collections.IEnumerable)selectedComponents)
            {
                TabPagePlusExt tabPageOfComponent = TabControlPlusExtDesigner.GetTabPageOfComponent(parent, comp);
                if (tabPageOfComponent != null && tabPageOfComponent.Parent == parent && tabPageOfComponent == parent.SelectedTab)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                return;
            }

            selectionService1.SetSelectedComponents((System.Collections.ICollection)new object[] { (object)this.Component });
        }

        /// <summary>
        /// 添加一个选项卡事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eevent"></param>
        private void OnAdd(object sender, EventArgs eevent)
        {
            IDesignerHost designerHost1 = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            if (designerHost1 == null)
            {
                return;
            }

            DesignerTransaction designerTransaction = (DesignerTransaction)null;//用于设计器撤销、重做的历史记录功能
            try
            {
                TabControlPlusExt tabControl = (TabControlPlusExt)this.Component;

                try
                {
                    designerTransaction = designerHost1.CreateTransaction(String.Format("添加选项卡到 \"{0}\"", tabControl.Site.Name));
                }
                catch (CheckoutException ex)
                {
                    if (ex == CheckoutException.Canceled)
                    {
                        return;
                    }
                    throw ex;
                }

                MemberDescriptor member = (MemberDescriptor)TypeDescriptor.GetProperties((object)tabControl)["Controls"];
                TabPagePlusExt tabPage = (TabPagePlusExt)designerHost1.CreateComponent(typeof(TabPagePlusExt));
                if (this.addingOnInitialize == false)
                {
                    this.RaiseComponentChanging(member);
                }
                tabPage.Padding = new Padding(3);
                string str = (string)null;
                PropertyDescriptor propertyDescriptor1 = TypeDescriptor.GetProperties((object)tabPage)["Name"];
                if (propertyDescriptor1 != null && propertyDescriptor1.PropertyType == typeof(string))
                {
                    str = (string)propertyDescriptor1.GetValue((object)tabPage);
                }
                if (str != null)
                {
                    PropertyDescriptor propertyDescriptor2 = TypeDescriptor.GetProperties((object)tabPage)["Text"];
                    if (propertyDescriptor2 != null)
                    {
                        propertyDescriptor2.SetValue((object)tabPage, (object)str);
                    }
                }

                tabControl.Controls.Add((Control)tabPage);
                tabControl.SelectedIndex = tabControl.TabCount - 1;
                this.RaiseComponentChanged(member, (object)null, (object)null);
            }
            finally
            {
                if (designerTransaction != null)
                {
                    designerTransaction.Commit();
                }
            }
        }

        /// <summary>
        /// 移除一个选项卡事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eevent"></param>
        private void OnRemove(object sender, EventArgs eevent)
        {
            IDesignerHost designerHost1 = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            if (designerHost1 == null)
            {
                return;
            }

            TabControlPlusExt tabControl = (TabControlPlusExt)this.Component;
            if (tabControl == null || tabControl.TabPages.Count == 0)
            {
                return;
            }

            DesignerTransaction designerTransaction = (DesignerTransaction)null;//用于设计器撤销、重做的历史记录功能
            try
            {
                MemberDescriptor member = (MemberDescriptor)TypeDescriptor.GetProperties((object)this.Component)["Controls"];
                TabPagePlusExt selectedTab = tabControl.SelectedTab;

                try
                {
                    designerTransaction = designerHost1.CreateTransaction(String.Format("添加选项卡 \"{0}\" 来自 \"{1}\" ", selectedTab.Name, tabControl.Site.Name));
                    this.RaiseComponentChanging(member);
                }
                catch (CheckoutException ex)
                {
                    if (ex == CheckoutException.Canceled)
                    {
                        return;
                    }
                    throw ex;
                }

                designerHost1.DestroyComponent((IComponent)selectedTab);
                this.RaiseComponentChanged(member, (object)null, (object)null);
            }
            finally
            {
                if (designerTransaction != null)
                {
                    designerTransaction.Commit();
                }
            }
        }

        /// <summary>
        /// 获取视图设计器TabControlPlusExt选中的TabPagePlusExt
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="comp"></param>
        /// <returns></returns>
        internal static TabPagePlusExt GetTabPageOfComponent(TabControlPlusExt parent, object comp)
        {
            if (!(comp is Control))
            {
                return (TabPagePlusExt)null;
            }
            for (Control control = (Control)comp; control != null; control = control.Parent)
            {
                TabPagePlusExt tabPage = control as TabPagePlusExt;
                if (tabPage != null && tabPage.Parent == parent)
                {
                    return tabPage;
                }
            }
            return (TabPagePlusExt)null;
        }

        /// <summary>
        /// 获取选中的TabPagePlusExt的TabPagePlusExtDesigner设计器
        /// </summary>
        /// <returns></returns>
        private TabPagePlusExtDesigner GetSelectedTabPageDesigner()
        {
            TabPagePlusExtDesigner tabPageDesigner = (TabPagePlusExtDesigner)null;
            TabPagePlusExt selectedTab = ((TabControlPlusExt)this.Component).SelectedTab;
            if (selectedTab != null)
            {
                IDesignerHost designerHost = (IDesignerHost)this.GetService(typeof(IDesignerHost));
                if (designerHost != null)
                    tabPageDesigner = designerHost.GetDesigner((IComponent)selectedTab) as TabPagePlusExtDesigner;
            }
            return tabPageDesigner;
        }

        #endregion

        #region 拖载

        protected override void OnDragEnter(DragEventArgs de)
        {
            this.forwardOnDrag = true;
            if (this.forwardOnDrag)
            {
                TabPagePlusExtDesigner selectedTabPageDesigner = this.GetSelectedTabPageDesigner();
                if (selectedTabPageDesigner == null)
                {
                    return;
                }
                selectedTabPageDesigner.OnDragEnterInternal(de);//通知TabPagePlusExtDesigner拖载操作
            }
            else
            {
                base.OnDragEnter(de);
            }
        }

        protected override void OnDragDrop(DragEventArgs de)
        {
            if (this.forwardOnDrag)
            {
                TabPagePlusExtDesigner selectedTabPageDesigner = this.GetSelectedTabPageDesigner();
                if (selectedTabPageDesigner != null)
                {
                    selectedTabPageDesigner.OnDragDropInternal(de);//通知TabPagePlusExtDesigner拖载操作
                }
            }
            else
            {
                base.OnDragDrop(de);
            }
            this.forwardOnDrag = false;
        }

        protected override void OnDragLeave(EventArgs e)
        {
            if (this.forwardOnDrag)
            {
                TabPagePlusExtDesigner selectedTabPageDesigner = this.GetSelectedTabPageDesigner();
                if (selectedTabPageDesigner != null)
                {
                    selectedTabPageDesigner.OnDragLeaveInternal(e);//通知TabPagePlusExtDesigner拖载操作
                }
            }
            else
            {
                base.OnDragLeave(e);
            }
            this.forwardOnDrag = false;
        }

        protected override void OnDragOver(DragEventArgs de)
        {
            if (this.forwardOnDrag)
            {
                TabControlPlusExt tabControl = (TabControlPlusExt)this.Control;
                if (tabControl.PageMainDisplayRectangle.Contains(this.Control.PointToClient(new Point(de.X, de.Y))) == false)
                {
                    de.Effect = DragDropEffects.None;
                }
                else
                {
                    TabPagePlusExtDesigner selectedTabPageDesigner = this.GetSelectedTabPageDesigner();
                    if (selectedTabPageDesigner == null)
                    {
                        return;
                    }
                    selectedTabPageDesigner.OnDragOverInternal(de);//通知TabPagePlusExtDesigner拖载操作
                }
            }
            else
            {
                base.OnDragOver(de);
            }
        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            if (this.forwardOnDrag)//通知TabPagePlusExtDesigner拖载操作
            {
                TabPagePlusExtDesigner selectedTabPageDesigner = this.GetSelectedTabPageDesigner();
                if (selectedTabPageDesigner == null)
                {
                    return;
                }
                selectedTabPageDesigner.OnGiveFeedbackInternal(e);
            }
            else
            {
                base.OnGiveFeedback(e);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
                if (selectionService != null)
                {
                    selectionService.SelectionChanged -= new EventHandler(this.OnSelectionChanged);
                }
                IComponentChangeService componentChangeService = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
                if (componentChangeService != null)
                {
                    componentChangeService.ComponentChanged -= new ComponentChangedEventHandler(this.OnComponentChanged);
                }
                TabControl tabControl = this.Control as TabControl;
                if (tabControl != null)
                {
                    tabControl.SelectedIndexChanged -= new EventHandler(this.OnTabSelectedIndexChanged);
                }
            }
            base.Dispose(disposing);
        }

        #endregion

    }

    /// <summary>
    /// TabControlPlus子控件集合属性编辑窗口扩展
    /// </summary>
    [Description("TabControlPlus子控件集合属性编辑窗口扩展")]
    internal class TabPagePlusExtControlCollectionEditor : CollectionEditor
    {
        public TabPagePlusExtControlCollectionEditor() : base(typeof(TabControlPlusExt.TabPagePlusCollection))
        {

        }

        protected override object SetItems(object editValue, object[] value)
        {
            TabControlPlusExt tabControl = this.Context.Instance as TabControlPlusExt;
            if (tabControl != null)
                tabControl.SuspendLayout();
            object obj = base.SetItems(editValue, value);
            if (tabControl != null)
                tabControl.ResumeLayout();
            return obj;
        }

    }
}
