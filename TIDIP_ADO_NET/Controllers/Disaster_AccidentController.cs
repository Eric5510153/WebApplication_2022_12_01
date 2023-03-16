using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using TIDIP_ADO_NET.Models;

namespace TIDIP_ADO_NET.Controllers 
{
    public class Disaster_AccidentController : Controller
    {
        private TIDIPEntities db = new TIDIPEntities();

        // GET: Disaster_Accident
        public ActionResult Index()
        {
            var disaster_Accident = db.Disaster_Accident.Include(d => d.Disaster_Accident_Type).Include(d => d.Members);
            return View(disaster_Accident.ToList());
        }

        // GET: Disaster_Accident/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disaster_Accident disaster_Accident = db.Disaster_Accident.Find(id);
            if (disaster_Accident == null)
            {
                return HttpNotFound();
            }
            return PartialView(disaster_Accident);
        }

        // GET: Disaster_Accident/Create
        public ActionResult _Create()
        {
            ViewBag.DATypeID = new SelectList(db.Disaster_Accident_Type, "DATypeID", "DATypeName");
            ViewBag.Member_MbIdentity = new SelectList(db.Members, "MbIdentity", "MbName");
            return PartialView();
        }

        // POST: Disaster_Accident/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "DAID,DALocation,County_City,Area,DACreatedDate,DAMessage,MbIdentity,DATypeID,Member_MbIdentity")]*/ Disaster_Accident disaster_Accident)
        
        {
            
            //var mbID = ((Members)Session["mb"]).MbIdentity.FirstOrDefault();

            disaster_Accident.DACreatedDate = DateTime.Now;
            
            db.Disaster_Accident.Add(disaster_Accident);
            if (ModelState.IsValid)
            {


                


                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DATypeID = new SelectList(db.Disaster_Accident_Type, "DATypeID", "DATypeName", disaster_Accident.DATypeID);
            ViewBag.Member_MbIdentity = new SelectList(db.Members, "MbIdentity", "MbName", disaster_Accident.Member_MbIdentity);
            return View(disaster_Accident);
        }
        /* =================> Original!!!!!!!!!!!!!!!!<==================
         
        public ActionResult Create([Bind(Include = "DAID,DALocation,County_City,Area,DACreatedDate,DAMessage,MbIdentity,DATypeID,Member_MbIdentity")] Disaster_Accident disaster_Accident)
        {
            if (ModelState.IsValid)
            {
                db.Disaster_Accident.Add(disaster_Accident);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DATypeID = new SelectList(db.Disaster_Accident_Type, "DATypeID", "DATypeName", disaster_Accident.DATypeID);
            ViewBag.Member_MbIdentity = new SelectList(db.Members, "MbIdentity", "MbName", disaster_Accident.Member_MbIdentity);
            return View(disaster_Accident);
        }
         =================> Original!!!!!!!!!!!!!!!!<=====================
         */

        // GET: Disaster_Accident/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disaster_Accident disaster_Accident = db.Disaster_Accident.Find(id);
            if (disaster_Accident == null)
            {
                return HttpNotFound();
            }
            ViewBag.DATypeID = new SelectList(db.Disaster_Accident_Type, "DATypeID", "DATypeName", disaster_Accident.DATypeID);
            ViewBag.Member_MbIdentity = new SelectList(db.Members, "MbIdentity", "MbName", disaster_Accident.Member_MbIdentity);
            return View(disaster_Accident);
        }

        // POST: Disaster_Accident/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DAID,DALocation,County_City,Area,DACreatedDate,DAMessage,MbIdentity,DATypeID,Member_MbIdentity")] Disaster_Accident disaster_Accident)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disaster_Accident).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DATypeID = new SelectList(db.Disaster_Accident_Type, "DATypeID", "DATypeName", disaster_Accident.DATypeID);
            ViewBag.Member_MbIdentity = new SelectList(db.Members, "MbIdentity", "MbName", disaster_Accident.Member_MbIdentity);
            return View(disaster_Accident);
        }

        // GET: Disaster_Accident/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disaster_Accident disaster_Accident = db.Disaster_Accident.Find(id);
            if (disaster_Accident == null)
            {
                return HttpNotFound();
            }
            return View(disaster_Accident);
        }

        // POST: Disaster_Accident/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disaster_Accident disaster_Accident = db.Disaster_Accident.Find(id);
            db.Disaster_Accident.Remove(disaster_Accident);
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
