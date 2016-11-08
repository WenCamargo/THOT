﻿using System;
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
    [Authorize(Roles = "Administrator")]
    public class AnswersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Answers
        public ActionResult Index()
        {
            var answers = db.Answers.Include(a => a.Question);
            return View(answers.ToList());
        }


        // GET: Answers / QuestionId
        [Authorize(Roles = "Administrator, Student")]
        public ActionResult QuestionsAnswers(int? id)
        {

            var answers = db.Answers.Where(x => x.QuestionId == id).Include(u => u.Question);
            //var units2 = db.Units.OrderBy(u => u.Subject);
            return View("Index", answers.ToList());
        }

        // GET: Answers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // GET: Answers/Create
        public ActionResult Create(int? id)
        {
            var question = db.Questions.Find(id);
            if(question != null)
            {
                ViewBag.QuestionId = question.QuestionId;
                ViewBag.QuestionName = question.Description;
                return View();

            }
            //ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "Description");
            return View(500);
        }

        // POST: Answers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "AnswerId,QuestionId,Description,IsCorrect")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                var cont = db.Answers.Where(x => x.QuestionId == answer.QuestionId).ToList().Count;
                if (cont < 4)
                {
                    db.Answers.Add(answer);
                    db.SaveChanges();
                    return RedirectToAction("Create", new { id = answer.QuestionId });
                }
                else
                {
                    return RedirectToAction("Create", "Questions");
                }
                
               
                
            }

            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "Description", answer.QuestionId);
            return View(answer);
        }

        // GET: Answers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "Description", answer.QuestionId);
            return View(answer);
        }

        // POST: Answers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "AnswerId,QuestionId,Description,IsCorrect")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "Description", answer.QuestionId);
            return View(answer);
        }

        // GET: Answers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Answer answer = db.Answers.Find(id);
            db.Answers.Remove(answer);
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
