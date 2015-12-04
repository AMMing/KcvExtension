using AMing.KcvExtension.Settings.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AMing.KcvExtension.Settings.Controls
{
    public class WindowViewTypeDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Default { get; set; }
        public DataTemplate Tabs { get; set; }

        public override DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            var type = (WindowViewType)item;
            switch (type)
            {
                case WindowViewType.Default:
                    return this.Default;
                case WindowViewType.Tabs:
                    return this.Tabs;
                default:
                    break;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
