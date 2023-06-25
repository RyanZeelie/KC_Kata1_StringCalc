using Calculator.Helpers;

namespace Calculator
{
    public class StringCalculator
    {
        private INumberFormatter _numberFormatter;
        private const int _defaultValue = 0;

        public StringCalculator(INumberFormatter formatter)
        {
            _numberFormatter = formatter;
        }

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return _defaultValue;
            }

            var result = _numberFormatter.ParseNumbers(numbers);

            return result.Sum();
        } 
    }
}