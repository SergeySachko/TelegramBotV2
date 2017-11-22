using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.BBLInteface;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataFactory dataFactory;

        public HomeController(IDataFactory _dataFactory)
        {
            dataFactory = _dataFactory;
        }
        public IActionResult Index()
        {
            dataFactory.UpdateHeroesInfo();
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
