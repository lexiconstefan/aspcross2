using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Accounts.Web.DataContexts;
using UserAccounts.Entities;
using Newtonsoft.Json.Linq;

namespace Accounts.Web.Controllers
{
  //  [Authorize(Roles = "Administrator")]
    public class UserAccountsController : Controller
    {
        private UserAccountsDb db = new UserAccountsDb();

        // GET: UserAccounts
        public ActionResult Index()
        {
            var userAccounts = db.UserAccounts.Include(u => u.account).Include(u => u.department);
            return View(userAccounts.ToList());
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult QueryIndex(string json)
        {
            //JObject obj = JObject.FromObject(json);
           // //string searchStringKommun = (string)obj["municipality"];
            //string searchStringDepartment = (string)obj["department"];
           // string searchStringAccount = (string)obj["account"];
            var userAccounts = db.UserAccounts.Include(u => u.account).Include(u => u.department).Where(u => u.DepartmentId == 1);
            //userAccounts.d

         
        
           
            return View(userAccounts.ToList());
        }
        // GET: UserAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccounts.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // GET: UserAccounts/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Accounts, "id", "name");
            ViewBag.DepartmentId = new SelectList(db.Departments, "id", "name");
            return View();
        }

        // POST: UserAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,municipality,DepartmentId,AccountId")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.UserAccounts.Add(userAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.Accounts, "id", "name", userAccount.AccountId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "id", "name", userAccount.DepartmentId);
            return View(userAccount);
        }

        // GET: UserAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccounts.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "id", "name", userAccount.AccountId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "id", "name", userAccount.DepartmentId);
            return View(userAccount);
        }

        // POST: UserAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,municipality,DepartmentId,AccountId")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "id", "name", userAccount.AccountId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "id", "name", userAccount.DepartmentId);
            return View(userAccount);
        }

        // GET: UserAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccounts.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // POST: UserAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAccount userAccount = db.UserAccounts.Find(id);
            db.UserAccounts.Remove(userAccount);
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
