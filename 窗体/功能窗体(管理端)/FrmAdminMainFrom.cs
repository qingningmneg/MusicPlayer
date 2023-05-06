using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WinformControlLibraryExtension;

using WinformDemo;

namespace 窗体
{
    public partial class FrmAdminMainFrom : XtraForm
    {
        public FrmAdminMainFrom()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmMainFrom_Load(object sender, EventArgs e)
        {
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem1 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = "音乐管理" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem11 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem1) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "音乐管理", Data = typeof(RadianMenuExtComponentForm), Image = null };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem12 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem1) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "本地音乐", Data = typeof(FisheyeMenuExtForm), Image = null };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem13 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem1) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "最近播放", Data = typeof(SlideMenuExtForm), Image = null };
            menuItem1.Children.Add(menuItem11);
            menuItem1.Children.Add(menuItem12);
            menuItem1.Children.Add(menuItem13);
            menuExt1.Nodes.Add(menuItem1);

            menuExt1.RestMenuNodes();
        }

        private void MenuPanel_NodeClick(object sender, SlideMenuPanelExt.NodeClickEventArgs e)
        {
            if (e.Node.ItemType == SlideMenuPanelExt.NodeTypes.MenuTab)
            {
                var Control_Name = e.Node.Text;
                if (Control_Name == "音乐管理")
                {
                    foreach (var frmChild in this.MdiChildren)
                    {
                        if (frmChild.GetType().FullName == typeof(FrmAdminMusic).FullName)
                        {
                            frmChild.Activate();
                            return;
                        }
                    }
                    var frm = new FrmAdminMusic();
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
        }
    }
}
