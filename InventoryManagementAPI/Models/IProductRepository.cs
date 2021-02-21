using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models
{
    public interface IProductRepository
    {
        Product GetProduct(int id);

        List<Product> GetAllProduct();

        Product AddProduct(Product product);
    }
}
