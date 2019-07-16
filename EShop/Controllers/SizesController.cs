using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using EShop.Models.Sizes;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class SizesController : Controller
    {
        private readonly ISizeService _sizeService;
        private readonly IMapper _automapper;

        public SizesController(ISizeService sizeService, IMapper automapper)
        {
            _sizeService = sizeService;
            _automapper = automapper;
        }

        // GET: Sizes
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var sizesDTO = await _sizeService.GetSizesAsync(10);
            var sizes = _automapper.Map<IEnumerable<SizeVM>>(sizesDTO);
            return View(sizes);
        }

        // GET: Sizes/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int Id)
        {
            var sizeDTO = await _sizeService.GetSizeAsync(Id);

            if (sizeDTO == null)
                return HttpNotFound();

            return View(_automapper.Map<SizeVM>(sizeDTO));
        }

        // GET: Sizes/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sizes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SizeCreateEditVM model)
        {
            var sizeDTO = _automapper.Map<SizeDTO>(model);

            if (await _sizeService.CreateAsync(sizeDTO) == false)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Create error");

            return RedirectToAction("Index");
        }

        // GET: Sizes/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int Id)
        {
            var sizeDTO = await _sizeService.GetSizeAsync(Id);

            if (sizeDTO == null)
                return HttpNotFound();

            return View(_automapper.Map<SizeCreateEditVM>(sizeDTO));
        }

        // POST: Sizes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SizeCreateEditVM model)
        {
            var sizeDTO = _automapper.Map<SizeDTO>(model);

            if (await _sizeService.EditAsync(sizeDTO) == false)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Edit error");

            return RedirectToAction("Index");
        }

        // GET: Sizes/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int Id)
        {
            var sizeDTO = await _sizeService.GetSizeAsync(Id);

            if (sizeDTO == null)
                return HttpNotFound();

            return View(_automapper.Map<SizeVM>(sizeDTO));
        }

        // POST: Sizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int Id)
        {
            if (await _sizeService.DeleteAsync(Id) == false)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Edit error");

            return RedirectToAction("Index");
        }
    }
}
