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
        private Calculator Calculator;

        [SetUp]
        public void Setup()
        {
            _numberService = Substitute.For<INumberService>();
            Calculator = new Calculator(_numberService);
        }

        [Test]
        public void GIVEN_AlistOfNumbers_WHEN_AddMethodCalled_SHOULD_AddNumbersTogether()
        {
            // Arrange
            var testInput = "1,2";
            var expectedResult = 3;

            _numberService.ParseNumbers(testInput).Returns(new List<int> { 1, 2 });

            //Act
            var result = Calculator.Add(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
