using Ass5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass5.Controller.Commands
{
    public class LogIn : Acommand
    {
        public LogIn(Imodel model, Iview view) : base(model, view) { }
        public override void DoCommand(params string[] parameters) // [0]=user [1]=password
        {
            var data = m_model.GetUser(parameters[0]);
            if (data == "No user")
            {
                m_view.userExists = false;
                return;
            }
            var arr = data.Split(' ');
            if (arr[3] == parameters[1])
                m_view.userExists = true;
            else
                m_view.userExists = false;
        }
    }
}
