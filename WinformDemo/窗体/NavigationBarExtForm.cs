using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinformControlLibraryExtension;

namespace WinformDemo
{
    public partial class NavigationBarExtForm : Form
    {
        public NavigationBarExtForm()
        {
            InitializeComponent();
        }

        private void navigationBarExt7_SelectedIndexChanged(object sender, NavigationBarExt.ItemOperatedEventArgs e)
        {
            MessageBox.Show(e.Item.Text);
        }
    }
}
