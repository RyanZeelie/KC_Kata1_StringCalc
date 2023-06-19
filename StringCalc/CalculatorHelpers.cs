namespace StringCalc
{
    public static class CalculatorHelpers
    {
        private static readonly string[] Seperators = { "\n", ","};
        private static readonly string[] DelimiterStrings = { "//", "[", "][", "]" };
        public enum Defaults
        {
            DefaultValue = 0,
            MaxValue = 1000,
        }
        
        public static bool ValuesAreNullOrEmpty(string numbers)
        {
            return string.IsNullOrEmpty(numbers);
        }

        private static List<string> CreateSeperators(string[] seperatorsAndValues)
        {
            var seperators = new List<string>(Seperators);
            var newSeperators = seperatorsAndValues[0].Split(DelimiterStrings, StringSplitOptions.RemoveEmptyEntries);

            seperators.AddRange(newSeperators);
           
            return seperators;
        }

        private static IEnumerable<string> RemoveNumbersGreaterThan1000(IEnumerable<string> numbers)
        {
            return numbers.Where(number => int.Parse(number) <= (int)Defaults.MaxValue);
        }

        private static void CheckForNegativeNumbers(IEnumerable<string> numbers)
        {
            if (numbers.FirstOrDefault(x => int.Parse(x) < 0) is not null)
            {
                throw new Exception("Negatives not allowed");
            }
        }

        public static List<int> ParseNumbers(string numbers)
        {
            IEnumerable<string> result;

            if (numbers.StartsWith("//"))
            {
                var seperatorsAndValues = numbers.Split(new string[] { Seperators[0] }, StringSplitOptions.RemoveEmptyEntries);
                var seperators = CreateSeperators(seperatorsAndValues);

                result = seperatorsAndValues[1].Split(seperators.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                result = numbers.Split(Seperators, StringSplitOptions.RemoveEmptyEntries);
            }

            result = RemoveNumbersGreaterThan1000(result);

            CheckForNegativeNumbers(result);

            return result.Select(n => int.Parse(n)).ToList();
        }

    }
}
