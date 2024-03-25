using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Laboratorium_2.Models;
using System.Collections.Generic;

namespace Laboratorium_2.Controllers
{
    public class ComputerController : Controller
    {
        static Dictionary<int, Computer> _computers = new Dictionary<int, Computer>();

        public IActionResult Index()
        {
            return View(_computers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Computer computer)
        {
            if (ModelState.IsValid)
            {
                int id = _computers.Keys.Count != 0 ? _computers.Keys.Max() + 1 : 1;
                computer.Id = id;
                _computers.Add(computer.Id, computer);

                return RedirectToAction("Index");
            }
            else
            {
                return View(computer);
            }
        }
    }
}
