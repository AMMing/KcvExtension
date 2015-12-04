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
using AMing.KcvExtension.Settings.Enums;

namespace AMing.KcvExtension.Settings.Modules
{
    public class WindowViewModules : ModulesBase
    {
        public static WindowViewModules Current { get; } = new WindowViewModules();

        public override string Key { get; set; } = "AMing.KcvExtension.Settings.WindowViewModules";

        public Helper.WindowViewHelper WindowViewHelper { get; } = new Helper.WindowViewHelper();

        public override void MainWindowFristActivated()
        {
            base.MainWindowFristActivated();
#if DEBUG
            return;
#endif
            if (Data.Settings.SettingsCurrent.Settings.WindowViewType != Enums.WindowViewType.Default)
            {
                SetWindow();
            }
        }


        void SetWindow()
        {
            switch (Data.Settings.SettingsCurrent.Settings.WindowViewType)
            {
                case WindowViewType.Default:
                    WindowViewHelper.SetDefaultWindow();
                    break;
                case WindowViewType.Tabs:
                    WindowViewHelper.TabsWindow();
                    break;
                default:
                    break;
            }
        }

        public void Change(WindowViewType type)
        {
            //System.Threading.Thread.Sleep(200);//太快导致左右切换重复触发
            if (Data.Settings.SettingsCurrent.Settings.WindowViewType != type)
            {
                //switch (Data.Settings.SettingsCurrent.Settings.WindowViewType)
                //{
                //    case WindowViewType.Tabs:
                //        WindowViewHelper.ResetTabsWindow();
                //        break;
                //}
                Data.Settings.SettingsCurrent.Settings.WindowViewType = type;
                SetWindow();
            }

            RadioHub.Current.Send($"{RadioHub.Send_Exception}_Log", $"{type}");
        }
    }
}
