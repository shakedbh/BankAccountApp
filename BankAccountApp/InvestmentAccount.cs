using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountApp
{
    [Serializable]
    public class InvestmentAccount : SavingsAccount
    {
        private string investmentChannel;

        public InvestmentAccount(int accountNum, string ownerName, string ownerID, double accountBalance, double interestRate, string investmentChannel)
        : base(accountNum, ownerName, ownerID, accountBalance, interestRate)
        { this.investmentChannel = investmentChannel; }

        public string getInvestmentChannel()
        {
            return investmentChannel;
        }

        public double getInvesment(string invesmentChannel)
        {
            switch (investmentChannel)
            {
                case "Shares":
                    setInterestRate(0.25);
                    break;
                case "Real Estate":
                    setInterestRate(0.7);
                    break;
                case "Bonds":
                    setInterestRate(0.08);
                    break;
            }
            return getInterestRate();
        }

        public bool invest(double amount, string investmentChannel)
        {
            switch (investmentChannel)
            {
                case "Shares":
                    setInterestRate(0.25);
                    break;
                case "Real Estate":
                    setInterestRate(0.7);
                    break;
                case "Bonds":
                    setInterestRate(0.08);
                    break;
            }
            if (amount > getAccountBalance())
            {
                return false;
            }
            setAccountBalance(getAccountBalance() - amount + (amount * (1 + getInterestRate())));
            return true;
        }

        public string toString(int accountNum, string ownerName, string ownerID, double accountBalance, double interestRate, string channel)
        {
            return toString(accountNum, ownerName, ownerID, accountBalance) + "\n[-] Interest rate is: " + interestRate + "\n[-] Your channel is: " + channel;
        }

        public override double manageAccount()
        {
            return getAccountBalance();
        }
    }
}
