using Ass5.Controller;
using Ass5.Model;
using Ass5.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass5.Controller
{
    public interface Icontroller
    {
        void DropAllTables();
        void SetModel(Imodel model);
        void SetView(Iview view);
        void Output(string output);
        Dictionary<string, Icommand> GetCommands();
    }
}
