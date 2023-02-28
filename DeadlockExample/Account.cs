namespace DeadlockExample;

public class Account
{
	public int Id { get; }
	private double balance { get; set; }

	public Account(int id, double balance)
	{
		Id = id;
		this.balance = balance;
	}

	public void WithdrawMoney(double amount) 
		=> balance -= amount;
	
	public void DepositMoney(double amount) 
		=> balance += amount;
}