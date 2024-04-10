using SmartCalculator.Interfaces;

namespace SmartCalculator
{
    public class Context
    {
        private IOperation _operation;

        public Context(IOperation operation)
        {
            _operation = operation;
        }

        public void SetStrategy(IOperation operation)
        {
            _operation = operation;
        }

        public int Execute(int a, int b)
        {
            return _operation.Calculate(a, b);
        }
    }
}
