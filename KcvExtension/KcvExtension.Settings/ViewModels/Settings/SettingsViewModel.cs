using AMing.KcvExtension.Core.Collections;
using AMing.KcvExtension.Settings.ViewModels.Themes;
using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroRadiance;
using static AMing.KcvExtension.Settings.Data.Settings;
using AMing.KcvExtension.Core.Extensions;

namespace AMing.KcvExtension.Settings.ViewModels.Settings
{
    public class SettingsViewModel : ViewModel
    {
        public SettingsViewModel()
        {
            WindowThemeList.GetListFunc = () => Modules.ThemeModules.Current.ThemeHelper.ThemeList.Select(x =>
            {
                var item = new ThemeItemViewModel<Theme, Models.ThemeItem<Theme>>(x.Value);
                if (item.Type == SettingsCurrent.Settings.WindowTheme_Theme)
                {
                    WindowThemeList.SelectedItem = item;
                }

                return item;
            }).ToList();

            WindowAccentList.GetListFunc = () => Modules.ThemeModules.Current.ThemeHelper.AccentList.Select(x =>
            {
                var item = new ThemeItemViewModel<Accent, Models.ThemeItem<Accent>>(x.Value);
                if (item.Type == SettingsCurrent.Settings.WindowTheme_Accent)
                {
                    WindowAccentList.SelectedItem = item;
                }

                return item;
            }).ToList();

            WindowViewTypeList.GetListFunc = () =>
            {
                var list = new List<WindowViewTypeViewModel>();
                EnumEx.ForEach<Enums.WindowViewType>(item =>
                {
                    var vm = new WindowViewTypeViewModel(item);
                    list.Add(vm);

                    if (item == SettingsCurrent.Settings.WindowViewType)
                    {
                        WindowViewTypeList.SelectedItem = vm;
                    }
                });
                return list;
            };


            WindowThemeList.SelectedChange += (sender, e) => Modules.ThemeModules.Current.ChangeTheme(e.Type);
            WindowAccentList.SelectedChange += (sender, e) => Modules.ThemeModules.Current.ChangeAccent(e.Type);
            WindowViewTypeList.SelectedChange += (sender, e) => Modules.WindowViewModules.Current.Change(e.Type);
        }


        #region EnableExitTip

        public bool EnableExitTip
        {
            get { return SettingsCurrent.Settings.EnableExitTip; }
            set
            {
                if (SettingsCurrent.Settings.EnableExitTip != value)
                {
                    SettingsCurrent.Settings.EnableExitTip = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region EnableNotifyIcon

        public bool EnableNotifyIcon
        {
            get { return SettingsCurrent.Settings.EnableNotifyIcon; }
            set
            {
                if (SettingsCurrent.Settings.EnableNotifyIcon != value)
                {
                    SettingsCurrent.Settings.EnableNotifyIcon = value;
                    //Modules.NotifyIconModules.Current.ResetNotifyIconVisible();
                    if (!SettingsCurrent.Settings.EnableNotifyIcon)
                    {
                        EnableWindowMiniHideTaskbar = false;
                    }
                    this.RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region EnableWindowMiniHideTaskbar

        public bool EnableWindowMiniHideTaskbar
        {
            get { return SettingsCurrent.Settings.EnableWindowMiniHideTaskbar; }
            set
            {
                if (SettingsCurrent.Settings.EnableWindowMiniHideTaskbar != value)
                {
                    SettingsCurrent.Settings.EnableWindowMiniHideTaskbar = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region WindowThemeList

        public ThemeListViewModels<Theme> WindowThemeList { get; } = new ThemeListViewModels<Theme>();

        #endregion

        #region WindowAccentList

        public ThemeListViewModels<Accent> WindowAccentList { get; } = new ThemeListViewModels<Accent>();

        #endregion



        #region WindowViewTypeList

        public ListViewModels<WindowViewTypeViewModel> WindowViewTypeList { get; } = new ListViewModels<WindowViewTypeViewModel>();

        #endregion
    }
}
