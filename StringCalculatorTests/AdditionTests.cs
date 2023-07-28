using Calculator;
using Calculator.Helpers;
using NSubstitute;
using NUnit.Framework;

namespace StringCalculatorTests
{
    [TestFixture]
    public class AdditionTests
    {
        private INumberFormatter _numberFormatter;
        private StringCalculator _stringCalculator;


        [SetUp]
        public void Setup()
        {
            _numberFormatter = Substitute.For<INumberFormatter>();
            _stringCalculator = new StringCalculator(_numberFormatter);
        }

        [Test]
        public void AddMethod_GivenAnEmptyString_ShouldReturnZero()
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
        public void AddMethod_GivenAnTwoNumbersAsString_ShouldAddThemTogether()
        {
            // Arrange
            var testInput = "1,2";
            var expectedResult = 3;

            _numberFormatter.ParseNumbers(testInput).Returns(new List<int> { 1, 2 });

            //Act
            var result = _stringCalculator.Add(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AddMethod_GivenAnUnknownAmountOfNumbers_ShouldAddThemTogether()
        {
            // Arrange
            var rndm = new Random();
            var randomAmountOfNumbersBetween1And20 = Enumerable.Range(1, rndm.Next(20)).ToList();

            var testInput = string.Join(",", randomAmountOfNumbersBetween1And20); 
            var expectedResult = randomAmountOfNumbersBetween1And20.Sum();;

            _numberFormatter.ParseNumbers(testInput).Returns(randomAmountOfNumbersBetween1And20);

            //Act
            var result = _stringCalculator.Add(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AddMethod_GivenNumbersSeparatedByNewLinesAsString_ShouldAddThemTogether()
        {
            // Arrange
            var testInput = "1\n2";
            var expectedResult = 3;

            _numberFormatter.ParseNumbers(testInput).Returns(new List<int> { 1, 2 });

            //Act
            var result = _stringCalculator.Add(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}