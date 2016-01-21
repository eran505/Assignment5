using Ass5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass5.Controller.Commands
{
    public class RemoveProduct : Acommand
    {
        public RemoveProduct(Imodel model, Iview view) : base(model, view) { }

     
        public override void DoCommand(params string[] parameters)
        {
            string id = parameters[0];
            m_model.RemoveProduct(id);
        }
    }
}
