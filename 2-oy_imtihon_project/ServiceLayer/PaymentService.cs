using _2_oy_imtihon_project.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_oy_imtihon_project.ServiceLayer
{
    public class PaymentService
    {
        public double TransferInterest { get; init; } = 0.3;

        public bool Transfer(UserSchyot userCard, FitnessCharacters fitnesCard, double amount )
        {
               var amountWithTransferInterest = amount + (amount / 100 * TransferInterest);
            if(amountWithTransferInterest > userCard.Balance) return false;

            userCard.Balance -= amountWithTransferInterest;
            fitnesCard.Balance += amount;

            return true;

        }
    }
}
