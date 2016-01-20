using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
           
             Model model = new Model();
            //if (model.AddUser("eran@gmail", "eran", "12323", 20))
            //    x++;
            //if (model.AddUser("shalom@gmail", "shalom", "12323", 20))
            //    x++;
            //var data = model.GetUser("eran@gmail");
            //Console.WriteLine(data);
            //model.RemoveUser("eran@gmail");
             //model.AddUser("hadar@gmail", "hadar", "12323", 20);
             //model.AddUser("mor@gmail", "mor", "12323", 20);
           //// model.MakeFriend("mor@gmail", "hadar@gmail");
           //  Console.WriteLine("mor and hadar ="+model.CheckFriend("mor@gmail", "hadar@gmail"));
           //  model.CancelFriend("mor@gmail", "hadar@gmail");
           //  Console.WriteLine("mor and hadar =" + model.CheckFriend("mor@gmail", "hadar@gmail"));
             model.AddProduct("12d", "milk");
            // model.AddProduct("123d", "coal");
            // model.AddProduct("142d", "bread");
            // Console.WriteLine(model.GetProduct("12d"));
            //model.RemoveProduct("12d");
            // Console.WriteLine(model.GetProduct("12d"));

            Console.ReadKey();

        }
    }
}
