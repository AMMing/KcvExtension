using AMing.KcvExtension.Core.Generic;
using AMing.KcvExtension.Core.Interface;
using AMing.KcvExtension.Settings.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static AMing.KcvExtension.Core.Helper.ResourcesHelper;

namespace AMing.KcvExtension.Settings
{
    [Export(typeof(IPlugin))]
    public class Entrance : PluginBase
    {
        public override string PluginKey { get; } = "KcvExtension.Settings";

        public override string PluginName { get; } = "KcvExtension.Settings";

        public override Version PluginVersion { get; } = Version.Parse("1.0.1.1");

        public override ImageSource ItemButton => new BitmapImage(GetResourcesUri("images/icon.jpg"));

        private ViewModels.Settings.SettingsViewModel viewModel = new ViewModels.Settings.SettingsViewModel();
        private Views.SettingsControl settingsControl;

        public override object SettingsView() => settingsControl;

        public override void Initialize_Start()
        {
            base.Initialize_Start();
            settingsControl = new Views.SettingsControl { DataContext = this.viewModel };
        }

        public override void InitSettings()
        {
            base.InitSettings();
            this._settings.Add(Data.Settings.SettingsCurrent);
        }
        public override void InitModules()
        {
            base.InitModules();
            this._modules.Add(ExitTipModules.Current);
            this._modules.Add(ThemeModules.Current);
        }

    }
}
