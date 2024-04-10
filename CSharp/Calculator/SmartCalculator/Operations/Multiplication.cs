using SmartCalculator.Interfaces;

namespace SmartCalculator.Operations
{
    public class Multiplication : IOperation
    {
        public int Calculate(int firstNum, int secondNum)
        {
            return firstNum * secondNum;
        }
    }
}
