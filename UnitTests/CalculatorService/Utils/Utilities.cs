using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Utils
{
	public class Utilities : IUtilities
	{
		public int ConvertStringToInt(string strNumber)
		{
			var isConverted = int.TryParse(strNumber, out var result);
			if (isConverted) return result;
			throw new Exception("Convert failed. You must enter a valid number!");
		}
	}
}
