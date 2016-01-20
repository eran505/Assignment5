using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Model : Imodel
    {

        SqlConnection m_cnn;
        public Model()
        {
            Strat();
        }
        public void Strat()
        {            
            string str1 = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Eran Hershkovich\Desktop\ConsoleApplication1\ConsoleApplication1\Database1.mdf;Integrated Security=True";
            m_cnn = new SqlConnection(str1);
            m_cnn.Open();
        }

        public bool AddUser(string mail, string name, string password, int age)
        {
            bool ans = true;
            var qury = string.Format("INSERT INTO [RUsers] ([Email],[Name],[Password],[Age]) VALUES ('{0}','{1}','{2}',{3})", mail, name,password,age);
            try
            {
                var cmd = new SqlCommand(qury, m_cnn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception )
            {
                ans = false;
               
            }


            return ans;
        }

        public string GetUser(string mail)
        {
            string ans = "";
            var qury = string.Format("Select * From [RUsers] Where [Email]='{0}'",mail);
            try
            {
                using (SqlCommand command = new SqlCommand(qury, m_cnn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                ans = ans + " " + reader.GetValue(i);
                            }

                        }
                    }
                }
            }
            catch (Exception)
            {

                return "";
            }

            return ans;
        }

        public bool RemoveUser(string mail)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM RUsers WHERE Email = @ID", m_cnn))
                {
                    command.Parameters.Add("@ID", mail);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        public bool AddProduct(string id, string name)
        {

            var qury = string.Format("INSERT INTO [Products] ([Id],[Name]) VALUES ('{0}','{1}')", id, name);
            try
            {
                var cmd = new SqlCommand(qury, m_cnn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;

            }
            return true;
        }

        public bool RemoveProduct(string id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM [Products] WHERE [id]=@ID", m_cnn))
                {
                    command.Parameters.Add("@ID", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        public string GetProduct(string id)
        {
            string ans = "";
            var qury = string.Format("Select * From [Products] Where [id]='{0}'", id);
            try
            {
                using (SqlCommand command = new SqlCommand(qury, m_cnn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                ans = ans + " " + reader.GetValue(i);
                            }

                        }
                    }
                }
            }
            catch (Exception )
            {
                return "";
            }

            return ans;
        }

        public bool MakeFriend(string id1, string id2)
        {
            var qury = string.Format("INSERT INTO [Friends] ([User1],[User2],[Date]) VALUES ('{0}','{1}','{2}')", id1, id2, DateTime.Now.ToString("MM/DD"));          
            try
            {
                var cmd = new SqlCommand(qury, m_cnn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception )
            {
                
                return false;

            }
            return true;
        }
        public bool CheckFriend(string id1, string id2) 
        {
            string str=string.Empty;
            var qury = string.Format("Select * From [Friends] WHERE [User1]='{0}' and [User2]='{1}'", id1, id2);
            try
            {
                var cmd = new SqlCommand(qury, m_cnn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            str = str + " " + reader.GetValue(i);
                        }

                    }
                }
            }
            catch (Exception )
            {
                return false;

            }
            if (str.Length > 1)
                return true;
            else
                return false;
        
        }

        public bool CancelFriend(string id1, string id2)
        {
            var qury = string.Format("DELETE FROM [Friends] WHERE [User1]='{0}' and [User2]='{1}'", id1, id2);
            try
            {
                using (SqlCommand command = new SqlCommand(qury, m_cnn))
                {

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}
