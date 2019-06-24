using DAL.Models;
using System.Collections.Generic;

namespace BLL
{
    public interface IProductService
    {
        List<Product> GetProducts(int? limit = null);
        Product GetProduct(int id);
    }
}
