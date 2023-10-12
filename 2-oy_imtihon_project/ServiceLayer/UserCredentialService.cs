using _2_oy_imtihon_project.DataLayer.Models;
using _2_oy_imtihon_project.FileServer.FilePath;
using _2_oy_imtihon_project.Interfaces;
using FileContext.Abstractions.Models.FileSet;
using FileContext.Core.Models.FileSet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2_oy_imtihon_project.ServiceLayer
{
    public class UserCredentialService : IUserCredentialService
    {
        public static FileContext<UserCredential> filecontext = new FileContext<UserCredential>(@"D:\Projects\2-oy_imtihon_project\2-oy_imtihon_project\FileServer\File\FollowingUser.txt");
        List<UserCredential> followedUsers = filecontext.Readtext().ToList();
        public UserCredential Create(UserCredential userCredential)
        {
            if (followedUsers.Find(user => user.PhoneNumber == userCredential.PhoneNumber) is null)
            {
                Console.WriteLine("You have started creting your account: ");

                var userId = (followedUsers.Count == 0) ? 1 : followedUsers.LastOrDefault().Id + 1;
                userCredential.Id = userId;

                followedUsers.Add(userCredential);
                filecontext.Writetext(followedUsers);


               
            }
            else
            {
                Console.WriteLine("you are already exested: ");
                return userCredential;

            }
            Console.WriteLine("You have successfully created your acoount!");
            Console.WriteLine("Congratulate yoy!!!");
            return userCredential;
        }
    }
}
