using System.Runtime.InteropServices.JavaScript;

namespace AccountsSample.Models;

public class AccountRepo
{
   private List<AccountModel> _accounts = new()
   {
       new AccountModel { Id = 1, Name = "Kreditkarte" },
       new AccountModel { Id = 2, Name = "Privatkonto" }
   };

   public IReadOnlyList<AccountModel> GetAccounts() => _accounts;
   public AccountModel? GetAccount(int id) => _accounts.SingleOrDefault(acc => acc.Id == id);

   public void UpdateAccount(int id, string name)
   { 
       if (_accounts.All(acc => acc.Id != id))
       {
           return;
       }

       _accounts.Single(acc => acc.Id == id).Name = name;
   }
}