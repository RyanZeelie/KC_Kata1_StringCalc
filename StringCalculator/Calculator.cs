using StringCalculator.Services;

namespace StringCalculator
{
    public class Calculator
    {
        private readonly INumberService _numberService;
        private const int DefaultValue = 0;

        public Calculator(INumberService numberService)
        {
            _numberService = numberService;
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