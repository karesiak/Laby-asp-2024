using Laboratorium_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_2.Controllers
{ 
    public class BirthController : Controller
    {
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result(BirthModel model)
        {
            if (model.IsValid())
            {
                ViewBag.Message = $"Cześć {model.Name}, masz {model.Age()} lat(a).";
                return View("Result");
            }
            return View("Error");
        }
    }
}
