using Calculator.Helpers;

namespace Calculator
{
    public class StringCalculator
    {
        private readonly INumberService _numberService;
        private const int DefaultValue = 0;

        public StringCalculator(INumberService formatter)
        {
            _numberService = formatter;
        }

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return DefaultValue;
            }

            var listOfNumbers = _numberService.ParseNumbers(numbers);

            return listOfNumbers.Sum();
        } 
    }
}