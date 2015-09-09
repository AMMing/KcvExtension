using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMing.KcvExtension.Core.Interface
{
    public interface IModules : IDisposable
    {
        string Key { get; set; }
        /// <summary>
        /// 模块是否已经初始化
        /// </summary>
        bool IsInitialization { get; set; }
        /// <summary>
        /// 初始化开始
        /// </summary>
        void Initialize_Start();
        /// <summary>
        /// 初始化结束
        /// </summary>
        void Initialize_End();
        /// <summary>
        /// 主窗体第一次获得焦点
        /// </summary>
        void MainWindowFristActivated();
        /// <summary>
        /// 主窗体退出
        /// </summary>
        void MainWindowExit();
    }
}
