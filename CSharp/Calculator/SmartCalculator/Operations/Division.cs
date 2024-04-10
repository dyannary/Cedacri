using SmartCalculator.Interfaces;

namespace SmartCalculator.Operations
{
    public class Division : IOperation
    {
        public int Calculate(int firstNum, int secondNum)
        {
            if(secondNum == 0)
            {
                throw new
                System.NotSupportedException(
                       "Cannot divide by zero");
            }
            return firstNum / secondNum;
        }
    }
}
