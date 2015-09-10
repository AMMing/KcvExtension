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
        public DataTemplate Bottom { get; set; }
        public DataTemplate Top { get; set; }
        public DataTemplate Left { get; set; }
        public DataTemplate Right { get; set; }
        public DataTemplate Split { get; set; }
        public DataTemplate Tabs { get; set; }

        public override DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            var type = (WindowViewType)item;
            switch (type)
            {
                case WindowViewType.Bottom:
                    return this.Bottom;
                case WindowViewType.Top:
                    return this.Top;
                case WindowViewType.Left:
                    return this.Left;
                case WindowViewType.Right:
                    return this.Right;
                case WindowViewType.Split:
                    return this.Split;
                case WindowViewType.Tabs:
                    return this.Tabs;
                default:
                    break;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
