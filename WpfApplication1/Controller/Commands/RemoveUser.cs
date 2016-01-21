using Ass5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass5.Controller.Commands
{
    public class RemoveUser : Acommand
    {
        public RemoveUser(Imodel model, Iview view) : base(model, view) { }

        public override void DoCommand(params string[] parameters)
        {
            string mail = parameters[0];
            m_model.RemoveUser(mail);
        }
    }
}
