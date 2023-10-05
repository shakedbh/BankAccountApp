
namespace BankAccountApp
{
	using System;

	[Serializable]
	public abstract class BankAccount
	{
		private int accountNum;
		private string ownerName;
		private string ownerID;
		private double accountBalance;

		public BankAccount(int accountNum, string ownerName, string ownerID, double accountBalance)
		{
			this.accountNum = accountNum;
			this.ownerName = ownerName;
			this.ownerID = ownerID;
			this.accountBalance = accountBalance;
		}

		public int getAccountNum()
		{
			return accountNum;
		}

		public string getOwnerName()
		{
			return ownerName;
		}

		public string getOwnerID()
		{
			return ownerID;
		}

		public double getAccountBalance()
		{
			double value = Math.Round(accountBalance, 2);
			return value;
		}

		public void setOwnerName(string ownerName)
		{
			this.ownerName = ownerName;
		}

		public void setOwnerID(string ownerID)
		{
			this.ownerID = ownerID;
		}

		public void setAccountBalance(double accountBalance)
		{
			this.accountBalance = accountBalance;
		}

		public void withdraw(double amount)
		{
			if (amount > accountBalance)
				Console.WriteLine("You can withdraw up to " + accountBalance);

			accountBalance -= amount;
		}

		public void deposit(double amount)
		{
			accountBalance += amount;
		}

		public abstract double manageAccount();

		public virtual string toString(int accountNum, string ownerName, string ownerID, double accountBalance)
		{
			return "[-] Account number is: " + accountNum +
				"\n[-] Owner name is: " + ownerName +
				"\n[-] Owner ID is: " + ownerID +
				"\n[-] Account balance is: " + accountBalance;
		}

	}
}

