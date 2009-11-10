using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spirit.External
{
    /// <summary>
    /// 外部应用程序管理器
    /// </summary>
    class AppManager
    {
        public Dictionary<string, AppCategory> Categories { get; set; }
        public AppManager()
        {
        }
    }
    /// <summary>
    /// 外部程序分类
    /// </summary>
    class AppCategory
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }
        public string Icon { get; set; }
        public AppCategory(string name)
        {
            this.Name = name;
        }
    }
    /// <summary>
    /// 外部程序连接
    /// </summary>
    class AppLink
    {
        /// <summary>
        /// 应用程序名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 应用程序图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 应用程序图标
        /// </summary>
        public string Path { get; set; }
        public AppLink(string uri)
        {
        }
    }
}
