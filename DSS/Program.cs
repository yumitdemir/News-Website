
namespace DSS
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");



            app.MapControllerRoute(
                name: "SignInRoute",
                pattern: "Login/SignIn",
                defaults: new { controller = "Login", action = "SignIn" });

            app.MapControllerRoute(
                name: "SignUpRoute",
                pattern: "Login/SignUp",
                defaults: new { controller = "Login", action = "SignUp" });

            app.MapControllerRoute(
                name: "DetailsRouting",
                pattern: "Details/{id}",
                defaults: new { controller = "Details", action = "Index" });

            app.Run();
        }
    }
}