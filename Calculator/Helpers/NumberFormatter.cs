using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Helpers
{
    public class NumberFormatter : INumberFormatter
    {
        private string[] _defaultSeparators = { ",", "\n" };
        private string[] _delimiterSurroundingStrings = { "//", "[", "][", "]" };
        public List<int> ParseNumbers(string numbers)
        {
            var splitNumbers = SplitString(numbers, _defaultSeparators);
            return splitNumbers.Select(x => int.Parse(x)).ToList(); 
        }

        public IEnumerable<string> SplitString(string numbers, string[] delimiters)
        {
            return numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        public IEnumerable<string> GetDelimiters(string stringOfNumbersIncludingDelimiters)
        {
            var delimiters = SplitString(stringOfNumbersIncludingDelimiters, new string[] { _defaultSeparators[1] }).ToList();
            var formattedDelimiters = delimiters[0].Split(_delimiterSurroundingStrings, StringSplitOptions.RemoveEmptyEntries);

            var allDelimiters = new List<string>(_defaultSeparators);
            allDelimiters.AddRange(formattedDelimiters);

            return allDelimiters;
        }
    }
}
