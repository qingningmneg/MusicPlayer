using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using WinformControlLibraryExtension;

namespace WinformDemo
{
    public partial class TabControlPlusExtForm : Form
    {

        public TabControlPlusExtForm()
        {
            InitializeComponent();

            this.tabControlPlusExt1.GlobalCustomButttons["add"].GlobalCustomButttonClick += this.tabControlPlusExt1_add__GlobalCustomButttonClick;
            this.tabControlPlusExt1.GlobalCustomButttons["delete"].GlobalCustomButttonClick += this.tabControlPlusExt1_delete__GlobalCustomButttonClick;
            this.tabControlPlusExt1.GlobalCustomButttons["drop"].GlobalCustomButttonClick += this.tabControlPlusExt1_drop__GlobalCustomButttonClick;
        }

        private void tabControlPlusExt1_add__GlobalCustomButttonClick(object sender, WinformControlLibraryExtension.TabControlPlusExt.GlobalCustomButttonEventArgs e)
        {
            TabControlPlusExt tabControl = (TabControlPlusExt)sender;
            TabPagePlusExt tabPage = new TabPagePlusExt("新页面" + tabControl.TabCount.ToString());
            tabControl.TabPages.Add(tabPage);
        }

        private void tabControlPlusExt1_delete__GlobalCustomButttonClick(object sender, WinformControlLibraryExtension.TabControlPlusExt.GlobalCustomButttonEventArgs e)
        {
            TabControlPlusExt tabControl = (TabControlPlusExt)sender;
            if (tabControl.SelectedIndex < 0)
            {
                MessageBox.Show("请选择要删除的选项", "提示");
                return;
            }
            if (MessageBox.Show("是否要删除“" + tabControl.SelectedTab.Text + "”", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tabControl.TabPages.Remove(tabControl.SelectedTab);
            }
        }

        private void tabControlPlusExt1_drop__GlobalCustomButttonClick(object sender, WinformControlLibraryExtension.TabControlPlusExt.GlobalCustomButttonEventArgs e)
        {
            TabControlPlusExt tabControl = (TabControlPlusExt)sender;
            if (tabControl.TabCount > 0)
            {
                RectangleF rect = e.GlobalCustomButtton.GetRectangle();
                tabControl.ShowDropDownPanel(rect);
            }
        }

        private void tabControlPlusExt1_TabItemInterchangeing(object sender, TabControlPlusExt.TabItemInterchangeingEventArgs e)
        {
            if (MessageBox.Show("是否要互换“" + e.CurrentTabPage.Text + "”和“" + e.TargetTabPage.Text + "”的位置", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
