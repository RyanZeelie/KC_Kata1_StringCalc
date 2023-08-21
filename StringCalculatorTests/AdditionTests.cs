using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace StringCalculatorTests
{
    [TestFixture]
    public class AdditionTests
    {
        private INumberService _numberService;
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _numberService = Substitute.For<INumberService>();
            _calculator = new Calculator(_numberService);
        }

        [Test]
        public void GIVEN_AlistOfNumbers_WHEN_AddMethodCalled_SHOULD_AddNumbersTogether()
        {
            // Arrange
            var testInput = "1,2";
            var expectedResult = 3;

            _numberService.ParseNumbers(testInput).Returns(new List<int> { 1, 2 });

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
    }
}
