//int[] elements = {1, 2, 3, 12, 5, 76, 2, 3, 3};

//var query = (from e in elements
//            where e < 10
//            where e > 0
//            orderby e  
//            select e).Distinct();

//var queryMethod = elements.Where(x => x > 0 && x < 10).OrderBy(x=>x).Distinct();

//foreach (var element in query)
//{
//    Console.WriteLine(element);
//}

//Console.WriteLine("Method: ");
//foreach (var element in queryMethod)
//{
//    Console.WriteLine(element);
//}

//var squareNum = from int Number in elements
//                let SqrNo = Number*Number
//                select new { Number, SqrNo };                                                                                                                                                                                                                                                                                                                                                     

//var squareNumMethod = elements.Select(Number => new {Number, SqrNo = Number * Number });

//foreach (var element in squareNum)
//{
//    Console.WriteLine(element);
//}

//Console.WriteLine("Method: ");
//foreach (var element in squareNumMethod)
//{
//    Console.WriteLine(element);
//}

//var frequencyNum = elements.Where(x => x > 0 && x < 10).GroupBy(x => x).Select(Number => new { Number.Key, appeares = Number.Count()});

//Console.WriteLine("Frequency");
//foreach (var element in frequencyNum)
//{
//    Console.WriteLine(element);
//}






using PracticeLinq;

int[] array = { 10, -2, 7, 54, -3, 2 };


var result = from a in array
             where a < 0
             let Sqr = a * a
             let l = "  -  "
             select new {a, l, Sqr};

array[2] = 10;

foreach (var item in result)
{
    Console.WriteLine(item.a + item.l + item.Sqr);
}







































//Color color = new Color();

//var myArray = new int[] { 1, 5, -1, 3 , 4};

//color.WriteRed("Sum elements except duplicates.");

//Console.ResetColor();

//SumNoDuplicates(myArray);

//static void SumNoDuplicates(int[] arr)
//{
//    var sum = arr.GroupBy(x => x).Where(x => x.Count() == 1).Select(x => x.Key).Sum();
//    Console.WriteLine("Sum is: " + sum);
//}

//color.WriteRed("\nSum of positive numbers and negative numbers.");

//CountPositivesSumNegatives(myArray);
//static void CountPositivesSumNegatives(int[] input)
//{
//    int[] result;

//    Console.WriteLine("Sum of positive is: " + input.Where(x=>x>0).Sum());
//    Console.WriteLine("Sum of negative is: " + input.Where(x=>x<0).Sum());


//    Console.WriteLine(input.Where(x=>x>0).Sum());
//}

//color.WriteRed("\nReverse given number from the largest diget to smallest.");

//int value = 145263;

//Console.WriteLine($"Reversed by descending value for {value} is {DescendingOrder(value)}");

//static int DescendingOrder(int num)
//{
//    return int.Parse(num.ToString().ToCharArray().OrderByDescending(x=>x).ToArray());
//}

//color.WriteRed("\nCount duplicates from a string.");

//string str = "aaBbcde";

//Console.WriteLine($"In {str} are {DuplicateCount(str)} duplicates.");

//static int DuplicateCount(string str)
//{
//    return str.GroupBy(x => x).Where(x => x.Count() > 1).Count();
//}

//color.WriteRed("\nHas string the same amount of 'x' and 'o'?");

//string xoStr = "xOoxxo";

//Console.WriteLine(XO(xoStr));

//static bool XO(string input)
//{
//    return input.ToLower()
//                .Where(i => i == 'o')
//                .Count()
//                .Equals(input.ToLower()
//                             .Where(o => o == 'x')
//                             .Count());;
//}

//color.WriteRed("\nDuplicate Encoder");

//string encoder = "recede";

//Console.WriteLine(DuplicateEncode(encoder));

//static string DuplicateEncode(string word)
//{
//    return new string(word.Select(c=>word
//                                .Count(x=>char.ToLower(x) == char.ToLower(c)) == 1 ? '(' : ')')
//                                .ToArray());
//}

//color.WriteRed("\nAdd binary");

//int a = 5, b = 9;

//Console.WriteLine(AddBinary(a, b));

//static string AddBinary(int a, int b)
//{
//    return Convert.ToString(a + b, 2);
//}

//myArray
//var result = (from element 
//             in myArray
//             where element % 2 != 0
//             select element).Sum();

//Console.WriteLine("sum is: " + result);

//string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

//var selectedPeople = from p in people
//                     where p.ToUpper().StartsWith("T")
//                     orderby p
//                     select p;

//var selectedPeopleMethod = people.Where(p => p.ToUpper().StartsWith("T")).OrderBy(p => p);

//foreach(var person in selectedPeopleMethod)
//{
//    Console.Write(person + " ");
//}

//int[] numbers = { 1, 39, 10, 3 };

//var evenNumbers = (from n in numbers
//                  where n % 2 != 0
//                  select n).Count();

//var evenNumbersMethod = numbers.Where(n => n % 2 != 0).Sum();

//var numberContains = numbers.Where(x => x.ToString().Contains("1")).Count();

//Console.WriteLine(evenNumbersMethod);
//Console.WriteLine("Numbers contain 1: " + numberContains);

//var resultMethod 
//foreach (var item in result)
//{
//    Console.Write(item + " ");
//}




