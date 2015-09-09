using Grabacr07.KanColleViewer.Composition;
using MetroRadiance;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KcvExtension.Test
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static List<ITool> IToolList { get; set; } = new List<ITool>();
        public static List<IPlugin> IPluginList { get; set; } = new List<IPlugin>();


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ThemeService.Current.Initialize(this, Theme.Dark, Accent.Purple);

            var core = new AMing.KcvExtension.Core.Entrance();

            IToolList.Add(core);
            IPluginList.Add(core);


            IPluginList.ForEach(x => x.Initialize());

            this.MainWindow = new MainWindow();
            this.MainWindow.Show();
        }

    }
}
