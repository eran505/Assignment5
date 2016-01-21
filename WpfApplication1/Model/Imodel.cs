using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass5.Model
{
    public interface Imodel
    {
        List<string> GetTable(int index);
         List<string> ShowAllProduct();
         bool AddUser(string mail, string name ,string password ,int age);
         string GetUser(string mail);
         bool RemoveUser(string mail);
         bool AddProduct(string id , string name);
         bool RemoveProduct(string id);
         string GetProduct(string id);
         bool MakeFriend(string id1, string id2);
         bool CancelFriend(string id1, string id2);
         bool CheckFriend(string id1, string id2);

    }
}
