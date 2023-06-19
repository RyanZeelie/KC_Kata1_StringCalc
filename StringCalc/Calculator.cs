namespace StringCalc
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if(CalculatorHelpers.ValuesAreNullOrEmpty(numbers)) return (int)CalculatorHelpers.Defaults.DefaultValue;

            var res = CalculatorHelpers.ParseNumbers(numbers);

            return res.Sum();
        }
    }
}
