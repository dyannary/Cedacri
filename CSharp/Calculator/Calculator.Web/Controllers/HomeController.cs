using Microsoft.AspNetCore.Mvc;
using Calculator.Algorithm;
using Calculator.Web.Models;

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


        public ActionResult Index(CalculatorModel calculatorModel)
        {
            return View(calculatorModel);
        }

        [HttpPost]
        public ActionResult CalculateExpression(string expression)
        {
            try
            {

                expression = (_dijkstraTwoStack.Calculate(expression)).ToString();

                CalculatorModel calculatorModel = new CalculatorModel();

                calculatorModel.Expression = expression;

                return View("Index", calculatorModel);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error calculating expression: {ex.Message}");
            }
        }

    }
}
