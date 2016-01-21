using Ass5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass5.Controller.Commands
{
    public class AddProduct:Acommand
    {
        public AddProduct(Imodel model, Iview view) : base(model, view) { }
        public override void DoCommand(params string[] parameters)
        {
            string id = parameters[0];
            string name = parameters[1];
            m_model.AddProduct(id,name);
        }
    }
}
