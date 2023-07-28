using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Helpers
{
    public class NumberFormatter : INumberFormatter
    {
        private string[] DefaultDelimiters = { ",", "\n" };
        private string[] DelimiterSurroundingStrings = { "//", "[", "][", "]" };

        public List<int> ParseNumbers(string numbers)
        {
            IEnumerable<string> stringOfNumbers;

            if (numbers.StartsWith("//"))
            {
                var delimiters = GetDelimiters(numbers);
                var numbersWithDelimiters = GetNumbersWithDelimiters(numbers);
                stringOfNumbers = numbersWithDelimiters.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                stringOfNumbers = numbers.Split(DefaultDelimiters, StringSplitOptions.RemoveEmptyEntries);
            }
            
            return stringOfNumbers.Select(x => int.Parse(x)).ToList(); 
        }

        public IEnumerable<string> SplitString(string numbers, IEnumerable<string> delimiters)
        {
            return numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        public IEnumerable<string> GetDelimiters(string stringOfNumbersIncludingDelimiters)
        {
            var delimitersAndNumbers = SplitString(stringOfNumbersIncludingDelimiters, new string[] { DefaultDelimiters[1] }).ToList();
            var formattedDelimiters = delimitersAndNumbers[0].Split(DelimiterSurroundingStrings, StringSplitOptions.RemoveEmptyEntries);

            var allDelimiters = new List<string>(DefaultDelimiters);
            allDelimiters.AddRange(formattedDelimiters);

            return allDelimiters;
        }

        public string GetNumbersWithDelimiters(string stringOfNumbersIncludingDelimiters)
        {
            var numbersWithDelimiters =  stringOfNumbersIncludingDelimiters.Split(DefaultDelimiters[1], StringSplitOptions.RemoveEmptyEntries);

            return numbersWithDelimiters[1];
        }
    }
}
