using Ass5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass5.Controller.Commands
{
    public class AddUser:Acommand
    {
        public AddUser(Imodel model, Iview view) : base(model, view) { }
        public override void DoCommand(params string[] parameters)
        {
            int age = int.Parse(parameters[3]);
            if (m_model.AddUser(parameters[0], parameters[1], parameters[2], age))
                m_view.userExists = false;
            else
                m_view.userExists = true;
           
        }
    }
}
