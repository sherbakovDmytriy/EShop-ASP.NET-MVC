using BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        #region Get

        Task<IEnumerable<ProductDTO>> GetProducts(int? limit = null);
        Task<ProductDTO> GetProduct(int id);

        #endregion

        #region Create Edit Delete

        Task<bool> CreateAsync(ProductDTO model, int[] sizes);
        Task<bool> EditAsync(ProductDTO model, int[] sizes);
        Task<bool> DeleteAsync(int Id);

        #endregion
    }
}
