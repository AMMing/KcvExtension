using AMing.KcvExtension.Core.Helper;
using AMing.KcvExtension.Settings.Controls;
using AMing.KcvExtension.Settings.Views;
using Grabacr07.KanColleViewer.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMing.KcvExtension.Settings.Helper
{
    public class WindowViewHelper
    {
        #region member


        #region ContainerWindow

        private ContainerWindow _ContainerWindow;

        public ContainerWindow ContainerWindow
        {
            get
            {
                if (this._ContainerWindow == null)
                {
                    this._ContainerWindow = new Views.ContainerWindow
                    {
                        DataContext = Application.Current.MainWindow.DataContext
                    };
                    this._ContainerWindow.ShowHide += (sender, args) =>
                    {
                        this.SplitWindowButton.BtnIsEnabled = !args;
                    };
                }
                return _ContainerWindow;
            }
            set { _ContainerWindow = value; }
        }

        #endregion

        public SplitWindowButton SplitWindowButton { get; set; }

        public TabsWindowButton TabsWindowButton { get; set; }
        #endregion

        #region method


        #region Tabs

        bool isTabsMode = false;
        public bool TabsWindow()
        {
            if (!KcvMainWindowControlHelper.Current.IsInit) return false;
            try
            {
                KcvMainWindowControlHelper.Current.Grid_Content.RowDefinitions.Clear();
                KcvMainWindowControlHelper.Current.Grid_Content.ColumnDefinitions.Clear();

                this.TabsWindowButton = new TabsWindowButton();
                KcvMainWindowControlHelper.Current.StackPanel_WindowCaptionBar.Children.Insert(0, this.TabsWindowButton);
                this.TabsWindowButton.GameVisibility += (sender, args) => KcvMainWindowControlHelper.Current.KanColleHost.Visibility = args;
                this.TabsWindowButton.ToolVisibility += (sender, args) => KcvMainWindowControlHelper.Current.ContentControl_ToolControl.Visibility = args;

                KcvMainWindowControlHelper.Current.KanColleHost.Visibility = Visibility.Visible;
                KcvMainWindowControlHelper.Current.ContentControl_ToolControl.Visibility = Visibility.Collapsed;
                isTabsMode = true;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ResetTabsWindow()
        {
            if (!KcvMainWindowControlHelper.Current.IsInit) return false;
            try
            {
                KcvMainWindowControlHelper.Current.StackPanel_WindowCaptionBar.Children.Remove(this.TabsWindowButton);

                KcvMainWindowControlHelper.Current.KanColleHost.Visibility = Visibility.Visible;
                KcvMainWindowControlHelper.Current.Grid_Content.Visibility = Visibility.Visible;
                isTabsMode = false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ChangeTabs()
        {
            if (this.TabsWindowButton != null && this.TabsWindowButton.IsInitialized && isTabsMode)
            {
                this.TabsWindowButton.TriggerClick();
            }
        }
        #endregion

        #region Top Bottom Left Right

        /// <summary>
        /// 工具栏居上
        /// </summary>
        /// <returns></returns>
        public void TopWindow() =>
            SettingsViewModel.Instance?.WindowSettings.SetDockSettings(System.Windows.Controls.Dock.Top);

        /// <summary>
        /// 工具栏居底部
        /// </summary>
        /// <returns></returns>
        public void BottomWindow() =>
            SettingsViewModel.Instance?.WindowSettings.SetDockSettings(System.Windows.Controls.Dock.Bottom);
        /// <summary>
        /// 工具栏居左
        /// </summary>
        /// <returns></returns>
        public void LeftWindow() =>
            SettingsViewModel.Instance?.WindowSettings.SetDockSettings(System.Windows.Controls.Dock.Left);
        /// <summary>
        /// 工具栏居右
        /// </summary>
        /// <returns></returns>
        public void RightWindow() =>
            SettingsViewModel.Instance?.WindowSettings.SetDockSettings(System.Windows.Controls.Dock.Right);
        /// <summary>
        /// 拆分窗体
        /// </summary>
        /// <returns></returns>
        public void SplitWindow() =>
            SettingsViewModel.Instance.WindowSettings.IsSplit = true;

        #endregion


        #endregion

    }
}
