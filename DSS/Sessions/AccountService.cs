using DSS.Data;
using DSS.Models;

namespace DSS.Sessions;

public class AccountService : IAccountService
{
    private readonly ApplicationDBContext _context;
    private List<UserModel> accounts;

    public AccountService(ApplicationDBContext dbContext)
    {
        _context = dbContext;
        accounts = _context.Users.ToList();
    }


    
    
   
    public UserModel? Login(string username, string password)
    {
        return accounts.SingleOrDefault(x => x.Username == username && x.Password == password);
    }
}