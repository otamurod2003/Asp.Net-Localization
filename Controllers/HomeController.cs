using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace Localization.Controllers
{
    public class HomeController :Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
