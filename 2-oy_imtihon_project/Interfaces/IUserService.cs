using _2_oy_imtihon_project.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_oy_imtihon_project.Interfaces
{
    interface IUserService
    {
        public User AddUserToFile(User users);
        public List<User> GetAllUser();
        public User Search(User id);
        public User Update(User user);
        public IEnumerable<User>  DeleteFromFile(int id);
    }
}
