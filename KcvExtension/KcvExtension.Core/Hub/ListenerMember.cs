﻿using AMing.KcvExtension.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMing.KcvExtension.Core.Hub
{
    /// <summary>
    /// 收听者
    /// </summary>
    public class ListenerMember : ListenerMemberBase
    {
        public ListenerMember() { }
        public ListenerMember(object obj, string key, Action<dynamic> receive)
        {
            this.ListenerObject = obj;
            this.ListenerKey = key;
            this.Receive = receive;
        }
        /// <summary>
        /// 符合key就收听
        /// </summary>
        public string ListenerKey { get; set; }
        /// <summary>
        /// 是否发送广播
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override bool IsSend(string key)
        {
            if (this.OnlyListenerKey.Equals(key)) return true;

            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(this.ListenerKey)) return false;

            if (RadioHub.IsSendAll(key)) return true;//默认接受全部消息

            return this.ListenerKey.Equals(key);
        }

        /// <summary>
        /// 发送广播
        /// </summary>
        /// <param name="args"></param>
        public override void OnReceive(dynamic args)
        {
            if (this.Receive != null)
                this.Receive(args);
        }
    }
}
