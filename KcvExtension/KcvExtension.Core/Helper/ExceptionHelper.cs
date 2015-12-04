using AMing.KcvExtension.Core.Hub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMing.KcvExtension.Core.Helper
{
    public class ExceptionHelper
    {
        /// <summary>
        /// 调用kcv内部一些不明确的方法时候可以拦截异常并记录到日志
        /// </summary>
        /// <param name="action"></param>
        public static void TryFunction(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                RadioHub.Current.SendException(ex);
                MessageBoxDialog.Show(ex.Message);
            }
        }
    }
}
