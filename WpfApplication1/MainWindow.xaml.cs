using Ass5.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ass5.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, Iview
    {
        public string SelectedItem { get; set; }
        public bool userExists { get; set; }
        public bool userCreated { get; set; }
        public List<string> products { get; set; }

        private List<string> tmp { get; set; }
        public bool listUpdated { get; set; }

        Icontroller cont;
        Dictionary<string, Icommand> commDic;
        string Current;

        public MainWindow()
        {
            userExists = false;
            userCreated = false;
            listUpdated = false;
            InitializeComponent();
            products = new List<string>();
            tmp = new List<string>();
        }

        public void SetController(Icontroller c)
        {
            cont = c;
            commDic = cont.GetCommands();
            Icommand cmd = commDic["GetData"];
            cmd.DoCommand("3");

            for (int i = 0; i < products.Count; i++)
            {
                terms.Items.Add(products.ElementAt(i));
            }
        }
        private void new_Click(object sender, RoutedEventArgs e)
        {
            addfriend.Visibility = Visibility.Hidden;
            Content.Visibility = Visibility.Visible;

        }

        private void btn_existUser_Click(object sender, RoutedEventArgs e)
        {
            if (txtbx_password.Text == "" || txtbx_Umail.Text == "")
            {
                Output("You haven't entered something");
            }
            else
            {
                Icommand cmd = commDic["LogIn"];
                cmd.DoCommand(txtbx_Umail.Text, txtbx_password.Text);
                if (userExists)
                {
                    Current = txtbx_Umail.Text;
                    Output("congratz");
                    init.Visibility = Visibility.Hidden;
                    Content.Visibility = Visibility.Visible;
                    menuu.Visibility = Visibility.Visible;
                }
                else
                {
                    Output("user already exists");
                }
            }
        }

        private void btn_newUser_Click(object sender, RoutedEventArgs e)
        {

            init.Visibility = Visibility.Hidden;
            newUser.Visibility = Visibility.Visible;
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            if (txtbx_Uname2.Text == "" || txtbx_password2.Text == "" || txtbx_Mail.Text == "" || txtbx_age.Text == "")
            {
                Output("please fill missing data");
            }
            else
            {
                Icommand cmd = commDic["AddUser"];
                cmd.DoCommand(txtbx_Mail.Text, txtbx_Uname2.Text, txtbx_password2.Text, txtbx_age.Text);
                if (!userExists)
                {
                    Current = txtbx_Mail.Text;
                    Output("Welcome you shopper");
                    newUser.Visibility = Visibility.Hidden;
                    menuu.Visibility = Visibility.Visible;
                    Content.Visibility = Visibility.Visible;
                }
                else
                {
                    Output("failed");
                }
            }
        }

        public void Output(string str)
        {
            MessageBox.Show(str);
        }

        private void addFriend_Click(object sender, RoutedEventArgs e)
        {
            Content.Visibility = Visibility.Hidden;
            addfriend.Visibility = Visibility.Visible;
        }



        private void btn_addFriend_Click(object sender, RoutedEventArgs e)
        {
            if (txtbx_friendMail.Text == "")
                Output("please try again");
            Icommand cmd = commDic["MakeFriend"];
            cmd.DoCommand(Current, txtbx_friendMail.Text);
            
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Get the currently selected item in the ListBox.
            SelectedItem = terms.SelectedItem.ToString();

        }

        private void btn_remFriend_Click(object sender, RoutedEventArgs e)
        {
            Icommand cmd = commDic["CancelFriend"];
            cmd.DoCommand(Current, txtbx_friendMail.Text);
            Content.Visibility = Visibility.Visible;
            addfriend.Visibility = Visibility.Hidden;
        }

        private void btn_addToCart_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItem != "")
            {
                if (SelectedItem != "")
                {
                    //Icommand cmd = commDic["RemoveProduct"];
                    //cmd.DoCommand("236", SelectedItem);
                    cart.Items.Add(SelectedItem);

                }


            }
        }

        private void listBox2_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cart.Items.Count != 0)
            {
                SelectedItem = cart.SelectedItem.ToString();
            }
        }

        private void ComboBox_Max_Month(object sender, RoutedEventArgs e)
        {
            // ... A List.
            List<string> data = new List<string>();
            data.Add("Regular User");
            data.Add("Finance User");


            // ... Get the ComboBox reference.
            var comboBox = sender as System.Windows.Controls.ComboBox;

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            // ... Make the first item selected.
            comboBox.SelectedIndex = 11;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cont.DropAllTables();
        }

        private void btn_remFromCart_Click(object sender, RoutedEventArgs e)
        {
            tmp.Clear();
            if (SelectedItem != "")
            {
                //Icommand cmd = commDic["RemoveProduct"];
                //cmd.DoCommand("236", SelectedItem);
                //cart.SelectedIndex = -1;
                //cart.Items.Remove(cart.SelectedItem);
                foreach (string s in cart.Items)
                {
                    tmp.Add(s);
                }
                tmp.Remove(SelectedItem);
                cart.Items.Clear();
                foreach (string s in tmp)
                {
                    cart.Items.Add(s);
                }
                SelectedItem = "";
            }
        }

        private void diss_Click(object sender, RoutedEventArgs e)
        {
            addfriend.Visibility = Visibility.Hidden;
            Content.Visibility = Visibility.Hidden;
            txtbx_password.Clear();
            txtbx_Umail.Clear();
            init.Visibility = Visibility.Visible;
            
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            newUser.Visibility = Visibility.Hidden;
            init.Visibility = Visibility.Visible;
        }

        private void btn_back_Click2(object sender, RoutedEventArgs e)
        {
            addfriend.Visibility = Visibility.Hidden;
            Content.Visibility = Visibility.Visible;
        }
    }
}