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
    
    public class TestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tests
        [Authorize(Roles = "Administrator,Student")]
        public ActionResult Index()
        {
            return View(db.Tests.ToList());
        }

        // GET: Tests/Details/5
        [Authorize(Roles = "Administrator,Student")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);

            if (test == null)
            {
                return HttpNotFound();
            }

            var questions = db.Questions.Where(x => x.TestId == test.TestId).ToList();
            foreach(var q in questions)
            {
                q.Answers = db.Answers.Where(a => a.QuestionId == q.QuestionId).ToList();
            }

            test.Questions = questions;

            return View(test);
        }

        // GET: Tests/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.TopicId = new SelectList(db.Topics, "TopicId", "Name");
            return View();
        }

        // POST: Tests/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestId,TopicId,Name,Date")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Tests.Add(test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(test);
        }

        // GET: Tests/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            ViewBag.TopicId = new SelectList(db.Topics , "TopicId", "Name", test.TopicId);            
            return View(test);
        }

        // POST: Tests/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestId,TopicId,Name,Date")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test);
        }

        // GET: Tests/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Tests/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test test = db.Tests.Find(id);
            db.Tests.Remove(test);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Tests/ResolveTest/5
        [Authorize(Roles = "Student")]
        public ActionResult ResolveTest(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Where(x => x.TopicId == id).FirstOrDefault();

            var questions = db.Questions.Where(x => x.TestId == test.TestId).ToList();
            foreach (var q in questions)
            {
                q.Answers = db.Answers.Where(a => a.QuestionId == q.QuestionId).ToList();
            }

            test.Questions = questions;

            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Tests/ResolveTest/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Student")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResolveTest(Test test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(test);
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
