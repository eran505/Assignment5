using Ass5.Controller;
using Ass5.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass5.Model
{
    public class MyModel : Imodel
    {
        Icontroller m_control;
        SqlConnection m_cnn;
        public MyModel(Icontroller c)
        {
            m_control = c;
            Strat();
        }
        public void Strat()
        {
            //Data Source=(LocalDB)\v11.0;AttachDbFilename="C:\Users\yarin\Downloads\final-ניתוצ-5\ניתוצ 5\WpfApplication1\Model\Database1.mdf";Integrated Security=True
           // string str1 = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Eran Hershkovich\Desktop\ConsoleApplication1\ConsoleApplication1\Database1.mdf;Integrated Security=True";
            string str1 = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\yarin\Downloads\final-ניתוצ-5\ניתוצ 5\WpfApplication1\Model\Database1.mdf;Integrated Security=True";
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
            m_cnn.Close();
            m_cnn.Open();

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

                return "Exception user";
            }
            if (ans.Length < 1)
                return "No user";
            return ans;
        }

        public bool RemoveUser(string mail)
        {
            var qury = string.Format("DELETE FROM RUsers WHERE Email='{0}'", mail);
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

        public List<string> ShowAllProduct()
        {
            List<string> ans = new List<string>();
            var qury = string.Format("Select [Name] From [Products]");
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
                                ans.Add((string)reader.GetValue(i));
                            }

                        }
                    }
                }
            }
            catch (Exception)
            {
                return ans;

            }
            return ans;
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
            var qury = string.Format("DELETE FROM [Products] WHERE [id]='{0}'", id);
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
                return "Exception product ";
            }
            if (ans.Length < 1)
                return "No prouduct";
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
            catch (Exception)
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
        public List<string> GetTable(int index)   // 1 = user  2=products 3=freinds 
        {
            string qury;
            var ans = new List<string>();
            switch (index)
            {
                case 1:
                    qury = string.Format("Select * From [RUsers]");
                    try
                    {
                        SqlCommand cmd = new SqlCommand(qury, m_cnn);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            ans.Add(dr["Email"].ToString() + " " + dr["Name"].ToString() + " " + dr["Password"].ToString() + " " + dr["Age"].ToString());
                        }
                         //var cmd = new SqlCommand(qury, m_cnn);
                         //using (SqlDataReader reader = cmd.ExecuteReader())
                         // {
                         //     while (reader.Read())
                         //     {
                         //         for (int i = 0; i < reader.FieldCount; i++)
                         //         {
                         //              ans.Add((string)reader.GetValue(i));
                         //         }

                         //     }
                         // }
                    }
                    catch (Exception)
                    {
                        return ans;
                    }
                    break;
                case 2:
                     qury = string.Format("Select * From [Products]");
                     try
                     {
                        // var cmd = new SqlCommand(qury, m_cnn);
                         SqlCommand cmd = new SqlCommand(qury, m_cnn);
                         SqlDataAdapter da = new SqlDataAdapter(cmd);
                         DataTable dt = new DataTable();
                         da.Fill(dt);
                         foreach (DataRow dr in dt.Rows)
                         {
                             ans.Add(dr["Name"].ToString());
                         }
                     }
                     catch (Exception)
                     {
                         return ans;
                     }
                    break;
                case 3 :
                    qury = string.Format("Select * From [Friends]");
                    try
                    {
                        SqlCommand cmd = new SqlCommand(qury, m_cnn);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            ans.Add(dr["User1"].ToString()+" : " + dr["User2"].ToString());
                        }
                    }
                    catch (Exception)
                    {
                        return ans;
                    }
                    break;
            }
            return ans;
        
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
