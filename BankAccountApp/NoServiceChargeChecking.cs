using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp
{
    [Serializable]
    public class NoServiceChargeChecking : CheckingAccount
    {
        private double minBalance;
        private readonly double DEFAULT_MINBALANCE = 0;

        public NoServiceChargeChecking(int accountNum, string ownerName, string ownerID, double accountBalance, double minBalance)
            : base(accountNum, ownerName, ownerID, accountBalance)
        { this.minBalance = minBalance; }

        public double getMinBalance()
        {
            return minBalance;
        }

        public void setMinBalance(double value)
        {
            minBalance = value;
        }

        public bool withdrawWithMinBalanceLimit(double amount)
        {
            if (getAccountBalance() - amount < minBalance)
                return false;
            withdraw(amount);
            return true;
        }

        public string toString(int accountNum, string ownerName, string ownerID, double accountBalance, double minBalance)
        {
            return toString(accountNum, ownerName, ownerID, accountBalance) + "\n[-] Minimum balance is: " + minBalance;
        }

        public override void writeCheck(double amount)
        {
            withdrawWithMinBalanceLimit(amount);
        }

    }
}
