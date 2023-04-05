using DSS.Data;
using DSS.Models;
using DSS.Repository;
using DSS.Repository.CommentRepository;
using DSS.Repository.Detail;
using DSS.Repository.Sessions;
using DSS.Repository.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace DSS;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddSession(); //! Related to authentication with session
        builder.Services.AddScoped<IAccountRepository, AccountRepository>(); //! Related to authentication with session
        builder.Services.AddScoped<INewsRepository, NewsRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IDetailRepository, DetailRepository>();
        builder.Services.AddScoped<ICommentRepository, CommentRepository>();


        builder.Services.AddDbContext<ApplicationDBContext>(options => //! db context service
        {
            var connString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connString);
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment()) app.UseExceptionHandler("/Home/Error");
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();


        app.UseSession(); //! Related to authentication with session


      

        app.MapControllerRoute(
            "default",
            "/{id?}",
            new { controller = "Home", action = "Index" });

        app.MapControllerRoute(
            "SignInRoute",
            "Account/SignIn",
            new { controller = "Account", action = "SignIn" });

        app.MapControllerRoute(
            "SignUpRoute",
            "Account/SignUp",
            new { controller = "Account", action = "SignUp" });

        app.MapControllerRoute(
            "SignUpRoute",
            "Account/SignIn",
            new { controller = "Account", action = "SignIn" });

        app.MapControllerRoute(
            "DetailsRouting",
            "Details/{newsId}",
            new { controller = "Details", action = "Index" });

        app.MapControllerRoute(
            "AddNewsRouting",
            "News/AddNews",
            new { controller = "News", action = "AddNews" });

       


        app.Run();
    }
}