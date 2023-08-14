using Calculator;
using Calculator.Helpers;
using NSubstitute;

namespace StringCalculatorTests
{
    [TestFixture]
    public class AdditionTests
    {
        private INumberService _numberService;
        private StringCalculator _stringCalculator;


        [SetUp]
        public void Setup()
        {
            _numberService = Substitute.For<INumberService>();
            _stringCalculator = new StringCalculator(_numberService);
        }

        [Test]
        public void GIVEN_AnEmptyString_WHEN_AddMethodCalled_RETURNS_Zero()
        {
            // Arrange
            var testInput = "";
            var expectedResult = 0;

            //Act
            var result = _stringCalculator.Add(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GIVEN_TwoNumbersAsString_WHEN_AddMethodCalled_SHOULD_AddNumbersTogether()
        {
            // Arrange
            var testInput = "1,2";
            var expectedResult = 3;

            _numberService.ParseNumbers(testInput).Returns(new List<int> { 1, 2 });

            //Act
            var result = _stringCalculator.Add(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GIVEN_AnUnknownAmountOfNumbers_WHEN_AddMethodCalled_SHOULD_AddNumbersTogether()
        {
            // Arrange
            var rndm = new Random();
            var randomAmountOfNumbersBetween1And20 = Enumerable.Range(1, rndm.Next(20)).ToList();

            var testInput = string.Join(",", randomAmountOfNumbersBetween1And20); 
            var expectedResult = randomAmountOfNumbersBetween1And20.Sum();;

            _numberService.ParseNumbers(testInput).Returns(randomAmountOfNumbersBetween1And20);

            //Act
            var result = _stringCalculator.Add(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void GIVEN_NumbersSeparatedByNewLines_WHEN_AddMethodCalled_SHOULD_AddNumbersTogether()
        {
            // Arrange
            var testInput = "1\n2";
            var expectedResult = 3;

            _numberService.ParseNumbers(testInput).Returns(new List<int> { 1, 2 });

            //Act
            var result = _stringCalculator.Add(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}