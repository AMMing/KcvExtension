using AMing.KcvExtension.Core.Generic;
using MetroRadiance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMing.KcvExtension.Settings.Modules
{
    public class ThemeModules : ModulesBase
    {
        public static ThemeModules Current { get; } = new ThemeModules();

        public override string Key { get; set; } = "AMing.KcvExtension.Settings.ThemeModules";

        public Helper.ThemeHelper ThemeHelper { get; } = new Helper.ThemeHelper();

        #region method

        public void ChangeTheme()
        {
            if (MetroRadiance.ThemeService.Current?.Theme != Data.Settings.SettingsCurrent.Settings.WindowTheme_Theme)
            {
                MetroRadiance.ThemeService.Current?.ChangeTheme(Data.Settings.SettingsCurrent.Settings.WindowTheme_Theme);
            }
        }
        public void ChangeTheme(Theme theme)
        {
            Data.Settings.SettingsCurrent.Settings.WindowTheme_Theme = theme;
            ChangeTheme();
        }

        public void ChangeAccent()
        {
            if (MetroRadiance.ThemeService.Current?.Accent != Data.Settings.SettingsCurrent.Settings.WindowTheme_Accent)
            {
                MetroRadiance.ThemeService.Current?.ChangeAccent(Data.Settings.SettingsCurrent.Settings.WindowTheme_Accent);
            }
        }
        public void ChangeAccent(Accent accent)
        {
            Data.Settings.SettingsCurrent.Settings.WindowTheme_Accent = accent;
            ChangeAccent();
        }


        #endregion

        public override void Initialize_Start()
        {
            base.Initialize_Start();
            ChangeAccent();
            ChangeTheme();
        }
        
    }
}
