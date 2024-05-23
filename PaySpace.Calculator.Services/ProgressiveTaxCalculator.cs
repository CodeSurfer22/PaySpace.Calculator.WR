
namespace PaySpace.Calculator.Services
{
    public class ProgressiveTaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal annualSalary)
        {
            decimal tax = 0;

            if (annualSalary <= 8350)
                tax = annualSalary * 0.10m;
            else if (annualSalary <= 33950)
                tax = (8350 * 0.10m) + ((annualSalary - 8350) * 0.15m);
            else if (annualSalary <= 82250)
                tax = (8350 * 0.10m) + (25600 * 0.15m) + ((annualSalary - 33950) * 0.25m);
            else if (annualSalary <= 171550)
                tax = (8350 * 0.10m) + (25600 * 0.15m) + (48300 * 0.25m) + ((annualSalary - 82250) * 0.28m);
            else if (annualSalary <= 372950)
                tax = (8350 * 0.10m) + (25600 * 0.15m) + (48300 * 0.25m) + (89250 * 0.28m) + ((annualSalary - 171550) * 0.33m);
            else
                tax = (8350 * 0.10m) + (25600 * 0.15m) + (48300 * 0.25m) + (89250 * 0.28m) + (201400 * 0.33m) + ((annualSalary - 372950) * 0.35m);

            return tax;
        }
    }

}
