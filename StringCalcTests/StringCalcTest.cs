using StringCalc;

namespace StringCalcTests
{
    public class StringCalcTest
    {
        private readonly Calculator _calc;

        public StringCalcTest()
        {
            // Arrange
            _calc = new Calculator();
        }

        [Fact]
        public void ShouldReturnZeroIfStringIsNull()
        {
            // Arrange
            string? numbers = null;

            // Act
            var result = _calc.Add(numbers);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void ShouldReturnZeroIfStringIsEmpty()
        {
            // Arrange
            var numbers = "";

            // Act
            var result = _calc.Add(numbers);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void ShouldAddTwoNumbers()
        {
            // Arrange
            var numbers = "1,2";

            // Act
            var result = _calc.Add(numbers);

            // Assert
            Assert.Equal(3, result);
        }


        [Fact]
        public void ShouldAddThreeNumbers()
        {
            // Arrange
            var numbers = "1,2,3";

            // Act
            var result = _calc.Add(numbers);

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void ShouldAddRandomAmountOfNumbers()
        {
            // Arrange
            var valuesToTest = TestHelpers.GetRandomAmountOfNumbers();

            // Act
            var result = _calc.Add(valuesToTest.TestCase);

            // Assert
            Assert.Equal(valuesToTest.Answer, result);
        }

        [Fact]
        public void ShouldAddNumbersWithANewLine()
        {
            // Arrange
            var numbers = "1,\n2,3";

            // Act
            var result = _calc.Add(numbers);

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void ShouldSupportSingleDelimiter()
        {
            // Arrange
            var numbers = "//;\n1;2;3";

            // Act
            var result = _calc.Add(numbers);

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void ShouldSupportMultipleDelimiters()
        {
            // Arrange
            var numbers = "//[;][*][&]\n1;1*1&3";

            // Act
            var result = _calc.Add(numbers);

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void ShouldSupportMultipleDelimitersWithLengthLongerThanOneCharacter()
        {
            // Arrange
            var numbers = "//[;][****][&&]\n1;1****1&&3";

            // Act
            var result = _calc.Add(numbers);

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void ShouldIgnoreNumbersBiggerThan1000()
        {
            // Arrange
            var numbers = "1,2,3,1001";

            // Act
            var result = _calc.Add(numbers);

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void ShouldThrowAnErrorIfNegativeNumberIsGiven()
        {
            // Arrange
            var numbers = "1,2,3,-2";

            // Act
            var exception = Assert.Throws<Exception>(() => _calc.Add(numbers));

            // Assert
            Assert.Equal("Negatives not allowed", exception.Message);
        }
    }
}
