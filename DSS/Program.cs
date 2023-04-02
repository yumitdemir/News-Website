
using DSS.Models;
using DSS.Sessions;

namespace DSS
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(); //! Related to authentication with session
            builder.Services.AddScoped<IAccountService, AccountService>(); //! Related to authentication with session


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            

            app.UseSession(); //! Related to authentication with session



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");



            app.MapControllerRoute(
                name: "SignInRoute",
                pattern: "Account/SignIn",
                defaults: new { controller = "Account", action = "SignIn" });

            app.MapControllerRoute(
                name: "SignUpRoute",
                pattern: "Account/SignUp",
                defaults: new { controller = "Account", action = "SignUp" });

            app.MapControllerRoute(
                name: "DetailsRouting",
                pattern: "Details/{id}",
                defaults: new { controller = "Details", action = "Index" });

            app.Run();
        }
    }
}