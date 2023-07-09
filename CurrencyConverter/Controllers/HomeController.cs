using CurrencyConverter.Models;
using CurrencyConverterClient;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CurrencyConverter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public  IActionResult Index(string result , string oldValue)
        {
            if(!string.IsNullOrEmpty(result))
                TempData["result"] = result;
            if (!string.IsNullOrEmpty(oldValue))
                TempData["oldValue"] = oldValue;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> ConvertString(ConvertRequest convertRequest)
        {
            try
            {
                var result = await ApiClientGrpc.Send(convertRequest.NumberString);
                return RedirectToAction(nameof(Index), new { Result = result.Message  , OldValue = convertRequest.NumberString });
            }
            catch(Exception ex)
            {
                return RedirectToAction(nameof(Index), new { Result = "Error in your string , please make sure that your string matches the conditions like: 999 999 767,56" , oldValue= convertRequest.NumberString });

            }

        }
    }
}