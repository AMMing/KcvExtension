using AMing.KcvExtension.Core.Generic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AMing.KcvExtension.Core.Hub;
using Grabacr07.KanColleViewer.ViewModels.Contents;
using Grabacr07.KanColleViewer.ViewModels;
using AMing.KcvExtension.Core.Helper;

namespace AMing.KcvExtension.Debug.Modules
{
    public class DebugModules : ModulesBase
    {
        public static DebugModules Current { get; } = new DebugModules();

        public override string Key { get; set; } = "AMing.KcvExtension.Debug.DebugModules";

        public ViewModels.Settings.SettingsViewModel SettingsVM { get; set; }

        public override void MainWindowFristActivated()
        {
            base.MainWindowFristActivated();
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
            RadioHub.Current.RegisterSpecific(this, RadioHub.Send_Exception, arg =>
            {
                if (SettingsVM != null)
                    SettingsVM.DebugMessage += $"Exception:\n  {arg}\n";
            });
            RadioHub.Current.RegisterSpecific(this, $"{RadioHub.Send_Exception}_Log", arg =>
            {
                if (SettingsVM != null)
                    SettingsVM.DebugMessage += $"Log:\n  {arg}\n";
            });

            RadioHub.Current.Send($"{RadioHub.Send_Exception}_Log", "Debug init.");
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            RadioHub.Current.SendException(e.Exception);
            //#if DEBUG
            MessageBox.Show($"Error:{e.Exception.Message}\n{e.Exception.Source}\n{e.Exception.StackTrace}");
            //#endif
            e.Handled = true;
        }
    }
}
