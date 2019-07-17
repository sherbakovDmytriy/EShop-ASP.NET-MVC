using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SubtypeService : ISubtypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Subtype> _repository;

        public SubtypeService(IUnitOfWork unitOfWork, IMapper automapper)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Subtype>();
            _mapper = automapper;
        }

        #region Get

        public async Task<IEnumerable<SubtypeDTO>> GetSubtypesAsync(int? limit = null)
        {
            var subtypes = await _repository.GetWithInclude(limit, s => s.Type);
            return _mapper.Map<IEnumerable<SubtypeDTO>>(subtypes);
        }

        public async Task<SubtypeDTO> GetSubtypeAsync(int Id)
        {
            var subtypes = await _repository.FirstWithInclude(s => s.Id == Id, s => s.Type);
            return _mapper.Map<SubtypeDTO>(subtypes);
        }

        #endregion

        #region Create Edit Delete

        public async Task<bool> CreateAsync(SubtypeDTO model)
        {
            var subtypes = _mapper.Map<Subtype>(model);
            _repository.Add(subtypes);

            return await _repository.SaveAsync() > 0 ? true : false;
        }

        public async Task<bool> EditAsync(SubtypeDTO model)
        {
            var subtypes = _mapper.Map<Subtype>(model);
            _repository.Edit(subtypes);

            return await _repository.SaveAsync() > 0 ? true : false;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var subtypes = await _repository.FindById(Id);
            _repository.Remove(subtypes);

            return await _repository.SaveAsync() > 0 ? true : false;
        }

        #endregion
    }
}
