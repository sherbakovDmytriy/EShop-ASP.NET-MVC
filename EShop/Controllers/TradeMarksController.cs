using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using EShop.Models;
using EShop.Models.Products;
using EShop.Models.TradeMarks;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class TradeMarksController : Controller
    {
        private readonly ITradeMarkService _tradeMarkService;
        private readonly IMapper _automapper;

        public TradeMarksController(ITradeMarkService tradeMarkService, IMapper automapper)
        {
            _tradeMarkService = tradeMarkService;
            _automapper = automapper;
        }

        // GET: TradeMarks
        public async Task<ActionResult> Index()
        {
            var tradeMarksDTO = await _tradeMarkService.GetTradeMarksAsync(10);
            var tradeMarks = _automapper.Map<IEnumerable<TradeMarkVM>>(tradeMarksDTO);
            return View(tradeMarks);
        }

        // GET: TradeMarks/Details/5
        public async Task<ActionResult> Details(int Id)
        {
            var tradeMarkDTO = await _tradeMarkService.GetTradeMarkAsync(Id);

            if (tradeMarkDTO == null)
                return HttpNotFound();

            return View(_automapper.Map<TradeMarkVM>(tradeMarkDTO));
        }

        // GET: TradeMarks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TradeMarks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TradeMarkCreateEditVM model)
        {
            var tradeMarkDTO = _automapper.Map<TradeMarkDTO>(model);

            if (await _tradeMarkService.CreateAsync(tradeMarkDTO) == false)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Create error");

            return RedirectToAction("Index");
        }

        // GET: TradeMarks/Edit/5
        public async Task<ActionResult> Edit(int Id)
        {
            var tradeMarkDTO = await _tradeMarkService.GetTradeMarkAsync(Id);

            if (tradeMarkDTO == null)
            {
                return HttpNotFound();
            }

            return View(_automapper.Map<TradeMarkCreateEditVM>(tradeMarkDTO));
        }

        // POST: TradeMarks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TradeMarkCreateEditVM model)
        {
            var tradeMarkDTO = _automapper.Map<TradeMarkDTO>(model);

            if(await _tradeMarkService.EditAsync(tradeMarkDTO) == false)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Edit error");

            return RedirectToAction("Index");
        }

        // GET: TradeMarks/Delete/5
        public async Task<ActionResult> Delete(int Id)
        {
            var tradeMarkDTO = await _tradeMarkService.GetTradeMarkAsync(Id);

            if (tradeMarkDTO == null)
                return HttpNotFound();

            return View(_automapper.Map<TradeMarkVM>(tradeMarkDTO));
        }

        // POST: TradeMarks/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int Id)
        {
            if (await _tradeMarkService.DeleteAsync(Id) == false)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Edit error");

            return RedirectToAction("Index");
        }
    }
}
