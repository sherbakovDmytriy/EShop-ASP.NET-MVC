using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TradeMarkService : ITradeMarkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<TradeMark> _repository;

        public TradeMarkService(IUnitOfWork unitOfWork, IMapper automapper)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<TradeMark>();
            _mapper = automapper;
        }

        #region Get

        public async Task<IEnumerable<TradeMarkDTO>> GetTradeMarksAsync(int? limit = null)
        {
            var tradeMarks = await _repository.Get(limit);
            return _mapper.Map<IEnumerable<TradeMarkDTO>>(tradeMarks);
        }

        public async Task<TradeMarkDTO> GetTradeMarkAsync(int Id)
        {
            var tradeMark = await _repository.FindById(Id);
            return _mapper.Map<TradeMarkDTO>(tradeMark);
        }

        #endregion

        #region Create Edit Delete

        public async Task<bool> CreateAsync(TradeMarkDTO model)
        {
            var tradeMark = _mapper.Map<TradeMark>(model);
            _repository.Add(tradeMark);

            return await _repository.SaveAsync() > 0 ? true : false;
        }

        public async Task<bool> EditAsync(TradeMarkDTO model)
        {
            var tradeMark = _mapper.Map<TradeMark>(model);
            _repository.Edit(tradeMark);

            return await _repository.SaveAsync() > 0 ? true : false;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var tradeMark = await _repository.FindById(Id);
            _repository.Remove(tradeMark);

            return await _repository.SaveAsync() > 0 ? true : false;
        }

        #endregion
    }
}
