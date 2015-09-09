using AMing.KcvExtension.Core.Generic;
using System.Windows.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AMing.KcvExtension.Core.Helper;

namespace AMing.KcvExtension.Settings.Modules
{
    public class ExitTipModules : ModulesBase
    {
        public static ExitTipModules Current { get; } = new ExitTipModules();

        public override string Key { get; set; } = "AMing.KcvExtension.Settings.ExitTipModules";
        

        public override void MainWindowFristActivated()
        {
            base.MainWindowFristActivated();
            Application.Current.MainWindow.Closing += new CancelEventHandler(MainWindow_Closing);
        }

        void MainWindow_Closing(object o, CancelEventArgs e)
        {
            if (!Data.Settings.SettingsCurrent.Settings.EnableExitTip) return;

            if (!MessageBoxDialog.Show(TextResource.Exit_Msg_Content, TextResource.Exit_Msg_Title))
            {
                e.Cancel = true;
            }
        }
    }
}
