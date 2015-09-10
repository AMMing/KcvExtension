using AMing.KcvExtension.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMing.KcvExtension.Settings.ViewModels.Settings
{
    public class WindowViewTypeViewModel : SelectedItemViewModel
    {
        public WindowViewTypeViewModel(Enums.WindowViewType type)
        {
            this.Type = type;
        }
        public Enums.WindowViewType Type { get; set; }
    }
}
