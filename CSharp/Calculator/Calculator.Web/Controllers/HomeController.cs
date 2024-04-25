using Microsoft.AspNetCore.Mvc;
using Calculator.Web.Models;
using Calculator.Web.Services;
using System.Text.RegularExpressions;

namespace Calculator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly CalculatorService _calculatorService;

        public HomeController(CalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public ActionResult Index(CalculatorModel calculatorModel)
        {
            //
            //ViewBag.Calc = calculatorModel.Expression;
            //ViewData["calc"] = calculatorModel.Expression;

            return View(calculatorModel);
        }

        [HttpPost]
        public ActionResult CalculateExpression(string expression, string value)
        {
            try
            {
                expression = value switch
                {
                    "clear" => expression = _calculatorService.CleanExpression(),
                    "clearLast" => expression = _calculatorService.ClearLastCharacter(expression),
                    "calculate" => expression = _calculatorService.CalculateResult(expression),
                    "." => expression = _calculatorService.AddDecimal(expression, value),
                    _ => expression = _calculatorService.UpdateExpression(expression, value)
                };
             
                CalculatorModel calculatorModel = new CalculatorModel();

                calculatorModel.Expression = expression;

                return View("Index", calculatorModel);
            }
            catch (Exception ex)
            {
                CalculatorModel errorModel = new CalculatorModel();
                if(Regex.IsMatch(expression, @"÷0"))
                {
                    errorModel.Expression = "Infinity";
                }
                else
                {
                    errorModel.errorMessage = ex.Message;
                    errorModel.Expression = expression;
                }
                return View("Index", errorModel);
            }
        }
    }
}
