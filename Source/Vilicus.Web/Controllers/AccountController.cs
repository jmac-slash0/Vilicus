using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Vilicus.Dal;
using Vilicus.Dal.Interfaces;
using Vilicus.Web.Models;

namespace Vilicus.Web.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository accountData;

        public AccountController(IAccountRepository accountData)
        {
            this.accountData = accountData;
        }



        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginModel model, string returnUrl)
        {
            // Lets first check if the Model is valid or not
            if (ModelState.IsValid)
            {
                // Now if our password was enctypted or hashed we would have done the
                // same operation on the user entered password here, But for now
                // since the password is in plain text lets just authenticate directly
                bool userValid = accountData.Login(model.Email, model.Password);

                // User found in the database
                if (userValid)
                {

                    FormsAuthentication.SetAuthCookie(model.Email, false);

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The provided login credentials were invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }


        // GET: Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEditModel userEditModel = db.UserEditModels.Find(id);
            if (userEditModel == null)
            {
                return HttpNotFound();
            }
            return View(userEditModel);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,PasswordConfirmation,Email,Password")] UserEditModel userEditModel)
        {
            if (ModelState.IsValid)
            {
                db.UserEditModels.Add(userEditModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userEditModel);
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEditModel userEditModel = db.UserEditModels.Find(id);
            if (userEditModel == null)
            {
                return HttpNotFound();
            }
            return View(userEditModel);
        }

        // POST: Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,PasswordConfirmation,Email,Password")] UserEditModel userEditModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userEditModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userEditModel);
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEditModel userEditModel = db.UserEditModels.Find(id);
            if (userEditModel == null)
            {
                return HttpNotFound();
            }
            return View(userEditModel);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserEditModel userEditModel = db.UserEditModels.Find(id);
            db.UserEditModels.Remove(userEditModel);
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
