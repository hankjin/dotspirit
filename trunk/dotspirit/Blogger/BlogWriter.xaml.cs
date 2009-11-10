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
using System.Windows.Shapes;

namespace Blogger
{
    /// <summary>
    /// Interaction logic for BlogWriter.xaml
    /// </summary>
    public partial class BlogWriter : Window
    {
        public BlogWriter()
        {
            InitializeComponent();
        }

        private void btnPublish_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
