using Microsoft.Extensions.Caching.Memory;
using NUnit.Framework;
using PaySpace.Calculator.Services;

[TestFixture]
public class FlatRateTaxCalculatorTests
{
    private FlatRateTaxCalculator CreateCalculator()
    {
        var memoryCacheOptions = new MemoryCacheOptions();
        var memoryCache = new MemoryCache(memoryCacheOptions);
        return new FlatRateTaxCalculator(memoryCache);
    }

    [TestCase(100000, 17500)]
    [TestCase(200000, 35000)]
    [TestCase(500000, 87500)]
    public void CalculateTax_ReturnsCorrectTax(decimal annualSalary, decimal expectedTax)
    {
        var calculator = CreateCalculator();
        var tax = calculator.CalculateTax(annualSalary);
        Assert.AreEqual(expectedTax, tax);
    }
}
