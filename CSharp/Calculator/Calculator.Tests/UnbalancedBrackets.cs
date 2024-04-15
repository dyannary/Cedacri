using Calculator.Algorithm;

namespace Calculator.Tests
{
    public class UnbalancedBrackets
    {
        DijkstraTwoStack calculate = new DijkstraTwoStack();

        public static IEnumerable<object[]> WrongData()
        {
            yield return new object[] { "2+10-2*(2+3))"};
            yield return new object[] { "3+10-2*(2+3"};
            yield return new object[] { "4+10-2(2+3)"};
            yield return new object[] { "5+10-2*(-1-(2+3)"};
        }

        [Theory]
        [MemberData(nameof(WrongData))]
        public void WrongExpression(string expression)
        {
            Assert.Throws<InvalidOperationException>(() => calculate.Calculate(expression));
        }
    }
}
