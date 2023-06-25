using Calculator;

namespace StringCalculatorTests
{
    [TestFixture]
    public class AdditionTests
    {
        private StringCalculator _stringCalculator;
    
        [SetUp]
        public void Setup()
        {
            _stringCalculator = new StringCalculator();
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
    }
}