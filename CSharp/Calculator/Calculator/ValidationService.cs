using System.Text.RegularExpressions;

namespace Calculator
{
    public class ValidationService
    {
        public ValidationService()
        { }

        public static void ValidateExpression(string expression)
        {
            if (string.IsNullOrEmpty(expression) || expression == "00 ")
                throw new ArgumentException("The expression cannot be empty.");


            if (ContainsWords(expression))
            {
                throw new ArgumentException("The expression cannot contain words.");
            }

            if (!UnbalancedBrakets(expression))
            {
                throw new ArgumentException("The brackets are unbalanced.");
            }

            if (DuplicateOperands(expression))
            {
                throw new ArgumentException("Operand should not repeat twice or more.");
            }

            if (DivideZero(expression))
            {
                throw new ArgumentException("Division by zero does not exist.");
            }

            if (BracketsAfterDigit(expression))
            {
                throw new ArgumentException("Cannot add bracket after digit. Place * to multiply.");
            }

            Console.ResetColor();
        }

        public static bool ContainsWords(string expression)
        {
            return Regex.IsMatch(expression, "[a-zA-Z!@#$%&=';,]");
        }

        public static bool UnbalancedBrakets(string expression)
        {
            int count = expression.Count(c => c == '(') - expression.Count(c => c == ')');
            return count == 0;
        }

        public static bool DuplicateOperands(string expression)
        {
            return Regex.IsMatch(expression, @"([+*]{2})+");
        }

        public static bool DivideZero(string expression)
        {
            return Regex.IsMatch(expression, @"\/0");
        }
        public static bool BracketsAfterDigit(string expression)
        {
            return Regex.IsMatch(expression, @"\d\(");
        }
    }
}
