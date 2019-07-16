using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TypeService : ITypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Type> _repository;

        public TypeService(IUnitOfWork unitOfWork, IMapper automapper)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Type>();
            _mapper = automapper;
        }

        #region Get

        public async Task<IEnumerable<TypeDTO>> GetTypesAsync(int? limit = null)
        {
            var types = await _repository.Get(limit);
            return _mapper.Map<IEnumerable<TypeDTO>>(types);
        }

        public async Task<IEnumerable<TypeDTO>> GetTypesWithSubtypesAsync(int? limit = null)
        {
            var types = await _repository.GetWithInclude(limit, t => t.Subtypes);
            return _mapper.Map<IEnumerable<TypeDTO>>(types);
        }

        public async Task<TypeDTO> GetTypeAsync(int Id)
        {
            var type = await _repository.FindById(Id);
            return _mapper.Map<TypeDTO>(type);
        }

        public async Task<TypeDTO> GetTypeWithSubtypesAsync(int Id)
        {
            var type = await _repository.FirstWithInclude(t => t.Id == Id, t => t.Subtypes);
            return _mapper.Map<TypeDTO>(type);
        }

        #endregion

        #region Create Edit Delete

        public async Task<bool> CreateAsync(TypeDTO model)
        {
            var type = _mapper.Map<Type>(model);
            _repository.Add(type);

            return await _repository.SaveAsync() > 0 ? true : false;
        }

        public async Task<bool> EditAsync(TypeDTO model)
        {
            var type = _mapper.Map<Type>(model);
            _repository.Edit(type);

            return await _repository.SaveAsync() > 0 ? true : false;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var type = await _repository.FindById(Id);
            _repository.Remove(type);

            return await _repository.SaveAsync() > 0 ? true : false;
        }

        #endregion
    }
}
