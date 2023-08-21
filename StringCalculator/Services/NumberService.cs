namespace StringCalculator.Services
{
    public class NumberService : INumberService
    {
        private List<string> _delimiters = new List<string>() { ",", "\n" };
        private string[] _delimiterSurroundingStrings = { "[", "][", "]" };
        private string[] _stringNumbers;

        private const string DelimiterAndNumberSeperator = "\n";
        private const string DelimiterStartString = "//";
        private const int MaximumNumber = 1000;
        private const int DelimiterIndicatorIndex = 2;

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
                inputString = inputString.Substring(DelimiterIndicatorIndex);

                var delimtersAndNumbers = inputString.Split(DelimiterAndNumberSeperator, StringSplitOptions.RemoveEmptyEntries);

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

                if (parsedNumber < 0)
                {
                    throw new Exception("Negatives are not allowed");
                }
                else if (!(parsedNumber > MaximumNumber))
                {
                    listOfIntergerNumbers.Add(parsedNumber);
                }
            }

            return listOfIntergerNumbers;
        }
    }
}
