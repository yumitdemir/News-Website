using DSS.Models;
using Microsoft.EntityFrameworkCore;

namespace DSS.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
        

    }
}
