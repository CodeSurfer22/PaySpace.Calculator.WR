namespace PaySpace.Calculator.Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private readonly Dictionary<string, ITaxCalculator> _taxCalculators;

        public TaxCalculatorService(ProgressiveTaxCalculator progressiveTaxCalculator, FlatValueTaxCalculator flatValueTaxCalculator, FlatRateTaxCalculator flatRateTaxCalculator)
        {
            _taxCalculators = new Dictionary<string, ITaxCalculator>
            {
                { "7441", progressiveTaxCalculator },
                { "1000", progressiveTaxCalculator },
                { "A100", flatValueTaxCalculator },
                { "7000", flatRateTaxCalculator }
            };
        }

        public decimal CalculateTax(string postalCode, decimal annualSalary)
        {
            if (_taxCalculators.TryGetValue(postalCode, out ITaxCalculator calculator))
            {
                return calculator.CalculateTax(annualSalary);
            }

            throw new ArgumentException("Invalid postal code");
        }
    }
}
