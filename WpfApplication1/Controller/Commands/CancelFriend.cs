using Ass5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass5.Controller.Commands
{
    public class CancelFriend : Acommand
    {
        public CancelFriend(Imodel model, Iview view) : base(model, view) { }
        public override void DoCommand(params string[] parameters)
        {
            string id1 = parameters[0];
            string id2 = parameters[1];
            if (m_model.CancelFriend(id1, id2))
            {
                m_view.Output(parameters[1] + " No longer friend of you");
            }
            else 
            {
                m_view.Output("your not friend with " + parameters[1]);
            }
                
        }
    }
}
