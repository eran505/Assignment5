using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass5
{
    public interface Iview
    {
        void Output(string output);

        bool userExists { set; get; }
        List<string> products{get;set;}
        bool listUpdated{get;set;}
    }
}
