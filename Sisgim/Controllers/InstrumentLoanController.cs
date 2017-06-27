using Sisgim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sisgim.Controllers
{
    public class InstrumentLoanController : Controller
    {
        private SISGIMEntities dbSisgim = new SISGIMEntities();

        [Authorize]
        // GET: InstrumentLoan
        public ActionResult Index(string loanName)
        {
            var loan = from s in dbSisgim.PRESTAMO select s;
            if (!string.IsNullOrEmpty(loanName))
            {
                loan = loan.Where(a => a.NOMBREALUMNO.Contains(loanName));
            }
            return View(loan);
        }

        // GET: InstrumentLoan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InstrumentLoan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstrumentLoan/Create
        [HttpPost]
        public ActionResult Create(PRESTAMO loan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var a = loan;
                    a.FECHAHORAPRESTAMO = DateTime.Now;
                    a.NOMBREPROFESOR = User.Identity.Name;
                    dbSisgim.PRESTAMO.Add(a);
                    dbSisgim.SaveChanges();
                    dbSisgim.Dispose();
                    return RedirectToAction("Index");
                }
                return View(loan);
            }
            catch
            {
                return View(loan);
            }
        }

        // GET: InstrumentLoan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InstrumentLoan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InstrumentLoan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InstrumentLoan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
