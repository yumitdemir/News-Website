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
        public DbSet<TagModel> Tags { get; set; }
        public DbSet<NewsModel> News { get; set; }

        public DbSet<CommentModel> Comments { get; set; }



    }
}
