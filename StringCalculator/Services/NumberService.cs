using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Services
{


    public class NumberService : INumberService
    {
        private List<string> _delimiters = new List<string>() { ",", "\n" };
        private string[] _delimiterSurroundingStrings = { "[", "][", "]" };
        private string[] _stringNumbers;

        private const string DelimiterStartString = "//";

        public List<int> ParseNumbers(string inputString)
        {
            ExtractDelimitersAndNumbers(inputString);

            var parsedNumbers = ValidateAndParseNumbers();

            return parsedNumbers;
        }

        private void ExtractDelimitersAndNumbers(string inputString)
        {
            if (inputString.StartsWith(DelimiterStartString))
            {
                inputString = inputString.Remove(0, 2);

                var delimtersAndNumbers = inputString.Split(_delimiters[1], StringSplitOptions.RemoveEmptyEntries);

                var allDelimiters = delimtersAndNumbers[0].Split(_delimiterSurroundingStrings, StringSplitOptions.RemoveEmptyEntries);

                _delimiters.AddRange(allDelimiters);

                _stringNumbers = delimtersAndNumbers[1].Split(_delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                _stringNumbers = inputString.Split(_delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private List<int> ValidateAndParseNumbers()
        {
            var listOfIntergerNumbers = new List<int>();

            foreach (var number in _stringNumbers)
            {
                var parsedNumber = int.Parse(number);

                listOfIntergerNumbers.Add(parsedNumber);
            }

            return listOfIntergerNumbers;
        }
    }
}
