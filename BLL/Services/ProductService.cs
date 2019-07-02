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
        private readonly IMapper _automapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper automapper)
        {
            _unitOfWork = unitOfWork;
            _automapper = automapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts(int? limit = null)
        {
            var products = await _unitOfWork.GetRepository<Product>()
                .GetWithInclude(limit, p => p.Sizes, p => p.Type, p => p.Subtype, p => p.TradeMark);

            return _automapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
            var product = await _unitOfWork
                .GetRepository<Product>()
                .FirstWithInclude
                (
                    p => p.Id == id,
                    p => p.Sizes,
                    p => p.Type,
                    p => p.Subtype,
                    p => p.TradeMark
                );

            return _automapper.Map<ProductDTO>(product);
        }
    }
}
