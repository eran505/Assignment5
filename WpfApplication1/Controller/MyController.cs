using Ass5.Controller;
using Ass5.Model;
using Ass5.Controller.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ass5.Controller
{
    public class MyController:Icontroller
    {
        Imodel m_model;
        Iview m_view;

        public void SetModel(Imodel model)
        {
            m_model = model;
        }

        public void SetView(Iview view)
        {
            m_view = view;
        }

        public void Output(string output)
        {
            m_view.Output(output);
        }

        public void DropAllTables()
        {
            string path = Directory.GetCurrentDirectory();
            var list1 = m_model.GetTable(1);
            var list2 = m_model.GetTable(2);
            var list3 = m_model.GetTable(3);
            Wirte("Users", list1, path);
            Wirte("products", list2, path);
            Wirte("Friends", list3, path);
        }
        private void Wirte(string name ,List<string> data,string path) 
        {
            if (File.Exists(path + @"\" + name + ".txt"))
                File.Delete(path + @"\" + name + ".txt");
            var stream2 = File.OpenWrite(path + @"\" + name + ".txt");
                using (var writer = new StreamWriter(stream2))
                {
                    foreach (var key in data)
                    {
                        writer.Write(key);
                        writer.Write("\r\n");
                    }
                }
            
        }
        public Dictionary<string, Icommand> GetCommands()
        {
            Dictionary<string, Icommand> MyDictionary = new Dictionary<string, Icommand>();

            MyDictionary.Add("AddUser", new AddUser(m_model, m_view));
            MyDictionary.Add("RemoveUser", new RemoveUser(m_model, m_view));
            MyDictionary.Add("AddProduct", new AddProduct(m_model, m_view));
            MyDictionary.Add("RemoveProduct", new RemoveProduct(m_model, m_view));
            MyDictionary.Add("MakeFriend", new MakeFriend(m_model, m_view));
            MyDictionary.Add("CancelFriend", new CancelFriend(m_model, m_view));
            MyDictionary.Add("GetData", new GetData(m_model, m_view));
            MyDictionary.Add("LogIn", new LogIn(m_model, m_view));

            return MyDictionary;
        }

    }
}
