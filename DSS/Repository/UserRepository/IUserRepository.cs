using DSS.Models;

namespace DSS.Repository.UserRepository
{
    public interface IUserRepository
    {
        public void addUser(UserModel newUser);
    }
}
