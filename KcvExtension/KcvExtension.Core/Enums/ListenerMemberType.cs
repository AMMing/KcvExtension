using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMing.KcvExtension.Core.Enums
{
    [Flags]
    public enum ListenerMemberType
    {
        /// <summary>
        /// 正常的
        /// </summary>
        Normal = 1 << 0,
        /// <summary>
        /// 功能
        /// </summary>
        Function = 1 << 1,
        /// <summary>
        /// 数据方法
        /// </summary>
        DataMethod = 1 << 2,
        /// <summary>
        /// 全部
        /// </summary>
        All = Normal | Function | DataMethod
    }
}
