using AMing.KcvExtension.Core.Collections;
using AMing.KcvExtension.Core.Hub;
using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMing.KcvExtension.Logger.ViewModels.Settings
{
    public class SettingsViewModel : ViewModel
    {
        public SettingsViewModel()
        {
        }

        #region PluginList


        #endregion
        int count = 0;
        public void Test()
        {
            count++;
            RadioHub.Current.Send($"{RadioHub.Send_Exception}_Log", $"AMing.KcvExtension.Logger.ViewModels.Settings Test.{count}");
        }
    }
}
