using NSubstitute;

namespace StringCalculatorTests
{
    [TestFixture]
    public class AdditionTests
    {
        private INumberService _mockNumberService;
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _mockNumberService = Substitute.For<INumberService>();
            _calculator = new Calculator(_mockNumberService);
        }

        [Test]
        public void GIVEN_AlistOfNumbers_WHEN_AddMethodCalled_SHOULD_AddNumbersTogether()
        {
            // Arrange
            var testInput = "1,2";
            var expectedResult = 3;

            _mockNumberService.ParseNumbers(testInput).Returns(new List<int> { 1, 2 });

            //Act
            var result = _calculator.Add(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GIVEN_AnEmptyString_WHEN_AddMethodCalled_RETURNS_Zero()
        {
            // Arrange
            var testInput = "";
            var expectedResult = 0;

            //Act
            var result = _calculator.Add(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GIVEN_AnUnknownAmountOfNumbers_WHEN_AddMethodCalled_ShouldAddNumbersTogether()
        {
            // Arrange
            var rndm = new Random();
            var randomAmountOfNumbersBetween1And20 = Enumerable.Range(1, rndm.Next(20)).ToList();

            var testInput = string.Join(",", randomAmountOfNumbersBetween1And20);

            var expectedResult = randomAmountOfNumbersBetween1And20.Sum();

            _mockNumberService.ParseNumbers(testInput).Returns(randomAmountOfNumbersBetween1And20);

            //Act
            var result = _calculator.Add(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
