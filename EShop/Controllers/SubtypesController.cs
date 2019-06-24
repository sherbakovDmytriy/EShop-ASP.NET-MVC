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
//    public class SubtypesController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: Subtypes
//        public ActionResult Index()
//        {
//            var subtypes = db.Subtypes.Include(s => s.TypeModel);
//            return View(subtypes.ToList());
//        }

//        // GET: Subtypes/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            SubtypeModel subtype = db.Subtypes.Include(s => s.TypeModel).SingleOrDefault(s => s.Id == id);
//            if (subtype == null)
//            {
//                return HttpNotFound();
//            }
//            return View(subtype);
//        }

//        // GET: Subtypes/Create
//        public ActionResult Create()
//        {
//            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name");
//            return View();
//        }

//        // POST: Subtypes/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,Name,TypeId")] SubtypeModel subtype)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Subtypes.Add(subtype);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name", subtype.TypeId);
//            return View(subtype);
//        }

//        // GET: Subtypes/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            SubtypeModel subtype = db.Subtypes.Find(id);
//            if (subtype == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name", subtype.TypeId);
//            return View(subtype);
//        }

//        // POST: Subtypes/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,Name,TypeId")] SubtypeModel subtype)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(subtype).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name", subtype.TypeId);
//            return View(subtype);
//        }

//        // GET: Subtypes/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            SubtypeModel subtype = db.Subtypes.Find(id);
//            if (subtype == null)
//            {
//                return HttpNotFound();
//            }
//            return View(subtype);
//        }

//        // POST: Subtypes/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            SubtypeModel subtype = db.Subtypes.Find(id);
//            db.Subtypes.Remove(subtype);
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
