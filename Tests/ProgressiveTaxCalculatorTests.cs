using PaySpace.Calculator.Services;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestFixture]
        public class ProgressiveTaxCalculatorTests
        {
            [TestCase(5000, 500)]
            [TestCase(10000, 1082.5)]
            public void CalculateTax_ReturnsCorrectTax(decimal annualSalary, decimal expectedTax)
            {
                var calculator = new ProgressiveTaxCalculator();
                var tax = calculator.CalculateTax(annualSalary);
                Assert.AreEqual(expectedTax, tax);
            }
        }

    }
}