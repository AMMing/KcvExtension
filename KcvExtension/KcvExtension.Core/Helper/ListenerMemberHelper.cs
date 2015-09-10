using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMing.KcvExtension.Core.Helper
{
    /// <summary>
    /// 获取各种类型监听者列表及其变化的helper
    /// </summary>
    public class ListenerMemberHelper
    {
        public ListenerMemberHelper(Enums.ListenerMemberType type, Action<Interface.IListenerMember> itemAddFunc)
        {
            this.Type = type;
            this.ItemAdd = itemAddFunc;

            Hub.RadioHub.Current.GetListenerMemberByType(this.Type)?.ForEach(x => this.ItemAdd?.Invoke(x));
            Hub.RadioHub.Current.AddListenerMember += (sender, e) =>
            {
                if (e.Type.HasFlag(this.Type))
                {
                    this.ItemAdd?.Invoke(e);
                }
            };
        }

        public List<Interface.IListenerMember> ListenerMemberList { get; private set; } = new List<Interface.IListenerMember>();

        public Action<Interface.IListenerMember> ItemAdd { get; }

        public Enums.ListenerMemberType Type { get; }
    }
}
