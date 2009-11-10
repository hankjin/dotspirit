using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spirit.Plugins
{
    public interface IPlugin
    {
        string GetName();
        string GetIcon();
        string GetDll();
        bool IsActive();
    }
}
