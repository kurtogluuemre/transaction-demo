using System;

namespace TransactionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var fromAccount = context.Accounts.Find(1);
                        var toAccount = context.Accounts.Find(2);

                        fromAccount.Balance -= 100;
                        toAccount.Balance += 100;

                        context.SaveChanges();
                        transaction.Commit();
                        Console.WriteLine("Transfer başarılı.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Hata: " + ex.Message);
                    }
                }
            }
        }
    }
}
