using Calculator.Helpers;

namespace Calculator
{
    public class StringCalculator
    {
        private INumberService _numberFormatter;
        private const int DefaultValue = 0;

        public StringCalculator(INumberService formatter)
        {
            _numberFormatter = formatter;
        }

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return DefaultValue;
            }

            var listOfNumbers = _numberFormatter.ParseNumbers(numbers);

            return listOfNumbers.Sum();
        } 
    }
}