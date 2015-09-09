using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AMing.KcvExtension.Core.ViewModels.Settings
{
    public class PluginItemViewModel : SelectedItemViewModel
    {
        public PluginItemViewModel(Interface.IPlugin plugin)
        {
            this.Plugin = plugin;
            this.ItemButton = plugin.ItemButton;
        }
        public Interface.IPlugin Plugin { get; }

        public ImageSource ItemButton { get; }

        #region SettingsView

        private object _SettingsView;

        public object SettingsView
        {
            get
            {
                if (this._SettingsView == null)
                {
                    this._SettingsView = this.Plugin.SettingsView();
                    this.RaisePropertyChanged();
                }

                return _SettingsView;
            }
        }

        #endregion

    }
}
