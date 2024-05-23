using Microsoft.AspNetCore.Mvc;
using PaySpace.Calculator.Services;
using TaxCalculator.API.Data;
using TaxCalculator.API.Models;

namespace TaxCalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxCalculationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITaxCalculatorService _taxCalculatorService;

        public TaxCalculationsController(ApplicationDbContext context, ITaxCalculatorService taxCalculatorService)
        {
            _context = context;
            _taxCalculatorService = taxCalculatorService;
        }

        [HttpGet]
        public IActionResult Get(string? postalCode, decimal annualSalary)
        {
            try
            {
                decimal taxAmount = _taxCalculatorService.CalculateTax(postalCode, annualSalary);
                ViewBag.TaxAmount = taxAmount;
                Calculations_History result = new Calculations_History();
                result.TaxAmount = taxAmount;
                result.DateCreated = DateTime.Now;
                result.PostalCode = postalCode;
                result.AnnualIncome = annualSalary;
                _context.Calculations_Histories.Add(result);
                _context.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                ViewBag.Error = ex.Message;
            }

            var calc_histories = _context.Calculations_Histories.ToList();

            return Ok(calc_histories);

        }
    }

}
