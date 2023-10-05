using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountApp
{
	using System;
	[Serializable]
	public abstract class CheckingAccount : BankAccount
	{
		public CheckingAccount(int accountNum, string ownerName, string ownerID, double accountBalance)
			: base(accountNum, ownerName, ownerID, accountBalance)
		{ }

        public override double manageAccount()
        {
			return getAccountBalance();
        }

		public abstract void writeCheck(double amount);
    }
}
