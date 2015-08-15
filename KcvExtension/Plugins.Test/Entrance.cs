using AMing.KcvExtension.Core.Generic;
using AMing.KcvExtension.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Plugins.Test
{
    [Export(typeof(IPlugin))]
    public class Entrance : PluginBase
    {
        public override string PluginKey { get; } = "Plugins.Test_PluginKey";

        public override string PluginName { get; } = "Plugins.Test_PluginName";

        public override Version PluginVersion { get; } = Version.Parse("1.0.1.1");

        public override ImageSource ItemButton { get; } = null;

        public override object SettingsView() => null;

        public override void InitSettings()
        {
            base.InitSettings();
            this._settings.Add(Setting.Current);
        }
        public override void InitModules()
        {
            base.InitModules();
            this._modules.Add(Module.Current);
        }
    }
}
