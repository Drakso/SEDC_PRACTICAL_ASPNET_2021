using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Extension methods are available anywhere as long as we add the namespace to usings
namespace Examples
{
	public static class ExtensionClass
	{
		// The first parameter in extension methods is always of the type that we want to extend
		// The first parameter is always written with 'this' keyword before the parameter
		public static string Shorten(this string str, int shortenedWords)
		{
			if (shortenedWords == 0) return str;

			if (str.Length == 0) return "";

			string[] words = str.Split(' ');

			if (words.Length <= shortenedWords) return "";

			List<string> substring = words.Take(shortenedWords).ToList();
			
			string result = string.Join(" ", substring);

			return result + "...";
		}

		public static string QuoteString(this string str)
		{
			return '"' + str + '"';
		}

		public static void Execute()
		{
			string str = "Hey, this is the bob song. Yup. It's a Bob song. It is really awesome and everybody likes it!";

			// this string str gets the value from the variable str ( not as parameter )
			// shortenedWords must be passed as parameter
			Console.WriteLine(str.Shorten(6));
			Console.WriteLine(str.QuoteString());
		}
	}
}
