//using AutoMapper;
//using BLL;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;

//namespace EShop.Controllers
//{
//    public class ProductsController : Controller
//    {
//        private readonly IProductService _productService;
//        private readonly IMapper _automapper;

//        public ProductsController(IProductService productService, IMapper automapper)
//        {
//            _productService = productService;
//            _automapper = automapper;
//        }

//        // GET: Products
//        public ActionResult Index()
//        {
//            //var products = db.Products.Include(p => p.Sizes)
//            //    .Include(p => p.SubtypeModel)
//            //    .Include(p => p.TradeMarkModel)
//            //    .Include(p => p.TypeModel);

//            //return View(products.ToList());
//        }

//        // GET: Products/Details/5
//        public ActionResult Details(int? id)
//        {
//            //if (id == null)
//            //{
//            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            //}

//            //ProductModel product = db.Products.Where(p => p.Id == id)
//            //    .Include(p => p.Sizes)
//            //    .Include(p => p.TypeModel)
//            //    .Include(p => p.SubtypeModel)
//            //    .Include(p => p.TradeMarkModel)
//            //    .FirstOrDefault();

//            //if (product == null)
//            //{
//            //    return HttpNotFound();
//            //}

//            //return View(product);
//        }

//        // GET: Products/Create
//        public ActionResult Create()
//        {
//            //ViewBag.TypeId = new SelectList(db.Types, "Id", "Name");

//            //var firstTypeID = db.Types.ToList().First().Id;
//            //var subtypes = db.Subtypes.Where(s => s.TypeId == firstTypeID).ToList();
//            //ViewBag.SubtypeId = new SelectList(subtypes, "Id", "Name");

//            //ViewBag.TradeMarkId = new SelectList(db.TradeMarks, "Id", "Name");
//            //ViewBag.Sizes = db.Sizes;

//            //return View();
//        }

//        // POST: Products/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,Name,Materials,Price,Description,TypeId,SubtypeId,TradeMarkId")] ProductModel product, HttpPostedFileBase uploadImage, string[] sizes)
//        {
//            //if (ModelState.IsValid)
//            //{
//            //    string fileName = System.IO.Path.GetFileName(uploadImage.FileName);
//            //    // сохраняем файл в папку Pictures в проекте
//            //    uploadImage.SaveAs(Server.MapPath("~/Pictures/" + fileName));

//            //    product.PictureName = fileName;
//            //    product.PictureType = uploadImage.ContentType;

//            //    foreach (var sizeID in sizes)
//            //    {
//            //        product.Sizes.Add(db.Sizes.Find(Convert.ToInt32(sizeID)));
//            //    }

//            //    db.Products.Add(product);
//            //    db.SaveChanges();

//            //    return RedirectToAction("Index");
//            //}

//            //ViewBag.SubtypeId = new SelectList(db.Subtypes, "Id", "Name", product.SubtypeId);
//            //ViewBag.TradeMarkId = new SelectList(db.TradeMarks, "Id", "Name", product.TradeMarkId);
//            //ViewBag.TypeId = new SelectList(db.Types, "Id", "Name", product.TypeId);

//            //return View(product);
//        }

//        // GET: Products/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            //if (id == null)
//            //{
//            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            //}

//            //ProductModel product = db.Products.Where(p => p.Id == id)
//            //    .Include(p => p.Sizes)
//            //    .FirstOrDefault();

//            //if (product == null)
//            //{
//            //    return HttpNotFound();
//            //}

//            //ViewBag.SubtypeId = new SelectList(db.Subtypes, "Id", "Name", product.SubtypeId);
//            //ViewBag.TradeMarkId = new SelectList(db.TradeMarks, "Id", "Name", product.TradeMarkId);
//            //ViewBag.TypeId = new SelectList(db.Types, "Id", "Name", product.TypeId);
//            //ViewBag.Sizes = db.Sizes;

//            //return View(product);
//        }

//        // POST: Products/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,Name,Materials,Price,Description,TypeId,SubtypeId,TradeMarkId")] ProductModel product, HttpPostedFileBase uploadImage, string[] sizes)
//        {
//            //if (ModelState.IsValid)
//            //{
//            //    ProductModel curentProduct = db.Products.Where(p => p.Id == product.Id)
//            //        .Include(p => p.Sizes)
//            //        .FirstOrDefault();

//            //    curentProduct.Sizes = new List<SizeModel>();
//            //    foreach (var sizeID in sizes)
//            //    {
//            //        curentProduct.Sizes.Add(db.Sizes.Find(Convert.ToInt32(sizeID)));
//            //    }

//            //    if (uploadImage != null)
//            //    {
//            //        string fileName = System.IO.Path.GetFileName(uploadImage.FileName);
//            //        // сохраняем файл в папку Pictures в проекте
//            //        uploadImage.SaveAs(Server.MapPath("~/Pictures/" + fileName));

//            //        product.PictureName = fileName;
//            //        product.PictureType = uploadImage.ContentType;

//            //        db.Entry(product).State = EntityState.Modified;
//            //    }
//            //    else
//            //    {
//            //        product.PictureName = curentProduct.PictureName;

//            //        db.Entry(curentProduct).CurrentValues.SetValues(product);
//            //        db.Entry(curentProduct).State = EntityState.Modified;
//            //    }

//            //    db.SaveChanges();
//            //    return RedirectToAction("Index");
//            //}

//            //ViewBag.SubtypeId = new SelectList(db.Subtypes, "Id", "Name", product.SubtypeId);
//            //ViewBag.TradeMarkId = new SelectList(db.TradeMarks, "Id", "Name", product.TradeMarkId);
//            //ViewBag.TypeId = new SelectList(db.Types, "Id", "Name", product.TypeId);

//            //return View(product);
//        }

//        // GET: Products/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            //if (id == null)
//            //{
//            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            //}

//            //ProductModel product = db.Products.Where(p => p.Id == id)
//            //    .Include(p => p.Sizes)
//            //    .Include(p => p.TypeModel)
//            //    .Include(p => p.SubtypeModel)
//            //    .Include(p => p.TradeMarkModel)
//            //    .FirstOrDefault();

//            //if (product == null)
//            //{
//            //    return HttpNotFound();
//            //}

//            //return View(product);
//        }

//        // POST: Products/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            //ProductModel product = db.Products.Find(id);
//            //db.Products.Remove(product);
//            //db.SaveChanges();

//            //return RedirectToAction("Index");
//        }

//        [HttpPost]
//        public ActionResult GetSubtypes(int id)
//        {
//            //var subtypes = db.Subtypes.Where(s => s.TypeId == id).ToList();

//            //return View(subtypes);
//        }
//    }
//}
