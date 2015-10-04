using AMing.KcvExtension.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AMing.KcvExtension.Core.Extensions;

namespace AMing.KcvExtension.Core.Hosting
{
    public class PluginHost : IDisposable
    {
        #region Current

        public static PluginHost Current { get; } = new PluginHost();

        #endregion

        private readonly CompositionContainer container;

        public const string PluginsDirectory = "Plugins";

        [ImportMany]
        public IEnumerable<Lazy<IPlugin, IPluginMetadata>> Plugins { get; set; }

        private PluginHost()
        {
            var catalog = new AggregateCatalog(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

            var current = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            if (current != null)
            {
                var pluginsPath = Path.Combine(current, PluginsDirectory);
                if (Directory.Exists(pluginsPath))
                {
                    catalog.Catalogs.Add(new DirectoryCatalog(pluginsPath));
                }
            }

            this.container = new CompositionContainer(catalog);
        }
        static PluginHost()
        {

        }

        public void Dispose()
        {
            this.container.Dispose();
        }

        public void Initialize()
        {
            this.container.ComposeParts(this);
            this.Plugins.ForEach(x => Generic.PluginHelper.Current.Register_Plugin(x.Value));
        }

    }
}
