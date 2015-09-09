using AMing.KcvExtension.Core.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMing.KcvExtension.Settings.Data
{
    public class Settings : SettingBase<Models.Settings>
    {
        public static Settings SettingsCurrent { get; } = new Settings();

        public override string SettingKey { get; } = "AMing.KcvExtension.SettingsEx.Settings";

        public override string SettingDirName { get; } = "SettingsEx";

        public override string SettingFileName { get; } = "Settings.xml";

        public override void SetDefault() => base.Settings = new Models.Settings();

    }
}
