using Calculator;
using Calculator.Algorithm;

Colors color = new Colors();

color.WriteGrey("Calculate expression\n");

DijkstraTwoStack calculate = new DijkstraTwoStack();

string expression;

decimal result = 0;

while (true)
{
    try
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        if (keyInfo.Key == ConsoleKey.Escape)
            return 0;
#pragma warning disable CS8600
        expression = "0+" + Console.ReadLine();
#pragma warning restore CS8600
        ValidationService.ValidateExpression(expression);

        result = calculate.Calculate(expression);

        color.WriteGreen ("Result is: " + result);
    }
    catch (ArgumentException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Console.ResetColor();
    }
}