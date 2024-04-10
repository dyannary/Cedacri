using PracticeLinq;
using System.Runtime.CompilerServices;

Color color = new Color();

var myArray = new int[] { 1, 5, -1, 3 };

color.WriteRed("Sum elements except duplicates.");

Console.ResetColor();

SumNoDuplicates(myArray);

static void SumNoDuplicates(int[] arr)
{
    var sum = arr.GroupBy(x => x).Where(x => x.Count() == 1).Select(x => x.Key).Sum();
    Console.WriteLine("Sum is: " + sum);
}

color.WriteRed("\nSum of positive numbers and negative numbers.");

CountPositivesSumNegatives(myArray);
static void CountPositivesSumNegatives(int[] input)
{
    int[] result;

    Console.WriteLine("Sum of positive is: " + input.Where(x=>x>0).Sum());
    Console.WriteLine("Sum of negative is: " + input.Where(x=>x<0).Sum());


    Console.WriteLine(input.Where(x=>x>0).Sum());
}

color.WriteRed("\nReverse given number from the largest diget to smallest.");

int value = 145263;

Console.WriteLine($"Reversed by descending value for {value} is {DescendingOrder(value)}");

static int DescendingOrder(int num)
{
    return int.Parse(num.ToString().ToCharArray().OrderByDescending(x=>x).ToArray());
}

color.WriteRed("\nCount duplicates from a string.");

string str = "aaBbcde";

Console.WriteLine($"In {str} are {DuplicateCount(str)} duplicates.");

static int DuplicateCount(string str)
{
    return str.GroupBy(x => x).Where(x => x.Count() > 1).Count();
}

color.WriteRed("\nHas string the same amount of 'x' and 'o'?");

string xoStr = "xOoxxo";

Console.WriteLine(XO(xoStr));

static bool XO(string input)
{
    return input.ToLower()
                .Where(i => i == 'o')
                .Count()
                .Equals(input.ToLower()
                             .Where(o => o == 'x')
                             .Count());;
}

color.WriteRed("\nDuplicate Encoder");

string encoder = "recede";

Console.WriteLine(DuplicateEncode(encoder));

static string DuplicateEncode(string word)
{
    return new string(word.Select(c=>word
                                .Count(x=>char.ToLower(x) == char.ToLower(c)) == 1 ? '(' : ')')
                                .ToArray());
}

color.WriteRed("\nAdd binary");

int a = 5, b = 9;

Console.WriteLine(AddBinary(a, b));

static string AddBinary(int a, int b)
{
    return Convert.ToString(a + b, 2);
}
