using Calculator.Helpers;

namespace StringCalculatorTests
{
    [TestFixture]
    public class NumberFormatterTests
    {
        private INumberFormatter _numberFormatter;

        [SetUp]
        public void Setup()
        {
            _numberFormatter = new NumberFormatter();
        }

        [Test]
        public void ParseNumbersMethod_GivenStringOfTwoNumbersSeparatedByComma_ShouldReturnNumbersAsListInt()
        {
            // Arrange
            var testInput = "1,2";
            var expectedResult = new List<int>() { 1, 2 };

            //Act
            var result = _numberFormatter.ParseNumbers(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void SplitNumbersMethod_GivenStringOfTwoNumbersSeparatedByComma_ShouldReturnNumbersAsAnIEnumerableString()
        {
            // Arrange
            var testInput = "1,2";
            IEnumerable<string> expectedResult = new List<string>() { "1", "2" };

            //Act
            var result = _numberFormatter.SplitNumbers(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

    }
}
