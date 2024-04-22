namespace Calculator.Web;

public class CalculatorService
{
    public void ClearScreen(string expression, string clear, string delete)
    {
        if (!string.IsNullOrEmpty(clear))
        {
            expression = string.Empty;
        }
        else if (!string.IsNullOrEmpty(delete))
        {
            if (!string.IsNullOrEmpty(expression))
            {
                expression = expression.Remove(expression.Length - 1);
            }
        }
        else
        {
            // Other button clicked, handle accordingly
           // expression += Request.Form["buttonValue"];
        }
    }

}
