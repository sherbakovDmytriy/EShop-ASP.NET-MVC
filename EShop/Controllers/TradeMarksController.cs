//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using EShop.Data;
//using EShop.Models;

//namespace EShop.Controllers
//{
//    public class TradeMarksController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: TradeMarks
//        public ActionResult Index()
//        {
//            return View(db.TradeMarks.ToList());
//        }

//        // GET: TradeMarks/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            TradeMarkModel tradeMark = db.TradeMarks.Find(id);
//            if (tradeMark == null)
//            {
//                return HttpNotFound();
//            }
//            return View(tradeMark);
//        }

//        // GET: TradeMarks/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: TradeMarks/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,Name")] TradeMarkModel tradeMark)
//        {
//            if (ModelState.IsValid)
//            {
//                db.TradeMarks.Add(tradeMark);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(tradeMark);
//        }

//        // GET: TradeMarks/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            TradeMarkModel tradeMark = db.TradeMarks.Find(id);
//            if (tradeMark == null)
//            {
//                return HttpNotFound();
//            }
//            return View(tradeMark);
//        }

//        // POST: TradeMarks/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,Name")] TradeMarkModel tradeMark)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(tradeMark).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(tradeMark);
//        }

//        // GET: TradeMarks/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            TradeMarkModel tradeMark = db.TradeMarks.Find(id);
//            if (tradeMark == null)
//            {
//                return HttpNotFound();
//            }
//            return View(tradeMark);
//        }

//        // POST: TradeMarks/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            TradeMarkModel tradeMark = db.TradeMarks.Find(id);
//            db.TradeMarks.Remove(tradeMark);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
