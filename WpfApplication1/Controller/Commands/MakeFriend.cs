using Ass5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass5.Controller.Commands
{
    public class MakeFriend : Acommand
    {
        public MakeFriend(Imodel model, Iview view) : base(model, view) { }
        public override void DoCommand(params string[] parameters)
        {

            string id1 = parameters[0];
            string id2 = parameters[1];
            if (!m_model.CheckFriend(id1, id2))
            {
                string str = m_model.GetUser(parameters[1]) ;
                if ((str == "No user") || (str == "")) 
                {
                    m_view.Output(parameters[1] + " - has no account");
                    return;
                }
                m_model.MakeFriend(id1, id2);
                m_view.Output("congratulations you have a new friend");
            }
            else
                m_view.Output("your are friends allready");
        }
    }
}
