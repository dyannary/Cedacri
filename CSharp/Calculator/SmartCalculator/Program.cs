using SmartCalculator;
using SmartCalculator.ConcreteStrategy;
using SmartCalculator.Operations;

var a = -8;
var b = 6;

Context context;

context = new Context(new Addition());
int addition = context.Execute(a, b);

context = new Context(new Substraction());
int substraction = context.Execute(a, b);

context = new Context(new Multiplication());
int multiplication = context.Execute(a, b);

context = new Context(new Division());
int division = context.Execute(a, b);

Console.WriteLine(addition);
Console.WriteLine(substraction);
Console.WriteLine(multiplication);
Console.WriteLine(division);

Console.WriteLine();

DijkstraTwoStack calculate = new DijkstraTwoStack();

ConsoleKey input;
string expression;

int result = 0;

while (true)
{
    if (result != 0)
        Console.Write(result);
    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

    if (keyInfo.Key == ConsoleKey.Escape)
        return 0;
#pragma warning disable CS8600
    expression = result + " " + Console.ReadLine();
#pragma warning restore CS8600

    if (expression is null)
    {
        return 0;
    }

    result = calculate.Calculate(expression);


    Console.WriteLine("Result is: " + result);
}