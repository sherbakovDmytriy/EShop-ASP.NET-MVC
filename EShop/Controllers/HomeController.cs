using AutoMapper;
using BLL.Interfaces;
using EShop.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _automapper;

        public HomeController(IProductService productService, IMapper automapper)
        {
            _productService = productService;
            _automapper = automapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Landing()
        {
            var productsDTO = await _productService.GetProducts(5);
            var products = _automapper.Map<List<LandingVM>>(productsDTO);

            return View(products);
        }

        public ActionResult Cart()
        {
            return View();
        }

        // TODO finish
        public ActionResult ProductModel(int id)
        {
            return null;
            //ProductDTO productsDTO = _productService.GetProduct(id);
            
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

        //public ActionResult Filters(int id, int categoryId = 0, int sizeId = 0, int tradeMarkId = 0)
        //{
        //    IQueryable<ProductModel> products = db.Products.Where(p => p.TypeId == id);

        //    TypeModel type = null;
        //    IList<SizeModel> sizes = new List<SizeModel>();
        //    IList<TradeMarkModel> tradeMarks = new List<TradeMarkModel>();

        //    if (categoryId != 0)
        //    {
        //        type = db.Types.Where(t => t.Id == id)
        //            .FirstOrDefault();
        //        db.Subtypes.Find(categoryId);

        //        products = products.Where(p => p.SubtypeId == categoryId);
        //    }
        //    else
        //    {
        //        type = db.Types.Where(t => t.Id == id)
        //            .Include(t => t.Subtypes)
        //            .FirstOrDefault();
        //    }

        //    if (sizeId != 0)
        //    {
        //        var size = db.Sizes.Find(sizeId);
        //        sizes.Add(size);

        //        products = products.Where(p => p.Sizes.Contains(size));
        //    }
        //    else
        //    {
        //        sizes = db.Sizes.ToList();
        //    }

        //    if (tradeMarkId != 0)
        //    {
        //        tradeMarks.Add(db.TradeMarks.Find(tradeMarkId));
        //        products = products.Where(p => p.TradeMarkId == tradeMarkId);
        //    }
        //    else
        //    {
        //        tradeMarks = db.TradeMarks.ToList();
        //    }


        //    ViewBag.products = products.Include(p => p.Sizes)
        //        .Include(p => p.SubtypeModel)
        //        .Include(p => p.TradeMarkModel)
        //        .Include(p => p.TypeModel)
        //        .ToList();


        //    ViewBag.type = type;

        //    ViewBag.sizes = sizes;
        //    ViewBag.tradeMarks = tradeMarks;

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Types()
        //{
        //    var types = db.Types.ToList();
        //    return PartialView("Types", types);
        //}

        //[HttpPost]
        //public JsonResult CartProducts()
        //{
        //    string[] keys = Request.Form.AllKeys;
        //    var products = new List<ProductModel>();

        //    for (int i = 0; i < keys.Length; i += 2)
        //    {
        //        int productId = Convert.ToInt32(Request.Form.Get(keys[i]));
        //        int sizeId = Convert.ToInt32(Request.Form.Get(keys[i + 1]));

        //        var product = db.Products.Find(productId);

        //        product.Sizes = new List<SizeModel>
        //        {
        //            db.Sizes.Find(sizeId)
        //        };

        //        products.Add(product);
        //    }

        //    return Json(products);
        //}
    }
}