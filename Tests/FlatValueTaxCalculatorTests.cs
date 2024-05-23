using Microsoft.Extensions.Caching.Memory;
using PaySpace.Calculator.Services;

[TestFixture]
public class FlatValueTaxCalculatorTests
{

    private FlatValueTaxCalculator CreateCalculator()
    {
        var memoryCacheOptions = new MemoryCacheOptions();
        var memoryCache = new MemoryCache(memoryCacheOptions);
        return new FlatValueTaxCalculator(memoryCache);
    }

    [TestCase(150000, 7500)]
    [TestCase(200000, 10000)] 
    [TestCase(250000, 10000)] 
    public void CalculateTax_ReturnsCorrectTax(decimal annualSalary, decimal expectedTax)
    {
        var calculator = CreateCalculator();
        var tax = calculator.CalculateTax(annualSalary);
        Assert.AreEqual(expectedTax, tax);
    }
}

