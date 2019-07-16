using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SizeService : ISizeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Size> _repository;

        public SizeService(IUnitOfWork unitOfWork, IMapper automapper)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Size>();
            _mapper = automapper;
        }

        #region Get

        public async Task<IEnumerable<SizeDTO>> GetSizesAsync(int? limit = null)
        {
            var sizes = await _repository.Get(limit);
            return _mapper.Map<IEnumerable<SizeDTO>>(sizes);
        }

        public async Task<SizeDTO> GetSizeAsync(int Id)
        {
            var size = await _repository.FindById(Id);
            return _mapper.Map<SizeDTO>(size);
        }

        #endregion

        #region Create Edit Delete

        public async Task<bool> CreateAsync(SizeDTO model)
        {
            var size = _mapper.Map<Size>(model);
            _repository.Add(size);

            return await _repository.SaveAsync() > 0 ? true : false;
        }

        public async Task<bool> EditAsync(SizeDTO model)
        {
            var size = _mapper.Map<Size>(model);
            _repository.Edit(size);

            return await _repository.SaveAsync() > 0 ? true : false;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var size = await _repository.FindById(Id);
            _repository.Remove(size);

            return await _repository.SaveAsync() > 0 ? true : false;
        }

        #endregion
    }
}
