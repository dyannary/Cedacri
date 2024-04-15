using Calculator.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Calculator;
using Calculator.Algorithm;

namespace Calculator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DijkstraTwoStack _dijkstraTwoStack;

        public HomeController(ILogger<HomeController> logger, DijkstraTwoStack dijkstraTwoStack)
        {
            _logger = logger;
            _dijkstraTwoStack = dijkstraTwoStack;
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculateExpression([FromBody] string expression)
        {
            try
            {
                var result = _dijkstraTwoStack.Calculate(expression);

                return Json(new { StatusCode = 200, result });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error calculating expression: {ex.Message}");
            }
        }
        
    }
}
