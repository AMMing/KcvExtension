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

namespace AMing.KcvExtension.Settings.Modules
{
    public class WindowsModules : ModulesBase
    {
        public static WindowsModules Current { get; } = new WindowsModules();

        public override string Key { get; set; } = "AMing.KcvExtension.Settings.WindowsModules";


        public Window CurrentWindow { get; private set; }
        public WindowState OldwinState { get; private set; }


        public override void MainWindowFristActivated()
        {
            base.MainWindowFristActivated();
            InitCurrentWindow();
            InitPublicModules();
        }


        #region CurrentWindow

        void InitCurrentWindow()
        {
            this.CurrentWindow = Application.Current.MainWindow;
            this.CurrentWindow.StateChanged += CurrentWindow_StateChanged;
            this.OldwinState = this.CurrentWindow.WindowState;
        }

        void CurrentWindow_StateChanged(object sender, EventArgs e)
        {
            if (this.CurrentWindow.WindowState != WindowState.Minimized)
            {
                WindowShowHideForTaskBar(this.CurrentWindow, true);
                this.OldwinState = this.CurrentWindow.WindowState;
            }
            else
            {
                WindowShowHideForTaskBar(this.CurrentWindow, false);
            }

            RadioHub.Current.Send(Data.MessageKeys.Windows_State_Changed, new DynamicArgs<WindowState>(this.CurrentWindow.WindowState));
        }
        /// <summary>
        /// 显示隐藏窗体
        /// </summary>
        public WindowState? ShowHideWindow()
        {
            if (!this.IsInitialization) return null;

            var val = WindowState.Normal;
            if (this.CurrentWindow.WindowState == WindowState.Minimized)
            {
                WindowShowHideForTaskBar(this.CurrentWindow, true);
                val = this.OldwinState;
            }
            else
            {
                val = WindowState.Minimized;
            }
            this.CurrentWindow.WindowState = val;

            return val;
        }
        public static void WindowShowHideForTaskBar(Window win, bool isshow)
        {
            var old = Controls.AppendProperty.GetShowInTaskbar(win);
            if (!old.HasValue)
            {
                Controls.AppendProperty.SetShowInTaskbar(win, win.ShowInTaskbar);
                old = win.ShowInTaskbar;
            }
            if (old == true)
                win.ShowInTaskbar = !(Data.Settings.SettingsCurrent.Settings.EnableWindowMiniHideTaskbar && !isshow);
        }


        #endregion


        #region PublicModules

        void InitPublicModules()
        {
            RadioHub.Current.RegisterSpecific(this,
                Data.MessageKeys.Windows_Close,
                x => CloseWindows());

            RadioHub.Current.RegisterSpecific(this,
                Data.MessageKeys.Windows_Hide_All,
                x => HideAllWindows(),
                Core.Enums.ListenerMemberType.Function,
                $"{TextResource.Hide}{TextResource.AllWindow}");

            RadioHub.Current.RegisterSpecific(this,
                Data.MessageKeys.Windows_Show_All,
                x => ShowAllWindows(),
                Core.Enums.ListenerMemberType.Function,
                $"{TextResource.Show}{TextResource.AllWindow}");

            RadioHub.Current.RegisterSpecific(this,
                Data.MessageKeys.Windows_ShowOrHide_All,
                x => ChangeAllWindowsByMainWindow(),
                Core.Enums.ListenerMemberType.Function,
                $"{TextResource.Show}{TextResource.Hide}{TextResource.AllWindow}");


            RadioHub.Current.RegisterSpecific(this,
                Data.MessageKeys.Windows_ToggleMute,
                x => ToggleMute(),
                Core.Enums.ListenerMemberType.Function,
                $"{TextResource.ToggleMute}");

            RadioHub.Current.RegisterSpecific(this,
                Data.MessageKeys.Windows_TakeScreenshot,
                x => TakeScreenshot(),
                Core.Enums.ListenerMemberType.Function,
                $"{TextResource.Screenshot}");

            RadioHub.Current.RegisterSpecific(this,
                Data.MessageKeys.Windows_ShowShipCatalog,
                x => ShowShipCatalog(),
                Core.Enums.ListenerMemberType.Function,
                $"{TextResource.ShowShipCatalog}");

            RadioHub.Current.RegisterSpecific(this,
                Data.MessageKeys.Windows_ShowSlotItemCatalog,
                x => ShowSlotItemCatalog(),
                Core.Enums.ListenerMemberType.Function,
                $"{TextResource.ShowSlotItemCatalog}");
        }
        /// <summary>
        /// 隐藏全部窗体
        /// </summary>
        void CloseWindows()
        {
            Application.Current.MainWindow.Close();
        }
        /// <summary>
        /// 隐藏全部窗体
        /// </summary>
        void HideAllWindows()
        {
            if (Application.Current.Windows != null)
            {
                foreach (var item in Application.Current.Windows)
                {
                    var win = item as Window;
                    if (win != null && win.IsInitialized)
                    {
                        WindowShowHideForTaskBar(win, false);
                        win.WindowState = WindowState.Minimized;
                    }
                }
            }
        }
        /// <summary>
        /// 显示全部窗体
        /// </summary>
        void ShowAllWindows()
        {
            if (Application.Current.Windows != null)
            {
                foreach (var item in Application.Current.Windows)
                {
                    var win = item as Window;
                    if (win != null && win.IsInitialized)
                    {
                        WindowShowHideForTaskBar(win, true);
                        win.WindowState = OldwinState;
                    }
                }
            }
        }
        /// <summary>
        /// 显示隐藏全部窗体
        /// </summary>
        void ChangeAllWindowsByMainWindow()
        {
            var winState = ShowHideWindow();
            if (Application.Current.Windows != null && winState.HasValue)
            {
                foreach (var item in Application.Current.Windows)
                {
                    var win = item as Window;
                    if (win != null && win.IsInitialized)
                    {
                        win.WindowState = winState.Value;
                        WindowShowHideForTaskBar(win, winState != WindowState.Minimized);
                    }
                }
            }
        }

        void TryFunction(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                RadioHub.Current.SendException(ex);
                MessageBoxDialog.Show(ex.Message);
            }
        }

        OverviewViewModel GetOverviewViewModel() =>
             (Application.Current.MainWindow?.DataContext as InformationViewModel)?.Overview;
        /// <summary>
        /// 开关声音
        /// </summary>
        void ToggleMute() =>
            TryFunction(() => (Application.Current.MainWindow?.DataContext as KanColleWindowViewModel)?.Volume?.ToggleMute());
        /// <summary>
        /// 截图
        /// </summary>
        void TakeScreenshot() =>
            TryFunction(() => (Application.Current.MainWindow?.DataContext as KanColleWindowViewModel)?.TakeScreenshot());
        /// <summary>
        /// 舰娘一览
        /// </summary>
        void ShowShipCatalog() =>
            TryFunction(() => GetOverviewViewModel()?.ShowShipCatalog());
        /// <summary>
        /// 装备一览
        /// </summary>
        void ShowSlotItemCatalog() =>
            TryFunction(() => GetOverviewViewModel()?.ShowSlotItemCatalog());


        #endregion
    }
}
