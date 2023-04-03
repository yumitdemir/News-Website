using DSS.Data;
using DSS.Models;
using DSS.Sessions;
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
        builder.Services.AddScoped<IAccountService, AccountService>(); //! Related to authentication with session


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
            "{controller=Home}/{action=Index}/{id?}");


        app.MapControllerRoute(
            "SignInRoute",
            "Account/SignIn",
            new { controller = "Account", action = "SignIn" });

        app.MapControllerRoute(
            "SignUpRoute",
            "Account/SignUp",
            new { controller = "Account", action = "SignUp" });

        app.MapControllerRoute(
            "DetailsRouting",
            "Details/{id}",
            new { controller = "Details", action = "Index" });

        app.Run();
    }
}