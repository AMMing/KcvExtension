using AMing.KcvExtension.Core.Collections;
using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMing.KcvExtension.Debug.ViewModels.Settings
{
    public class SettingsViewModel : ViewModel
    {
        public SettingsViewModel()
        {
        }
        
        private string _DebugMessage;

        public string DebugMessage
        {
            get { return _DebugMessage; }
            set
            {
                if (_DebugMessage != value)
                {
                    _DebugMessage = value;
                    this.RaisePropertyChanged();
                }
            }
        }
        
    }
}
