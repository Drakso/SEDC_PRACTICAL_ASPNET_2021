using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Validators
{
	public interface IValidator
	{
		void CheckIfNumberIsInRange(List<int> numbers);
		void CheckIfNumberIsNegative(List<int> numbers);
	}
}
