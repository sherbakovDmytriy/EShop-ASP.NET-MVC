using AutoMapper;
using BLL;
using BLL.DTO;
using BLL.Interfaces;
using EShop.Models.Products;
using EShop.Models.Sizes;
using EShop.Models.Subtypes;
using EShop.Models.TradeMarks;
using EShop.Models.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ITypeService _typeService;
        private readonly ISubtypeService _subtypeService;
        private readonly ISizeService _sizeService;
        private readonly ITradeMarkService _tradeMarkService;
        private readonly IMapper _automapper;

        public ProductsController
        (
            IProductService productService,
            ITypeService typeService,
            ISubtypeService subtypeService,
            ISizeService sizeService,
            ITradeMarkService tradeMarkService,
            IMapper automapper
        )
        {
            _productService = productService;
            _typeService = typeService;
            _subtypeService = subtypeService;
            _sizeService = sizeService;
            _tradeMarkService = tradeMarkService;
            _automapper = automapper;
        }

        // GET: Products
        public async Task<ActionResult> Index()
        {
            var productsDTO = await _productService.GetProducts(10);
            var products = _automapper.Map<IEnumerable<ProductVM>>(productsDTO);
            return View(products);

            //var products = db.Products.Include(p => p.Sizes)
            //    .Include(p => p.SubtypeModel)
            //    .Include(p => p.TradeMarkModel)
            //    .Include(p => p.TypeModel);

            //return View(products.ToList());
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            return null;
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //ProductModel product = db.Products.Where(p => p.Id == id)
            //    .Include(p => p.Sizes)
            //    .Include(p => p.TypeModel)
            //    .Include(p => p.SubtypeModel)
            //    .Include(p => p.TradeMarkModel)
            //    .FirstOrDefault();

            //if (product == null)
            //{
            //    return HttpNotFound();
            //}

            //return View(product);
        }

        // GET: Products/Create
        public async Task<ActionResult> Create()
        {
            // Get Types
            var typesDTO = await _typeService.GetTypesAsync();
            var types = _automapper.Map<IEnumerable<TypeVM>>(typesDTO);
            ViewBag.types = types;

            // Get Subtypes
            var firstTypeID = types.FirstOrDefault().Id;
            var subtypesDTO = await _subtypeService.GetByTypeAsync(firstTypeID);
            ViewBag.subtypes = _automapper.Map<IEnumerable<SubtypeVM>>(subtypesDTO);

            // Get TradeMarks
            var tradeMarksDTO = await _tradeMarkService.GetTradeMarksAsync();
            ViewBag.tradeMarks = _automapper.Map<IEnumerable<TradeMarkVM>>(tradeMarksDTO);

            // Get Sizes
            var sizesDTO = await _sizeService.GetSizesAsync();
            var sizes = _automapper.Map<IEnumerable<SizeVM>>(sizesDTO);
            ViewBag.Sizes = sizes;

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public async Task<ActionResult> Create(ProductCreateEditVM model, HttpPostedFileBase upload, int[] sizes)
        {
            // сохраняем файл в папку Pictures в проекте
            string fileName = System.IO.Path.GetFileName(upload.FileName);
            upload.SaveAs(Server.MapPath("~/Content/Pictures/" + fileName));

            string domain = Request.Url.Scheme + Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);
            var filePath = domain + "/Content/Pictures/" + fileName;

            model.Picture = new Models.PictureVM
            {
                Name = fileName,
                Path = filePath
            };

            var productDTO = _automapper.Map<ProductDTO>(model);

            if (!await _productService.CreateAsync(productDTO, sizes))
                throw new Exception("Saving error");

            return RedirectToAction("Index");
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            // Get current Product
            var productDTO = await _productService.GetProduct(id);
            var product = _automapper.Map<ProductCreateEditVM>(productDTO);

            // Get Types
            var typesDTO = await _typeService.GetTypesAsync();
            var types = _automapper.Map<IEnumerable<TypeVM>>(typesDTO);
            ViewBag.types = types;

            // Get Subtypes
            var firstTypeID = types.FirstOrDefault(t => t.Id == product.TypeId).Id;
            var subtypesDTO = await _subtypeService.GetByTypeAsync(firstTypeID);
            ViewBag.subtypes = _automapper.Map<IEnumerable<SubtypeVM>>(subtypesDTO);

            // Get TradeMarks
            var tradeMarksDTO = await _tradeMarkService.GetTradeMarksAsync();
            ViewBag.tradeMarks = _automapper.Map<IEnumerable<TradeMarkVM>>(tradeMarksDTO);

            // Get Sizes
            var sizesDTO = await _sizeService.GetSizesAsync();
            var sizes = _automapper.Map<IEnumerable<SizeVM>>(sizesDTO);
            ViewBag.Sizes = sizes;

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductCreateEditVM model, HttpPostedFileBase upload, int[] sizes)
        {
            // сохраняем файл в папку Pictures в проекте
            string fileName = System.IO.Path.GetFileName(upload.FileName);
            upload.SaveAs(Server.MapPath("~/Content/Pictures/" + fileName));

            string domain = Request.Url.Scheme + Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);
            var filePath = domain + "/Content/Pictures/" + fileName;

            model.Picture = new Models.PictureVM
            {
                Name = fileName,
                Path = filePath
            };

            var productDTO = _automapper.Map<ProductDTO>(model);

            if (!await _productService.CreateAsync(productDTO, sizes))
                throw new Exception("Saving error");

            return RedirectToAction("Index");
            //if (ModelState.IsValid)
            //{
            //    ProductModel curentProduct = db.Products.Where(p => p.Id == product.Id)
            //        .Include(p => p.Sizes)
            //        .FirstOrDefault();

            //    curentProduct.Sizes = new List<SizeModel>();
            //    foreach (var sizeID in sizes)
            //    {
            //        curentProduct.Sizes.Add(db.Sizes.Find(Convert.ToInt32(sizeID)));
            //    }

            //    if (uploadImage != null)
            //    {
            //        string fileName = System.IO.Path.GetFileName(uploadImage.FileName);
            //        // сохраняем файл в папку Pictures в проекте
            //        uploadImage.SaveAs(Server.MapPath("~/Pictures/" + fileName));

            //        product.PictureName = fileName;
            //        product.PictureType = uploadImage.ContentType;

            //        db.Entry(product).State = EntityState.Modified;
            //    }
            //    else
            //    {
            //        product.PictureName = curentProduct.PictureName;

            //        db.Entry(curentProduct).CurrentValues.SetValues(product);
            //        db.Entry(curentProduct).State = EntityState.Modified;
            //    }

            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.SubtypeId = new SelectList(db.Subtypes, "Id", "Name", product.SubtypeId);
            //ViewBag.TradeMarkId = new SelectList(db.TradeMarks, "Id", "Name", product.TradeMarkId);
            //ViewBag.TypeId = new SelectList(db.Types, "Id", "Name", product.TypeId);

            //return View(product);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            return null;
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //ProductModel product = db.Products.Where(p => p.Id == id)
            //    .Include(p => p.Sizes)
            //    .Include(p => p.TypeModel)
            //    .Include(p => p.SubtypeModel)
            //    .Include(p => p.TradeMarkModel)
            //    .FirstOrDefault();

            //if (product == null)
            //{
            //    return HttpNotFound();
            //}

            //return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            return null;
            //ProductModel product = db.Products.Find(id);
            //db.Products.Remove(product);
            //db.SaveChanges();

            //return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> GetSubtypes(int id)
        {
            var subtypes = await _subtypeService.GetByTypeAsync(id);
            return null;
            //var subtypes = db.Subtypes.Where(s => s.TypeId == id).ToList();

            //return View(subtypes);
        }
    }
}
