using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorServiceTests.CustomMocks
{
    public class UtilitiesMock : IUtilitiesMock
    {
        private Action ConvertExpression;
        private readonly Queue<int> ConvertResult = new Queue<int>();
        public int ConvertStringToInt(string str)
        {
            ConvertExpression?.Invoke();
            return ConvertResult.Dequeue();
        }

        public void Executes(Action expression)
        {
            ConvertExpression = expression;
        }

        public void Returns(int number)
        {
            ConvertResult.Enqueue(number);
        }
    }
}
