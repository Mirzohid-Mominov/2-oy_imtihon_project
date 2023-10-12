using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_oy_imtihon_project.DataLayer.Models
{
    public class UserSchyot
    {
        public UserSchyot(int id, string cardNumber, string bankName, double balance)
        {
            Id = id;
            CardNumber = cardNumber;
            BankName = bankName;
            Balance = balance;
        }

        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string BankName { get; set; }
        public double Balance { get; set; }
    }
}
