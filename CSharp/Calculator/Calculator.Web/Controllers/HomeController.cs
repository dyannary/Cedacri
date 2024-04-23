using Microsoft.AspNetCore.Mvc;
using Calculator.Algorithm;
using Calculator.Web.Models;

namespace Calculator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly DijkstraTwoStack _dijkstraTwoStack;

        public HomeController(DijkstraTwoStack dijkstraTwoStack)
        {
            _dijkstraTwoStack = dijkstraTwoStack;
        }

        public ActionResult Index(CalculatorModel calculatorModel)
        {
            return View(calculatorModel);
        }

        [HttpPost]
        public ActionResult CalculateExpression(string expression, string value)
        {
            try
            {
                if(value == "clear")
                {
                    expression = "";
                }
                else if(value == "clearLast")
                {
                    if(!string.IsNullOrEmpty(expression))
                        expression = expression.Remove(expression.Length - 1, 1);
                }
                else if(value == "calculate")
                {
                    expression = (_dijkstraTwoStack.Calculate(expression)).ToString();
                }
                else
                {
                    if (IsArithmeticOperator(value))
                    {
                        if (!string.IsNullOrEmpty(expression) && (expression.Length == 0 || !IsArithmeticOperator(expression[expression.Length - 1].ToString())))
                        {
                            expression += value;
                        }
                        else if (!string.IsNullOrEmpty(expression))
                        {
                            expression = expression.Remove(expression.Length - 1) + value;
                        }
                    }
                    else
                    {
                        expression += value;
                    }
                }

                CalculatorModel calculatorModel = new CalculatorModel();

                calculatorModel.Expression = expression;

                return View("Index", calculatorModel);
            }
            catch (Exception ex)
            {
                CalculatorModel errorModel = new CalculatorModel();
                errorModel.errorMessage = ex.Message;
                return View("Index", errorModel);
            }
        }

        private bool IsArithmeticOperator(string value)
        {
            return value == "+" || value == "-" || value == "×" || value == "÷";
        }
    }
}
