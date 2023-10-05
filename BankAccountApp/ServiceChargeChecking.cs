using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp
{
    [Serializable]
    public class ServiceChargeChecking : CheckingAccount
    {
        private double commission;
        private readonly double DEFAULT_COMMISSION = 6.9;

        public ServiceChargeChecking(int accountNum, string ownerName, string ownerID, double accountBalance, double commission)
            : base(accountNum, ownerName, ownerID, accountBalance)
        { this.commission = commission; }

        public double Commission
        {
            get
            {
                return commission;
            }
            set
            {
                commission = value;
            }
        }

        public bool withdrawWithCommission(double amount)
        {
            if (getAccountBalance() < amount + DEFAULT_COMMISSION)
                return false;
            withdraw(amount + DEFAULT_COMMISSION);
            return true;
        }

        public string toString(int accountNum, string ownerName, string ownerID, double accountBalance, double commission)
        {
            return toString(accountNum, ownerName, ownerID, accountBalance) + "\n[-] The commission is: " + commission;
        }

        public override void writeCheck(double amount)
        {
            withdrawWithCommission(amount);
        } 
    }
}
