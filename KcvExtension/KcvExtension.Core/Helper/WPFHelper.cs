using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AMing.KcvExtension.Core.Helper
{
    public class ResourcesHelper
    {
        /// <summary>
        /// 获取资源的uri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static Uri GetResourcesUri(string uri) =>
            new Uri($"/{Assembly.GetCallingAssembly().GetName().Name};component/{uri}", UriKind.Relative);
        
    }
}
