using Calculator.Algorithm;

namespace Calculator.Web.Services;

public class CalculatorService
{
    private readonly DijkstraTwoStack _dijkstraTwoStack;
    public CalculatorService(DijkstraTwoStack dijkstraTwoStack)
    {

        _dijkstraTwoStack = dijkstraTwoStack;
    }

    public string CleanExpression()
    {
        return "";
    }
    public string ClearLastCharacter(string expression)
    {
        if (!string.IsNullOrEmpty(expression))
        {
            expression = expression.Remove(expression.Length - 1, 1);
        }
        return expression;
    }

    public string CalculateResult(string expression)
    {
        return _dijkstraTwoStack.Calculate(expression).ToString();
    }

    public string AddDecimal(string expression, string value)
    {
        string[] numbers = expression.Split(new char[] { '+', '-', '×', '÷' });
        bool flag = true;

        foreach (string num in numbers)
        {
            if (!num.Contains("."))
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
        if(flag is true)
        {
            expression += value;
        }
        return expression;
    }

    public string UpdateExpression(string expression, string value)
    {
        if (IsArithmeticOperator(value))
        {
            if (string.IsNullOrEmpty(expression))
            {
                expression += 0 + value;
            }
            else if (!string.IsNullOrEmpty(expression) && (expression.Length == 0 || !IsArithmeticOperator(expression[expression.Length - 1].ToString())))
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
            if (!string.IsNullOrEmpty(expression) && expression[expression.Length - 1].ToString() == "0" && value != ")" && value != "(")
            {
                expression = expression.Remove(expression.Length - 1) + value;
            }
            else if (expression == "Infinity")
            {
                expression = value;
            }
            else
            {
                expression += value;
            }
        }
        return expression;
    }

    private bool IsArithmeticOperator(string value)
    {
        return value == "+" || value == "-" || value == "×" || value == "÷" || value == ".";
    }
}
