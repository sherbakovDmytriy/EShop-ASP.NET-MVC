using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts(int? limit = null);
        Product GetProduct(int id);
    }
}
