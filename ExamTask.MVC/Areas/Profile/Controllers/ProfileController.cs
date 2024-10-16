using Microsoft.AspNetCore.Mvc;

namespace ExamTask.MVC.Areas.Profile.Controllers
{
    [Area("Profile")]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
