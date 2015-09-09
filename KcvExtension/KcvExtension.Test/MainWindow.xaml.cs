using Grabacr07.KanColleViewer.Composition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KcvExtension.Test
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            App.IToolList.ForEach(pugin => AddPlugin(pugin));

            if (tabControl.Items.Count > 0)
                tabControl.SelectedItem = tabControl.Items[0];
        }

        private void AddPlugin(ITool plugin)
        {
            var tabitem = new TabItem
            {
                Header = plugin.Name,
                Content = plugin.View
            };

            tabControl.Items.Add(tabitem);
        }
    }
}
