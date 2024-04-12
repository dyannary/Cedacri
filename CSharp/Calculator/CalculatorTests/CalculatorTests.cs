using SmartCalculator.ConcreteStrategy;
using Xunit;

namespace CalculatorTests
{
    public class Tests
    {
        [Fact]
        public void AddTwoNumbers(int a, int b, int expected)
        {
            DijkstraTwoStack calculate = new DijkstraTwoStack();

            int actual = calculate.Calculate($"{a} + {b}");

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Fact]
        public void SubstractTwoNumbers(int a, int b, int expected)
        {
            DijkstraTwoStack calculate = new DijkstraTwoStack();

            int actual = calculate.Calculate($"{a} - {b}");

            Assert.Equals(expected, actual);
        }

        [Fact]
        public void MultiplyTwoNumbers(int a, int b, int expected)
        {
            DijkstraTwoStack calculate = new DijkstraTwoStack();

            int actual = calculate.Calculate($"{a} * {b}");

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Fact]
        public void DivideTwoNumbers(int a, int b, int expected)
        {
            DijkstraTwoStack calculate = new DijkstraTwoStack();

            int actual = calculate.Calculate($"{a} * {b}");

            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}