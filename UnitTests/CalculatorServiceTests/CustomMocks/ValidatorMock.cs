using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorServiceTests.CustomMocks
{
    public class ValidatorMock : IValidatorMock
    {
        private Action ConvertExpression;

        public void CheckIfNumberIsInRange(List<int> numbers)
        {
            ConvertExpression?.Invoke();
        }

        public void CheckIfNumberIsNegative(List<int> numbers)
        {
            ConvertExpression?.Invoke();
        }

        public void Executes(Action expression)
        {
            ConvertExpression = expression;
        }
    }
}
