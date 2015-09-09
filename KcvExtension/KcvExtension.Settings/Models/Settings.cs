using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroRadiance;

namespace AMing.KcvExtension.Settings.Models
{
    public class Settings
    {
        public bool EnableExitTip { get; set; }

        public bool EnableNotifyIcon { get; set; }

        public bool EnableWindowMiniHideTaskbar { get; set; }

        public Theme WindowTheme_Theme { get; set; } = Theme.Dark;

        public Accent WindowTheme_Accent { get; set; } = Accent.Blue;
    }
}
