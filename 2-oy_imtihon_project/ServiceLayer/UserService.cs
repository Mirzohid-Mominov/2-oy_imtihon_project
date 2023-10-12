using _2_oy_imtihon_project.DataLayer.Models;
using _2_oy_imtihon_project.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2_oy_imtihon_project.ServiceLayer
{
    public class UserService : IUserService
    {
        public static FileContext<User> filecontext = new FileContext<User>(@"D:\Projects\2-oy_imtihon_project\2-oy_imtihon_project\FileServer\File\usersAndCategories.txt");
        List<User> AllusersList = filecontext.Readtext().ToList();

        public User AddUserToFile(User users)
        {
            if (AllusersList.Find(user => user.Id == users.Id) is null)
            {
                Console.WriteLine("You have just started creting your account: ");

                var userId = (AllusersList.Count == 0) ? 1 : AllusersList.LastOrDefault().Id + 1;
                users.Id = userId;

                AllusersList.Add(users);
                filecontext.Writetext(AllusersList);
                Console.WriteLine("You have added your account to users!");
                return users;
            }
            else
            {
                Console.WriteLine("you are already exested: ");
                return users;

            }

            return users;
        }
        public IEnumerable<User> DeleteFromFile(int id)
        {
            if(AllusersList.Any(user => user.Id == id))
            {
                Console.WriteLine("You are deleting this user: ");
                var foundUser = AllusersList.FirstOrDefault(user=> user.Id == id);

                AllusersList.Remove(foundUser);
                filecontext.Writetext(AllusersList);
                Console.WriteLine("You have deleted your account from users file!");
            }
            else
            {
                Console.WriteLine("we can't find this user. That's why we can't : ");
                return AllusersList;
            }
            return AllusersList;
        }

        public List<User> GetAllUser()
        {
            Console.WriteLine("You are taking all the users from file!");
            return AllusersList;
        }

        public User Search(User id)
        {
            Console.WriteLine("You are searching smth!");
            var searchingUser = AllusersList.FindIndex(user => user.Id == id.Id);
            if (searchingUser == -1)
            {
                AllusersList[searchingUser] = id;
                return AllusersList[searchingUser];
                Console.WriteLine("Found this user");
            }
            else { throw new Exception("User not found"); }
        }

        public User Update(User user)
        {
            Console.WriteLine("You are updating your account");
            var userIndex = AllusersList.FindIndex(u => u.Id == user.Id);
            if (userIndex == -1)
                throw new ArgumentException("User not found.");

            Console.WriteLine("Updated your characters");
            AllusersList[userIndex] = user;
            filecontext.Writetext(AllusersList);
            return AllusersList[userIndex];
            Console.WriteLine("You have updated your acount from users file!");
        }

        

    }
}
