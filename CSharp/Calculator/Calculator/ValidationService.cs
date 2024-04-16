using System.Text.RegularExpressions;

namespace Calculator
{
    public class ValidationService
    {
        public ValidationService()
        { }

        public static void ValidateExpression(string expression)
        {
            // cand avem ++, --, +-, *-, /- etc

            if (string.IsNullOrEmpty(expression) || expression == "00 ")
                throw new ArgumentException("The expression cannot be empty.");


            if (ContainsWords(expression))
            {
                throw new ArgumentException("The expression cannot contain words.");
            }

            if (ValidateNumber(expression))
            {
                throw new ArgumentException("Number after decimal point should not greater than 12.");
            }

            if (!UnbalancedBrakets(expression))
            {
                throw new ArgumentException("The brackets are unbalanced.");
            }

            Console.ResetColor();
        }

        public static bool ContainsWords(string input)
        {
            return Regex.IsMatch(input, "[a-zA-Z!@#$%&=';.,]");
        }

        public static bool ValidateNumber(string expression)
        {
            return Regex.IsMatch(expression, @"^(?!(\d{10,}\.\d*|\d*\.\d{10,}))[0-9.+-/*]+$");
        }

        public static bool UnbalancedBrakets(string expression)
        {
            int count = expression.Count(c => c == '(') - expression.Count(c => c == ')');
            return count == 0;
        }
    }
}
