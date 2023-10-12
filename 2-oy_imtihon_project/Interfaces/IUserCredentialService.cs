using _2_oy_imtihon_project.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_oy_imtihon_project.Interfaces
{
    public interface IUserCredentialService
    {
        public UserCredential Create(UserCredential userCredential);
    }
}
