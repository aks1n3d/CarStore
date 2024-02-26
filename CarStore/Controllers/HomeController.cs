using Microsoft.AspNetCore.Mvc;

namespace CarStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
