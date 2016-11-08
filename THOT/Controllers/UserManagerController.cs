using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using THOT.Models;

namespace THOT.Controllers
{
    public class UserManagerController : Controller
    {
        private Models.ApplicationDbContext db = new Models.ApplicationDbContext();
        // GET: UserManager
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
        }

        // GET: UserManager/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: UserManager/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(ApplicationUser user)
        {
            var userr = db.Users.Find(user.Id);
            userr.Name = user.Name;
            userr.FirstLastName = user.FirstLastName;
            userr.SecondLastName = user.SecondLastName;
            userr.StudentId = user.StudentId;
            userr.Email = user.Email;

            if (ModelState.IsValid)
            {
                db.Entry(userr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }
        // GET: Units/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit user = db.Units.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = db.Units.Find(id);
            db.Units.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}