using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Spirit.Plugins;

namespace Spirit
{
    class PluginManager
    {
        private List<IPlugin> plugins = new List<IPlugin>();
        /// <summary>
        /// 所有插件
        /// </summary>
        /// <returns></returns>
        public List<IPlugin> GetPlugins()
        {
            return this.plugins;
        }

        #region 工厂方法
        public static PluginManager Load(DirectoryInfo pluginDir)
        {
            PluginManager pm = new PluginManager();
            FileInfo[] dlls = pluginDir.GetFiles("*.dll");
            foreach (FileInfo dll in dlls)
            {
                IPlugin plugin = null;
                //加载dll文件
                pm.plugins.Add(plugin);
            }
            return pm;
        }
        private PluginManager() { }
        #endregion
    }
}
