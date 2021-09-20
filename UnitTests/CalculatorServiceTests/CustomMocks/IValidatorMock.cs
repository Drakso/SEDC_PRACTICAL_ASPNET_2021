using CalculatorService.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorServiceTests.CustomMocks
{
    public interface IValidatorMock : IValidator
    {
        void Executes(Action expression);
    }
}
