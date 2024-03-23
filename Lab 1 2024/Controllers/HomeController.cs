using Lab_1_2024.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab_1_2024.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Calculator(string op, double? a, double? b)
        {
            // Przygotowanie wyniku do wyświetlenia
            string result;

            // Sprawdzanie, czy parametry a i b są dostarczone
            if (a.HasValue && b.HasValue)
            {
                double calculationResult = 0;
                bool validOperation = true;

                // Wykonywanie obliczeń w zależności od operatora
                switch (op)
                {
                    case "add":
                        calculationResult = a.Value + b.Value;
                        break;
                    case "sub":
                        calculationResult = a.Value - b.Value;
                        break;
                    case "mul":
                        calculationResult = a.Value * b.Value;
                        break;
                    case "div":
                        // Dodatkowe sprawdzenie, aby uniknąć dzielenia przez zero
                        calculationResult = b.Value != 0 ? a.Value / b.Value : double.NaN;
                        break;
                    default:
                        validOperation = false;
                        break;
                }

                if (validOperation)
                {
                    // Przygotowanie tekstu wyniku dla poprawnej operacji
                    result = $"Wynik działania dla {a} {op} {b} = {calculationResult}";
                }
                else
                {
                    // Komunikat o nieznanej operacji
                    result = "Nieznana operacja";
                }
            }
            else
            {
                // Komunikat o brakujących parametrach
                result = "Brakujące parametry a lub b";
            }

            // Przekazanie wyniku do widoku
            ViewBag.Result = result;
            return View();
        }
        public enum Operator
        {
            Add, Mul, Sub, Div, Unknow
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}