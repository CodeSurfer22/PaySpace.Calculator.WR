namespace PaySpace.Calculator.Services
{
    public interface ITaxCalculatorService
    {
        decimal CalculateTax(string postalCode, decimal annualSalary);
    }

}
    