using Microsoft.AspNetCore.Http;

namespace DSS.Service.AuthService
{
    public class AuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? getSesionName()
        {
            return _httpContextAccessor.HttpContext.Session.GetString("username");
        }
    }
}
