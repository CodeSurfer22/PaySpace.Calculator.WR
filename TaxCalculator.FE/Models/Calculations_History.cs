namespace TaxCalculator.FE.Models
{
    public class Calculations_History
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public Decimal AnnualIncome { get; set; }
        public string PostalCode { get; set; }
        public decimal TaxAmount { get; set; }
    }
}
