using SmartCalculator.ConcreteStrategy;

namespace Calculator.Tests
{
    public class BalancedBrackets
    {
        DijkstraTwoStack calculate = new DijkstraTwoStack();

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { "2+10-2*(2+3)", 2 };
            yield return new object[] { "3+10-2*(2+3)", 3 };
            yield return new object[] { "4+10-2*(2+3)", 4 };
            yield return new object[] { "5+10-2*(2+3)", 5 };
        }

        public static IEnumerable<object[]> WrongData()
        {
            yield return new object[] { "2+10-2*(2+3))", 2 };
            yield return new object[] { "3+10-2*(2+3", 3 };
            yield return new object[] { "4+10-2(2+3)", 4 };
            yield return new object[] { "5+10-2*(-1-(2+3)", 5 };
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void BalancedBrakets(string expression, int expected)
        {
            int result = calculate.Calculate(expression);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(WrongData))]
        public void WrongExpression(string expression, int expected)
        {
            int result = calculate.Calculate(expression);

            Assert.Equal(expected, result);
        }
    }
}

