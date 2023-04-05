using DSS.Data;
using DSS.Models;
using Microsoft.EntityFrameworkCore;

namespace DSS.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public void addUser(UserModel newUser)
        {
            _context.Add(newUser);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<UserModel>> getAllUsersAsync()
        {
            var allUsers = await _context.Users.ToListAsync();
            return allUsers;
        }

        public async Task<UserModel> getUserByIdAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=> x.Id == userId);
            return user;
        }


    }
}
