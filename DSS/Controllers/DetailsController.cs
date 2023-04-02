using Microsoft.AspNetCore.Mvc;

namespace DSS.Controllers
{
    public class DetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
