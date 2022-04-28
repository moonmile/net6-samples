using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            var model = new HelloModel();
            model.Name = "Tomoaki Masuda";
            model.Now = DateTime.Now;
            return View(model);
        }
    }
}
