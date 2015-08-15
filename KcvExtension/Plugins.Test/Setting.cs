using AMing.KcvExtension.Core.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.Test
{
    public class Setting : SettingBase<SettingModel>
    {
        public static Setting Current { get; } = new Setting();

        public override string SettingKey { get; } = "TestPlugins";

        public override string SettingDirName { get; } = "TestPlugins";

        public override string SettingFileName { get; } = "Setting.xml";

        public override void SetDefault() => base.Settings = new SettingModel();

    }
}
