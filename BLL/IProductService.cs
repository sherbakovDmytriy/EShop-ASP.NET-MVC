using BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts(int? limit = null);
        Task<ProductDTO> GetProduct(int id);
    }
}
