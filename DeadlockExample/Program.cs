//Source link -> https://dotnettutorials.net/lesson/deadlock-in-csharp/



using DeadlockExample;



// 1001ci account Manager 1 uchun pul chixarilan, 1002ci account pul kochurulen accountdur. Manager 2 uchun ise eksine.
Console.WriteLine("Main Thread Started\n");
Account Account1001 = new(1001, 5000);
Account Account1002 = new(1002, 3000);


AccountManager accountManager1 = new AccountManager(Account1001, Account1002, 5000);
Thread thread1 = new(accountManager1.FundTransfer)
{
	Name = "Thread 1"
};


AccountManager accountManager2 = new AccountManager(Account1002, Account1001, 6000);
Thread thread2 = new(accountManager2.FundTransfer)
{
	Name = "Thread 2"
};


// Threadler eyni vaxtda bashladiqlarina gore Account1001 və Account1002 eyni anda bloklanır.
// FundTransfer methodunun icrasinin tamamlaması uchun Manager 1 Account1002, Manager 2 isə Account1001'i locklamaga chalishir, 
// Lakin her 2 account bloklandigina gore onlar bir-birini gozluyurler ve Deadlock yaranir.
thread1.Start();
thread2.Start();

thread1.Join();
thread2.Join();

Console.WriteLine("\nMain Thread Completed");