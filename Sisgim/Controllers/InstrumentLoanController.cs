using Sisgim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

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
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var loan = dbSisgim.PRESTAMO.Find(id);

            if (loan == null)
            {
                return HttpNotFound();
            }

            return View(loan);
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var loan = dbSisgim.PRESTAMO.Find(id);

            if (loan == null)
            {
                return HttpNotFound();
            }

            return View(loan);
        }

        // POST: InstrumentLoan/Edit/5
        [HttpPost]
        public ActionResult Edit(PRESTAMO loan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var a = loan;
                    a.FECHAHORAPRESTAMO = DateTime.Now;
                    a.NOMBREPROFESOR = User.Identity.Name;
                    dbSisgim.Entry(a).State = EntityState.Modified;
                    dbSisgim.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(loan);
            }
            catch
            {
                return View(loan);
            }
        }

        // GET: InstrumentLoan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var loan = dbSisgim.PRESTAMO.Find(id);

            if (loan == null)
            {
                return HttpNotFound();
            }

            return View(loan);
        }

        // POST: InstrumentLoan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PRESTAMO loan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    loan = dbSisgim.PRESTAMO.Find(id);
                    if (loan == null)
                    {
                        return HttpNotFound();
                    }
                    dbSisgim.PRESTAMO.Remove(loan);
                    dbSisgim.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(loan);
            }
            catch
            {
                return View(loan);
            }
        }

        // GET: InstrumentLoan/Return/5
        public ActionResult Return(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var loan = dbSisgim.PRESTAMO.Find(id);

            if (loan == null)
            {
                return HttpNotFound();
            }

            return View(loan);
        }

        // POST: InstrumentLoan/Return/5
        [HttpPost]
        public ActionResult Return(PRESTAMO loan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var a = loan;
                    a.FECHAHORAPRESTAMO = DateTime.Now;
                    a.FECHAHORADEVOLUCION = DateTime.Now;
                    a.NOMBREPROFESOR = User.Identity.Name;
                    dbSisgim.Entry(a).State = EntityState.Modified;
                    dbSisgim.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(loan);
            }
            catch
            { 
                return View(loan);
            }
        }
    }
}
