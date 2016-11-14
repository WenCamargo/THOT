using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using THOT.Models;

namespace THOT.Controllers
{
    public class StudentTestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentTests
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var studentTests = db.StudentTests.Where(x => x.UserId == userId).ToList();
            
            foreach(var s in studentTests)
                s.Test = db.Tests.Where(x => x.TestId == s.TestId).FirstOrDefault();

            return View(studentTests.ToList());
        }

        // GET: StudentTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTest studentTest = db.StudentTests.Find(id);
            if (studentTest == null)
            {
                return HttpNotFound();
            }
            return View(studentTest);
        }

        // GET: StudentTests/Create
        public ActionResult Create()
        {
            ViewBag.TestId = new SelectList(db.Tests, "TestId", "Name");
            return View();
        }

        // POST: StudentTests/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentTestId,UserId,TestId,Grade,CreationDate")] StudentTest studentTest)
        {
            if (ModelState.IsValid)
            {
                db.StudentTests.Add(studentTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TestId = new SelectList(db.Tests, "TestId", "Name", studentTest.TestId);
            return View(studentTest);
        }

        // GET: StudentTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTest studentTest = db.StudentTests.Find(id);
            if (studentTest == null)
            {
                return HttpNotFound();
            }
            ViewBag.TestId = new SelectList(db.Tests, "TestId", "Name", studentTest.TestId);
            return View(studentTest);
        }

        // POST: StudentTests/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentTestId,UserId,TestId,Grade,CreationDate")] StudentTest studentTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TestId = new SelectList(db.Tests, "TestId", "Name", studentTest.TestId);
            return View(studentTest);
        }

        // GET: StudentTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTest studentTest = db.StudentTests.Find(id);
            if (studentTest == null)
            {
                return HttpNotFound();
            }
            return View(studentTest);
        }

        // POST: StudentTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentTest studentTest = db.StudentTests.Find(id);
            db.StudentTests.Remove(studentTest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
