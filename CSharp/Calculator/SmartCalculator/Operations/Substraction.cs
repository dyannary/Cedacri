using SmartCalculator.Interfaces;

namespace SmartCalculator.Operations
{
    public class Substraction : IOperation
    {
        public int Calculate(int firstNum, int secondNum)
        {
            return firstNum - secondNum;
        }
    }
}
