using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Spirit.Plugin;
using Spirit.Plugins;

namespace Spirit
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private DB db = DB.GetDB();
        private string dbFile = "hankjin.db";
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Load(dbFile);
            //add plugins
            PluginManager pm = PluginManager.Load(new System.IO.DirectoryInfo("D:\\"));
            foreach (IPlugin plugin in pm.GetPlugins())
            {
                this.lvPlugin.Items.Add(plugin.GetName());
            }
            //add external apps
            //add others
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            db.Save(dbFile);
        }


        private void Window_Activated(object sender, EventArgs e)
        {
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            double margin = 5;
            if (this.Left <= 0)
            {
                this.Left = margin - this.Width;
            }
            else if (this.Left + this.Width > System.Windows.SystemParameters.PrimaryScreenWidth)
            {
                this.Left = System.Windows.SystemParameters.PrimaryScreenWidth - margin;
            }
            else if (this.Top <= 0)
            {
                this.Top = margin - this.Height;
            }
            else if (this.Top + this.Height > System.Windows.SystemParameters.PrimaryScreenHeight)
            {
                this.Top = System.Windows.SystemParameters.PrimaryScreenHeight - margin;
            }
        }
        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.Left < 0)
            {
                this.Left = 0;
            }
            else if (this.Left + this.Width > System.Windows.SystemParameters.PrimaryScreenWidth)
            {
                this.Left = System.Windows.SystemParameters.PrimaryScreenWidth - this.Width;
            }
            else if (this.Top < 0)
            {
                this.Top = 0;
            }
            else if (this.Top + this.Height > System.Windows.SystemParameters.PrimaryScreenHeight)
            {
                this.Top = System.Windows.SystemParameters.PrimaryScreenHeight - this.Height;
            }
        }
    }
}
