using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass5.Controller
{
    public interface Icommand
    {
        void DoCommand(params string[] parameters);
    }
}
