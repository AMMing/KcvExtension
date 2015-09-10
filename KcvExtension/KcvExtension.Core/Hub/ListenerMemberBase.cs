using AMing.KcvExtension.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMing.KcvExtension.Core.Hub
{
    /// <summary>
    /// 收听者基类
    /// </summary>
    public abstract class ListenerMemberBase : IListenerMember
    {
        /// <summary>
        /// 监听的对象
        /// </summary>
        public virtual object ListenerObject { get; set; }
        /// <summary>
        /// 是否发送广播
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public abstract bool IsSend(string key);
        /// <summary>
        /// 广播的接收方法
        /// </summary>
        public virtual Action<dynamic> Receive { get; set; }
        /// <summary>
        /// 发送广播
        /// </summary>
        /// <param name="args"></param>
        public abstract void OnReceive(dynamic args);
        /// <summary>
        /// 类型
        /// </summary>
        public virtual Enums.ListenerMemberType Type { get; set; } = Enums.ListenerMemberType.Function;
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 唯一的收听Key 注册的时候生成
        /// </summary>
        public virtual string OnlyListenerKey { get; set; }
    }
}
