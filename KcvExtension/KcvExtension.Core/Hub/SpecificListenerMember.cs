using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMing.KcvExtension.Core.Hub
{
    /// <summary>
    /// 只接受指定key的收听者
    /// </summary>
    public class SpecificListenerMember : ListenerMember
    {
        public override bool IsSend(string key)
        {
            return this.ListenerKey.Equals(key);
        }
    }
}
