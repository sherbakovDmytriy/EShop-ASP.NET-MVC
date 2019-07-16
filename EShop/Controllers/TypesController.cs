using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using EShop.Models.Types;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class TypesController : Controller
    {
        private readonly ITypeService _typeService;
        private readonly IMapper _automapper;

        public TypesController(ITypeService typeService, IMapper automapper)
        {
            _typeService = typeService;
            _automapper = automapper;
        }

        // GET: TradeMarks
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var typesDTO = await _typeService.GetTypesAsync(10);
            var types = _automapper.Map<IEnumerable<TypeVM>>(typesDTO);
            return View(types);
        }

        // GET: TradeMarks/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int Id)
        {
            var typeDTO = await _typeService.GetTypeAsync(Id);

            if (typeDTO == null)
                return HttpNotFound();

            return View(_automapper.Map<TypeVM>(typeDTO));
        }

        // GET: TradeMarks/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TradeMarks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TypeCreateEditVM model)
        {
            var typeDTO = _automapper.Map<TypeDTO>(model);

            if (await _typeService.CreateAsync(typeDTO) == false)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Create error");

            return RedirectToAction("Index");
        }

        // GET: TradeMarks/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int Id)
        {
            var typeDTO = await _typeService.GetTypeAsync(Id);

            if (typeDTO == null)
                return HttpNotFound();

            return View(_automapper.Map<TypeCreateEditVM>(typeDTO));
        }

        // POST: TradeMarks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TypeCreateEditVM model)
        {
            var typeDTO = _automapper.Map<TypeDTO>(model);

            if (await _typeService.EditAsync(typeDTO) == false)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Edit error");

            return RedirectToAction("Index");
        }

        // GET: TradeMarks/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int Id)
        {
            var typeDTO = await _typeService.GetTypeAsync(Id);

            if (typeDTO == null)
                return HttpNotFound();

            return View(_automapper.Map<TypeVM>(typeDTO));
        }

        // POST: TradeMarks/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int Id)
        {
            var typeDTO = await _typeService.GetTypeWithSubtypesAsync(Id);

            if(typeDTO.Subtypes.Count > 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Нельзя удалить тип у которого не 0 подтипов");

            if (await _typeService.DeleteAsync(Id) == false)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Edit error");

            return RedirectToAction("Index");
        }
    }
}
