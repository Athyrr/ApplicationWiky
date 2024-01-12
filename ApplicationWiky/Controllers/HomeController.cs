using ApplicationWiky.Models;
using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ApplicationWiky.Controllers
{
    public class HomeController : Controller
    {
        IArticleBusiness _articleBusiness;



        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IArticleBusiness articleBusiness)
        {
            _logger = logger;
            _articleBusiness = articleBusiness;
        }

        public async Task<IActionResult> Index()
           => View(await _articleBusiness.GetLastArticleAsync());


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
