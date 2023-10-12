using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_oy_imtihon_project.DataLayer.Models
{
    public class FitnessCharacters
    {
        private string CardNumber = "8600 3747 7282 8482";

        public FitnessCharacters(double balance, string fullName)
        {
            Balance = balance;
            FullName = fullName;
        }

        public double Balance { get; set; }
        public List<User> GymFlexBalance { get; set; }
        public string FullName { get; set; }
    }
}
