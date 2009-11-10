using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blogger.ISPs
{
    interface IISP
    {
        void Login(string user, string pass);
        void Publish(string title, string content, string category, Dictionary<string, string> args);
    }
}
