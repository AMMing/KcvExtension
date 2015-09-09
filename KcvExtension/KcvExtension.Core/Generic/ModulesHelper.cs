using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMing.KcvExtension.Core.Extensions;
using System.Windows;

namespace AMing.KcvExtension.Core.Generic
{
    public class ModulesHelper
    {
        #region current

        public static ModulesHelper Current { get; } = new ModulesHelper();

        #endregion

        #region member

        /// <summary>
        /// 全部的模块
        /// </summary>
        Dictionary<string, Interface.IModules> ModulesList { get; } = new Dictionary<string, Interface.IModules>();

        #endregion

        #region method

        /// <summary>
        /// 添加模块
        /// </summary>
        /// <param name="modules"></param>
        /// <returns></returns>
        public bool AddModules(Interface.IModules modules)
        {
            if (this.ModulesList.ContainsKey(modules.Key)) return false;

            this.ModulesList.Add(modules.Key, modules);

            return true;
        }

        /// <summary>
        /// 添加多个模块
        /// </summary>
        /// <param name="modules_list"></param>
        internal void AddModulesList(IEnumerable<Interface.IModules> modules_list)
        {
            modules_list?.ForEach(x =>
            {
                if (this.AddModules(x))
                {
                    InitModules(x);
                }
            });
        }


        /// <summary>
        /// 初始化配置模块
        /// </summary>
        /// <param name="modules"></param>
        private void InitModules(Interface.IModules modules)
        {
            modules.Initialize_Start();

            modules.IsInitialization = true;

            modules.Initialize_End();
        }

        /// <summary>
        /// 释放所有模块
        /// </summary>
        public void DisposeModulesList()
        {
            ModulesList.ForEach(x => x.Value.Dispose());
        }

        #endregion

        #region event

        public void InitMainWindowFristActivated()
        {
            Application.Current.Activated += Current_Activated;
            Application.Current.Exit += Current_Exit;
        }

        bool isActivated = false;
        private void Current_Activated(object sender, EventArgs e)
        {
            if (isActivated)
            {
                return;
            }
            isActivated = true;
            ModulesList?.ForEach(x => x.Value.MainWindowFristActivated());
        }
        private void Current_Exit(object sender, ExitEventArgs e)
        {
            ModulesList?.ForEach(x => x.Value.MainWindowExit());
        }

        #endregion
    }
}
