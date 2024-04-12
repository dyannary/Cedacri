using SmartCalculator.ConcreteStrategy;

namespace CalculatorTests
{
    public class Tests()
    {
        DijkstraTwoStack calculate = new DijkstraTwoStack();

        [Fact]
        public void AddTwoNumbers()
        {
            int actual = calculate.Calculate($"3+5");

            Assert.Equal(8, actual);
        }

        [Fact]
        public void SubstractTwoNumbers()
        {
            int actual = calculate.Calculate($"3-8");

            Assert.Equal(-5, actual);
        }

        [Fact]
        public void MultiplyTwoNumbers()
        {
            int actual = calculate.Calculate($"7*6");

            Assert.Equal(42, actual);
        }

        [Fact]
        public void DivideTwoNumbers()
        {
            int actual = calculate.Calculate($"8/2");

            Assert.Equal(4, actual);
        }
    }
}