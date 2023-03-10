using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MCSDD26.Models;
using PagedList;

namespace MCSDD26.Controllers
{
    public class MembersController : Controller
    {
        private MCSDD26Ccontext db = new MCSDD26Ccontext();
        setData setData = new setData();

        int pageSize = 10;
        // GET: Members

        public ActionResult Index(int page=1)
        {

            int currentPage = page < 1 ? 1 : page;

            var member = db.Members.ToList();

            var result = member.ToPagedList(currentPage,pageSize);

            return View(result);
        }

        // GET: Members/Details/5
        //[ChildActionOnly]
        public ActionResult _Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return PartialView(members);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Members/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "MemberID,MemberName,MemberPhotoFile,MemberBirdthday,CreatedDate,Account,Password")]*/ Members members)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(new Members()
                {   
                    MemberName = members.MemberName,
                    MemberPhotoFile = members.MemberPhotoFile,
                    MemberBirdthday = members.MemberBirdthday,    
                    CreatedDate=DateTime.Now,
                    Account= members.Account,
                    Password= members.Password,

                
                
                });

               // db.Members.Add(members);
                db.SaveChanges();
               
                return RedirectToAction("Index");
               
            }

            return View(members);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return PartialView(members);
        }
        // GET: Members/Edit/5
        // POST: Members/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Edit(Members members)
        {

            string sql = "update members set MemberName=@MemberName, MemberBirdthday=@MemberBirdthday where MemberID=@MemberID";

            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("MemberID",members.MemberID),
                new SqlParameter("MemberName",members.MemberName),
                new SqlParameter("MemberBirdthday",members.MemberBirdthday)
            };

            try
            {
                setData.executeSql(sql, list);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
                return RedirectToAction("Index",members);
            }

            //if (ModelState.IsValid)
            //{
            //    db.Entry(members).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

        }
       

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Members members = db.Members.Find(id);
            db.Members.Remove(members);
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
