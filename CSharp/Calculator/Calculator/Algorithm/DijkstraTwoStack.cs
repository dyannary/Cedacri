using System.Text;

namespace Calculator.Algorithm
{
    public class DijkstraTwoStack
    {
        public int Calculate(string expession)
        {
            char[] tokens = expession.ToCharArray();

            Stack<char> ops = new Stack<char>();
            Stack<int> values = new Stack<int>();

            for (var i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == ' ')
                {
                    continue;
                }
                if (tokens[i] >= '0' && tokens[i] <= '9')
                {
                    StringBuilder buf = new StringBuilder();

                    while (i < tokens.Length && tokens[i] >= '0' && tokens[i] <= '9')
                    {
                        buf.Append(tokens[i++]);
                    }

                    values.Push(int.Parse(buf.ToString()));

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
                }
                else if(tokens[i] == '+' ||
                        tokens[i] == '-' ||
                        tokens[i] == '*' ||
                        tokens[i] == '/')
                {
                    while(ops.Count > 0 && hasPrecedence(tokens[i],
                                 ops.Peek()))
                    {
                        values.Push(Operation(ops.Pop(), values.Pop(), values.Pop()));
                    }

                    ops.Push(tokens[i]);
                }
            }
            while(ops.Count > 0)
            {
                values.Push(Operation(ops.Pop(),
                         values.Pop(),
                        values.Pop()));
            }

            return values.Pop();
        }
        static int Operation(int op, int b, int a)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        throw new
                        System.NotSupportedException(
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
