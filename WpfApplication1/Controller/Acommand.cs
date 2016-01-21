using Ass5.Controller;
using Ass5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass5.Controller
{
    public abstract class Acommand:Icommand
    {
        protected Imodel m_model;
        protected Iview m_view;

        public Acommand(Imodel model , Iview view) 
        {
            m_model = model;
            m_view = view;
        }

        abstract public void DoCommand(params string[] parameters);
    }
}
