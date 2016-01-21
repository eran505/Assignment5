using Ass5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass5.Controller.Commands
{
    public class GetData : Acommand
    {
        public GetData(Imodel model, Iview view) : base(model, view) { }
        public override void DoCommand(params string[] parameters)
        {
            switch (parameters[0]) 
            {
                case "1" :
                    m_view.Output(m_model.GetProduct(parameters[1]));
                    break;
                case "2":
                    m_view.Output(m_model.GetUser(parameters[1]));
                    break;
                case "3":
                    m_view.products =m_model.ShowAllProduct();
                    m_view.listUpdated = true;
                    break;                 }
        }
    }
}
