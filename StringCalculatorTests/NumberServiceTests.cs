
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
    }
}
