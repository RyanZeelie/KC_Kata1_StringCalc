using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Helpers
{
    public class NumberFormatter : INumberFormatter
    {
        private string[] _defaultDelimiters = { ",", "\n" };
        private string[] _delimiterSurroundingStrings = { "//", "[", "][", "]" };
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
                stringOfNumbers = numbers.Split(_defaultDelimiters,StringSplitOptions.RemoveEmptyEntries);
            }
            
            return stringOfNumbers.Select(x => int.Parse(x)).ToList(); 
        }

        public IEnumerable<string> SplitString(string numbers, IEnumerable<string> delimiters)
        {
            return numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        public IEnumerable<string> GetDelimiters(string stringOfNumbersIncludingDelimiters)
        {
            var delimitersAndNumbers = SplitString(stringOfNumbersIncludingDelimiters, new string[] { _defaultDelimiters[1] }).ToList();
            var formattedDelimiters = delimitersAndNumbers[0].Split(_delimiterSurroundingStrings, StringSplitOptions.RemoveEmptyEntries);

            var allDelimiters = new List<string>(_defaultDelimiters);
            allDelimiters.AddRange(formattedDelimiters);

            return allDelimiters;
        }

        public string GetNumbersWithDelimiters(string stringOfNumbersIncludingDelimiters)
        {
            var numbersWithDelimiters =  stringOfNumbersIncludingDelimiters.Split(_defaultDelimiters[1], StringSplitOptions.RemoveEmptyEntries);
            return numbersWithDelimiters[1];
        }
    }
}
