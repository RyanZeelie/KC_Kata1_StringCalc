namespace StringCalcTests
{
    public static class TestHelpers
    {
        private static string AddDefaultSeperators(string randomString)
        {
            return string.Join(",", randomString.ToCharArray());
        }

        public static RandomStringOfNumbers GetRandomAmountOfNumbers()
        {
            var result = new RandomStringOfNumbers();

            var randomizer = new Random();
            var randomStringOfNumbers = randomizer.Next(10);

            for (int i = 0; i < randomStringOfNumbers; i++) 
            {
                result.TestCase += $"{i}";
                result.Answer += i;
            }

            result.TestCase = AddDefaultSeperators(result.TestCase);

            return result;
        }

        public  class RandomStringOfNumbers
        {
            public string TestCase { get; set; } = string.Empty;
            public int Answer { get; set; } = 0;
        }
    }
}
