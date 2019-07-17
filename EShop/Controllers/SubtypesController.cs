using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using EShop.Models.Subtypes;
using EShop.Models.Types;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class SubtypesController : Controller
    {
        private readonly ISubtypeService _subtypeService;
        private readonly ITypeService _typeService;
        private readonly IMapper _automapper;

        public SubtypesController(ISubtypeService subtypeService, ITypeService typeService, IMapper automapper)
        {
            _subtypeService = subtypeService;
            _typeService = typeService;
            _automapper = automapper;
        }

        // GET: TradeMarks
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var subtypesDTO = await _subtypeService.GetSubtypesAsync(10);
            var subtypes = _automapper.Map<IEnumerable<SubtypeVM>>(subtypesDTO);
            return View(subtypes);
        }

        // GET: TradeMarks/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int Id)
        {
            var subtypesDTO = await _subtypeService.GetSubtypeAsync(Id);

            if (subtypesDTO == null)
                return HttpNotFound();

            return View(_automapper.Map<SubtypeVM>(subtypesDTO));
        }

        // GET: TradeMarks/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var typesDTO = await _typeService.GetTypesAsync();
            ViewBag.types = _automapper.Map<IEnumerable<TypeVM>>(typesDTO);
            return View();
        }

        // POST: TradeMarks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SubtypeCreateEditVM model)
        {
            var subtypesDTO = _automapper.Map<SubtypeDTO>(model);

            if (await _subtypeService.CreateAsync(subtypesDTO) == false)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Create error");

            return RedirectToAction("Index");
        }

        // GET: TradeMarks/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int Id)
        {
            var subtypesDTO = await _subtypeService.GetSubtypeAsync(Id);

            if (subtypesDTO == null)
                return HttpNotFound();

            var typesDTO = await _typeService.GetTypesAsync();
            ViewBag.types = _automapper.Map<IEnumerable<TypeVM>>(typesDTO);

            return View(_automapper.Map<SubtypeCreateEditVM>(subtypesDTO));
        }

        // POST: TradeMarks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SubtypeCreateEditVM model)
        {
            var subtypesDTO = _automapper.Map<SubtypeDTO>(model);

            if (await _subtypeService.EditAsync(subtypesDTO) == false)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Edit error");

            return RedirectToAction("Index");
        }

        // GET: TradeMarks/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int Id)
        {
            var subtypesDTO = await _subtypeService.GetSubtypeAsync(Id);

            if (subtypesDTO == null)
                return HttpNotFound();

            return View(_automapper.Map<SubtypeVM>(subtypesDTO));
        }

        // POST: TradeMarks/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int Id)
        {
            if (await _subtypeService.DeleteAsync(Id) == false)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Edit error");

            return RedirectToAction("Index");
        }
    }
}
