using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kcvc = Grabacr07.KanColleViewer.Composition;

namespace AMing.KcvExtension.Core
{
    [Export(typeof(kcvc.IPlugin))]
    [Export(typeof(kcvc.ITool))]
    //[Export(typeof(IRequestNotify))]
    [ExportMetadata("Guid", "23D93579-5535-4E3C-A22B-E9CBEE999A01")]
    [ExportMetadata("Title", "KcvExtension")]
    [ExportMetadata("Description", "核心部分插件")]
    [ExportMetadata("Version", Version)]
    [ExportMetadata("Author", "@AMing")]
    public class Entrance : kcvc.IPlugin, kcvc.ITool
    {
        public const string Version = "1.0";


        private ViewModels.SettingsViewModel viewModel = new ViewModels.SettingsViewModel();

        string kcvc.ITool.Name => TextResource.Tool_Name;

        object kcvc.ITool.View => new Views.SettingsControl { DataContext = this.viewModel };

        ~Entrance()
        {
            Dispose();
        }

        public void Initialize()
        {
            Hosting.PluginHost.Current.Initialize();
        }
        public void Dispose()
        {
            Generic.SettingsHelper.Current.SaveAll();
            Generic.ModulesHelper.Current.DisposeModulesList();
        }
    }
}
