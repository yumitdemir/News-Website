using DSS.Models;

namespace DSS.Sessions
{
    public interface IAccountService
    {
        public UserModel? Login(string username, string password);

    }
}
