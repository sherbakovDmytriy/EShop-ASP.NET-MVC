using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper automapper)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Product>();
            _mapper = automapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts(int? limit = null)
        {
            var products = await _repository
                .GetWithInclude
                (
                    limit,
                    p => p.Sizes,
                    p => p.Type,
                    p => p.Subtype,
                    p => p.TradeMark,
                    p => p.Picture
                );

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
            var product = await _repository
                .FirstWithInclude
                (
                    p => p.Id == id,
                    p => p.Sizes,
                    p => p.Type,
                    p => p.Subtype,
                    p => p.TradeMark,
                    p => p.Picture
                );

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<bool> CreateAsync(ProductDTO model, int[] sizes)
        {
            var product = _mapper.Map<Product>(model);

            product.Sizes = await GetSizesByIdArr(sizes);

            _repository.Add(product);

            return await _repository.SaveAsync() > 0 ? true : false;
        }

        public async Task<bool> EditAsync(ProductDTO model, int[] sizes)
        {
            var product = _mapper.Map<Product>(model);

            product.Sizes = await GetSizesByIdArr(sizes);

            _repository.Edit(product);

            return await _repository.SaveAsync() > 0 ? true : false;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var product = await _repository.FindById(Id);
            _repository.Remove(product);

            return await _repository.SaveAsync() > 0 ? true : false;
        }

        private async Task<List<Size>> GetSizesByIdArr(int[] sizes)
        {
            var _sizeRepository = _unitOfWork.GetRepository<Size>();
            var sizesList = new List<Size>();

            foreach (var sizeId in sizes)
                sizesList.Add(await _sizeRepository.FindById(sizeId));

            return sizesList;
        }
    }
}
