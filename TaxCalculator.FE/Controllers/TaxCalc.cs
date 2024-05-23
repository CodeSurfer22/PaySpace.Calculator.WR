using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaxCalculator.FE.Controllers
{
    public class TaxCalc : Controller
    {
        // GET: TaxCalc
        public ActionResult Index()
        {
            return View();
        }

        // GET: TaxCalc/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaxCalc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaxCalc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaxCalc/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaxCalc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaxCalc/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaxCalc/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
