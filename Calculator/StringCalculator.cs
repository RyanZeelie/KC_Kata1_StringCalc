namespace Calculator
{
    public class StringCalculator
    {
        private const int _defaultValue = 0;
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return _defaultValue;
            }

            return int.Parse(numbers);
        } 
    }
}