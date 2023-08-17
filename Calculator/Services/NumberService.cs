namespace Calculator.Services
{
    public class NumberService : INumberService
    {
        private string[] DefaultDelimiters = { ",", "\n" };
        private string[] DelimiterSurroundingStrings = { "//", "[", "][", "]" };

        public List<int> ParseNumbers(string numbers)
        {
            IEnumerable<string> stringOfNumbers;

            if (numbers.StartsWith("//"))
            {
                var delimiters = GetDelimiters(numbers);
                var numbersSeperatedByDelimiters = GetNumbersSeperatedByDelimiters(numbers);
                stringOfNumbers = numbersSeperatedByDelimiters.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                stringOfNumbers = numbers.Split(DefaultDelimiters, StringSplitOptions.RemoveEmptyEntries);
            }

            if(stringOfNumbers.Any(x => int.Parse(x) < 0))
            {
                throw new Exception("Negatives are not allowed");
            }

            return stringOfNumbers.Select(x => int.Parse(x)).Where(num => num < 1001).ToList(); 
        }

        private IEnumerable<string> GetDelimiters(string stringOfNumbersIncludingDelimiters)
        {
            var delimitersAndNumbers = stringOfNumbersIncludingDelimiters.Split(DefaultDelimiters[1], StringSplitOptions.RemoveEmptyEntries);
            var formattedDelimiters = delimitersAndNumbers[0].Split(DelimiterSurroundingStrings, StringSplitOptions.RemoveEmptyEntries);

            var allDelimiters = new List<string>(DefaultDelimiters);
            allDelimiters.AddRange(formattedDelimiters);

            return allDelimiters;
        }

        private string GetNumbersSeperatedByDelimiters(string stringOfNumbersIncludingDelimiters)
        {
            var numbersWithDelimiters =  stringOfNumbersIncludingDelimiters.Split(DefaultDelimiters[1], StringSplitOptions.RemoveEmptyEntries);

            return numbersWithDelimiters[1];
        }
    }
}
