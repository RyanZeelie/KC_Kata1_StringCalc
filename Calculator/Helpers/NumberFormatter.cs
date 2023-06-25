using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Helpers
{
    public class NumberFormatter : INumberFormatter
    {
        private string[] _defaultSeparators = { "," };
        public List<int> ParseNumbers(string numbers)
        {
            var splitNumbers = SplitNumbers(numbers);
            return splitNumbers.Select(x => int.Parse(x)).ToList(); 
        }

        public IEnumerable<string> SplitNumbers(string numbers)
        {
            return numbers.Split(_defaultSeparators, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
