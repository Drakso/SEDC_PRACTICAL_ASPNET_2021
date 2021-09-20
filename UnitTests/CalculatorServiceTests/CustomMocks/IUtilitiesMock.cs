using CalculatorService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorServiceTests.CustomMocks
{
    public interface IUtilitiesMock : IUtilities
    {
        void Executes(Action expression);
        void Returns(int number);
    }
}
