
using Microsoft.Extensions.Caching.Memory;

namespace PaySpace.Calculator.Services
{
    public class FlatValueTaxCalculator : ITaxCalculator
    {
        private readonly IMemoryCache _cache;
        private const decimal FlatValue = 10000m;
        private const decimal Threshold = 200000m;
        private const decimal Percentage = 0.05m;

        public FlatValueTaxCalculator(IMemoryCache cache)
        {
            _cache = cache;
        }

        public decimal CalculateTax(decimal salary)
        {
            return _cache.GetOrCreate($"FlatValueTax_{salary}", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60);
                return salary > Threshold ? FlatValue : salary * Percentage;
            });
        }
    }

}
