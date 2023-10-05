using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountApp
{
    using System;

    [Serializable]
    public class SavingsAccount : BankAccount
    {
        private double interestRate;
        private readonly double DEFAULT_COMMISSION_PERCENT = 0.25;

        public SavingsAccount(int accountNum, string ownerName, string ownerID, double accountBalance, double interestRate)
            : base(accountNum, ownerName, ownerID, accountBalance)
        { this.interestRate = interestRate; }

        public double getInterestRate()
        {
            return interestRate;
        }

        public void setInterestRate(double interestRate)
        {
            this.interestRate = interestRate;
        }

        public double calculateInterest()
        {
            return getAccountBalance() + (getAccountBalance() * interestRate);
        }
        
        public override double manageAccount()
        {
            return calculateInterest();
        }

        public string toString(int accountNum, string ownerName, string ownerID, double accountBalance, double interestRate)
        { 
            return toString(accountNum, ownerName, ownerID, accountBalance) + "\n[-] Interest rate is: " + interestRate;
        }
    }
}
