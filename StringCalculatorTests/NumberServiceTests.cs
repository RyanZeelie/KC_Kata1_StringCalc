using Calculator.Helpers;

namespace StringCalculatorTests
{
    [TestFixture]
    public class NumberServiceTests
    {
        private INumberService _numberService;

        [SetUp]
        public void Setup()
        {
            _numberService = new NumberService();
        }

        [Test]
        public void GIVEN_StringOfTwoNumbersSeparatedByComma_WHEN_ParsingNumbers_RETURNS_NumbersAsList()
        {
            // Arrange
            var testInput = "1,2";
            var expectedResult = new List<int>() { 1, 2 };

            //Act
            var result = _numberService.ParseNumbers(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GIVEN_StringOfTwoNumbersSeparatedByANewLine_WHEN_ParsingNumbers_RETURNS_NumbersAsListInt()
        {
            // Arrange
            var testInput = "1\n2";
            var expectedResult = new List<int>() { 1, 2 };

            //Act
            var result = _numberService.ParseNumbers(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GIVEN_StringOfTwoNumbersSeparatedByACustomDelimiter_WHEN_ParsingNumbers_RETURNS_NumbersAsListInt()
        {
            // Arrange
            var testInput = "//;\n1;2";
            var expectedResult = new List<int>() { 1, 2 };

            //Act
            var result = _numberService.ParseNumbers(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GIVEN_AnegativeNumber_WHEN_ParsingNumbers_THROWS_NewError()
        {
            // Arrange
            var testInput = "1,2,-3,4";
            var expectedResult = "Negatives are not allowed";

            //Act
            var exception = Assert.Throws<Exception>(() => _numberService.ParseNumbers(testInput));

            //Assert
            Assert.That(exception.Message, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GIVEN_AnumberGreaterThan1000_WHEN_ParsingNumbers_RETRUNS_ListOfNumbersExcludingThoseGreaterThan1000()
        {
            // Arrange
            var testInput = "1,1001,2";
            var expectedResult = new List<int>() { 1, 2 };

            //Act
            var result = _numberService.ParseNumbers(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GIVEN_DelimiterOfRandomLength_WHEN_ParsingNumbers_RETRUNS_NumbersAsListInt()
        {
            // Arrange
            var testInput = "//*\n1*2***3";
            var expectedResult = new List<int>() { 1, 2, 3 };

            //Act
            var result = _numberService.ParseNumbers(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GIVEN_MoreThanOneDelimiter_WHEN_ParsingNumbers_RETRUNS_NumbersAsListInt()
        {
            // Arrange
            var testInput = "//[*][;]\n1*2;3";
            var expectedResult = new List<int>() { 1, 2, 3 };

            //Act
            var result = _numberService.ParseNumbers(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
