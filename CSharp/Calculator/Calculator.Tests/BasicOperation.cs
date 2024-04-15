using Calculator.Algorithm;

namespace CalculatorTests
{
    public class Tests()
    {
        DijkstraTwoStack calculate = new DijkstraTwoStack();

        [Fact]
        public void AddTwoNumbers()
        {
            Assert.Equal(8, calculate.Calculate($"3+5"));
        }

        [Fact]
        public void SubstractTwoNumbers()
        {
            Assert.Equal(-5, calculate.Calculate($"3-8"));
        }

        [Fact]
        public void MultiplyTwoNumbers()
        {
            Assert.Equal(42, calculate.Calculate($"7*6"));
        }

        [Fact]
        public void DivideTwoNumbers()
        {
            Assert.Equal(4, calculate.Calculate($"8/2"));
        }

        [Fact]
        public void Divide_TwoNumbers_ExpectException()
        {
            Assert.Throws<InvalidOperationException>(() => calculate.Calculate("10/0"));
        }
    }
}