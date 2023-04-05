using DSS.Data;
using DSS.Models;
using Microsoft.EntityFrameworkCore;

namespace DSS.Repository.Sessions;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationDBContext _context;
    private List<UserModel> accounts;

    public AccountRepository(ApplicationDBContext dbContext)
    {
        _context = dbContext;
        accounts = _context.Users.ToList();
    }


    public UserModel? Login(string username, string password)
    {
        return accounts.SingleOrDefault(x => x.Username == username && x.Password == password);
    }

    public bool Register(string username)
    {
        if (accounts.SingleOrDefault(x => x.Username == username) == null)
        {
            return true;
        }

        return false;

    }

    public async Task<UserModel> getSesionUser(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x=> x.Username == username);
      
        return user;
    }



}