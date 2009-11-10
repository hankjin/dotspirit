using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spirit.Plugins;

namespace Blogger
{
    public class BlogPlugin : IPlugin
    {
        public string GetName()
        {
            return "Bloger";
        }
        public string GetIcon()
        {
            return "hankjin.png";
        }
        public string GetDll()
        {
            return "a.dll";
        }
        public bool IsActive()
        {
            return true;
        }
    }
}
