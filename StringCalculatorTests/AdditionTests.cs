using Calculator;
using Calculator.Helpers;
using NSubstitute;

namespace StringCalculatorTests
{
    [TestFixture]
    public class AdditionTests
    {
        [Test]
        public void AddMethod_GivenAnEmptyString_ShouldReturnZero()
        {
            // Arrange
            var numberFormatter = Substitute.For<INumberFormatter>();
            var stringCalculator = new StringCalculator(numberFormatter);

            var testInput = "";
            var expectedResult = 0;

            //Act
            var result = stringCalculator.Add(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AddMethod_GivenAnTwoNumbersAsString_ShouldAddThemTogether()
        {
            // Arrange
            var testInput = "1,2";
            var expectedResult = 3;

            var numberFormatter = Substitute.For<INumberFormatter>();
            var stringCalculator = new StringCalculator(numberFormatter);

            numberFormatter.ParseNumbers(testInput).Returns(new List<int> { 1, 2 });

            //Act
            var result = stringCalculator.Add(testInput);

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

            var expectedResult = randomAmountOfNumbersBetween1And20.Sum();

            var numberFormatter = Substitute.For<INumberFormatter>();
            var stringCalculator = new StringCalculator(numberFormatter);

            numberFormatter.ParseNumbers(testInput).Returns(randomAmountOfNumbersBetween1And20);

            //Act
            var result = stringCalculator.Add(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}