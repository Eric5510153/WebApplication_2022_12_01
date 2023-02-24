using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MCSDD26.Models;

namespace MCSDD26.Controllers
{
   
    public class PayTypesController : Controller
    {
        private MCSDD26Ccontext db = new MCSDD26Ccontext();

        // GET: PayTypes
        public ActionResult Index()
        {
            return View(db.PayTypes.ToList());
        }

        // GET: PayTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayTypes payTypes = db.PayTypes.Find(id);
            if (payTypes == null)
            {
                return HttpNotFound();
            }
            return View(payTypes);
        }

        // GET: PayTypes/Create
        [LoginCheck]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PayTypes/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PayTypeID,PayTypeName")] PayTypes payTypes)
        {
            if (ModelState.IsValid)
            {
                db.PayTypes.Add(payTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(payTypes);
        }

        // GET: PayTypes/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayTypes payTypes = db.PayTypes.Find(id);
            if (payTypes == null)
            {
                return HttpNotFound();
            }
            return View(payTypes);
        }

        // POST: PayTypes/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PayTypeID,PayTypeName")] PayTypes payTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payTypes);
        }

        // GET: PayTypes/Delete/5
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayTypes payTypes = db.PayTypes.Find(id);
            if (payTypes == null)
            {
                return HttpNotFound();
            }
            return View(payTypes);
        }

        // POST: PayTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PayTypes payTypes = db.PayTypes.Find(id);
            db.PayTypes.Remove(payTypes);
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
