using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
namespace Question3
{
    class Program
    {
         
        static void Main(string[] args)
        {
            
            User user = new User();
            List<User> users = new List<User>();
            users = user.ViewAllUsers();
            foreach (User user1 in users)
            {
                Console.WriteLine(user1);
            }

            Console.Read();
        }
    }
}
