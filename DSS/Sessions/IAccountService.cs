using DSS.Models;

namespace DSS.Sessions
{
    public interface IAccountService
    {
        public AccountDTO? Login(string username, string password);

    }
}
