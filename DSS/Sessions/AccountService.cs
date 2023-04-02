using DSS.Models;

namespace DSS.Sessions
{
    public class AccountService : IAccountService
    {
        private List<AccountDTO> accounts;

        public AccountService()
        {
            accounts = new List<AccountDTO>()
            {
                new AccountDTO()
                {
                    Username = "n123",
                    Password="1234"
                },
                new AccountDTO()
                {
                    Username = "n123_",
                    Password = "1234"
                }
            };
        }
        public AccountDTO? Login(string username, string password)
        {
            return accounts.SingleOrDefault(x=>x.Username == username && x.Password == password);
        }
    }
}
