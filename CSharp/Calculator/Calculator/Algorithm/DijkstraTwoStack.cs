﻿using System.Text;

namespace Calculator.Algorithm
{
    public class DijkstraTwoStack
    {
        public decimal Calculate(string expression)
        {
            char[] tokens = expression.ToCharArray();

            Stack<char> ops = new Stack<char>();
            Stack<decimal> values = new Stack<decimal>();

            for (var i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == ' ')
                {
                    continue;
                }
                if (char.IsDigit(tokens[i]) || tokens[i] == '.')
                {
                    StringBuilder buf = new StringBuilder();

                    while (i < tokens.Length && (char.IsDigit(tokens[i]) || tokens[i] == '.'))
                    {
                        buf.Append(tokens[i++]);
                    }

                    values.Push(decimal.Parse(buf.ToString()));

                    i--;
                }

                else if (tokens[i] == '(')
                { 
                    ops.Push(tokens[i]);
                }
                else if (tokens[i] == ')')
                {
                    while (ops.Peek() != '(')
                    {
                        values.Push(Operation(ops.Pop(), values.Pop(), values.Pop()));
                    }
                    ops.Pop();

                    if (ops.Count > 0 && ops.Peek() == '-')
                    {
                        values.Push(-values.Pop()); // Negate the result if the previous operation was unary minus
                        ops.Pop(); // Pop the unary minus operator
                    }
                    
                }
                else if (tokens[i] == '+' ||
                        tokens[i] == '-' ||
                        tokens[i] == '*' ||
                        tokens[i] == '/' ||
                        tokens[i] == '.')
                {
                    while (ops.Count > 0 && hasPrecedence(tokens[i],
                                 ops.Peek()))
                    {
                        if (values.Count < 2)
                        {
                            new InvalidOperationException("Not enough operands for operation.");
                            break;
                        }
                        else
                            values.Push(Operation(ops.Pop(), values.Pop(), values.Pop()));
                    }

                    ops.Push(tokens[i]);
                }
                else
                {
                    new InvalidDataException("Not enough operands for operation.");
                }
            }
            while (ops.Count > 0)
            {
                try
                {
                    values.Push(Operation(ops.Pop(),
                         values.Pop(),
                        values.Pop()));
                }
                catch
                {
                    throw new
                        System.InvalidOperationException(
                               "Argument exception");
                }
            }

            return values.Pop();
        }
        static decimal Operation(decimal op, decimal b, decimal a)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    if (a < 0)
                    {
                        return a - b;
                    }
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        throw new
                        System.InvalidOperationException(
                               "Cannot divide by zero");
                    }
                    return a / b;
            }
            return 0;
        }

        static bool hasPrecedence(char op1, char op2)
        {
            if (op2 == '(' || op2 == ')')
            {
                return false;
            }
            if ((op1 == '*' || op1 == '/') &&
                   (op2 == '+' || op2 == '-'))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
