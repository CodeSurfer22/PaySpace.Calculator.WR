using Microsoft.Extensions.Caching.Memory;
using System;
namespace PaySpace.Calculator.Services
{
    public class FlatRateTaxCalculator : ITaxCalculator
    {
        private readonly IMemoryCache _cache;
        private const decimal FlatRate = 0.175m;

        public FlatRateTaxCalculator(IMemoryCache cache)
        {
            _cache = cache;
        }

        public decimal CalculateTax(decimal salary)
        {
            return _cache.GetOrCreate($"FlatRateTax_{salary}", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60);
                return salary * FlatRate;
            });
        }
    }

}
