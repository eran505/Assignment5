using Ass5.Controller;
using Ass5.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Ass5.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


        private void OnStartup(object sender, StartupEventArgs e)
        {
            Icontroller con = new MyController();
            Imodel model = new MyModel(con);
            MainWindow view = new MainWindow();
            con.SetModel(model);
            con.SetView(view);
            view.SetController(con);
            view.ShowDialog();
          //  MainWindow main = new MainWindow();
            
        }

     

    }
}
