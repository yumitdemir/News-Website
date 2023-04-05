using DSS.Models;

namespace DSS.Repository.Sessions
{
    public interface IAccountRepository
    {
        public UserModel? Login(string username, string password);
        public bool Register(string username);

        public Task<UserModel> getSesionUser(string username);
    }
}
