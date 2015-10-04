using AMing.KcvExtension.Core.Collections;
using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMing.KcvExtension.Core.ViewModels.Settings
{
    public class SettingsViewModel : ViewModel
    {
        public SettingsViewModel()
        {
            PluginList.SelectedChange += (sender, e) =>
            {
            };
        }

        #region PluginList
        

        public ListViewModels<PluginItemViewModel> PluginList { get; } = new ListViewModels<PluginItemViewModel>
        {
            GetListFunc = () =>
                Generic.PluginHelper.Current.Plugins.Select(
                    x => new PluginItemViewModel(x.Value)).ToList(),
            SetDefaultFunc =list =>
                list?.FirstOrDefault()
        };

        #endregion
    }
}
