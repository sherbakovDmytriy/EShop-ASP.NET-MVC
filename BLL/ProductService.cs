using AutoMapper;
using DAL;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
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

        public async Task<IEnumerable<Product>> GetProducts(int? limit = null)
        {
            return await _unitOfWork.GetRepository<Product>()
                .GetWithInclude(limit, p => p.Sizes, p => p.Type, p => p.Subtype, p => p.TradeMark);
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _unitOfWork
                .GetRepository<Product>()
                .FirstWithInclude
                (
                    p => p.Sizes,
                    p => p.Type,
                    p => p.Subtype,
                    p => p.TradeMark
                );
        }
    }
}
