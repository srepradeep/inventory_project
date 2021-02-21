using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models
{
    public class MockProductRepository : IProductRepository
    {
        List<Product> _productList;

        public MockProductRepository()
        {
            _productList = new List<Product>()
            {
                new Product() { Id = 1 ,ProdType = "Desktop",ProcessorType="P7", Brand="Dell",UsbPorts=3, RamSlots=2,FormFactor="Tower",Quantity= 10}
                //new Product() { Id = 2 ,ProdType = "Laptop",ProcessorType="P7", Brand="Lenovo",UsbPorts=3, RamSlots=5,FormFactor="Laptop",Quantity= 20}
            };
        }

        public Product AddProduct(Product product)
        {
            int id = this._productList.Count() + 1;
            product.Id = this._productList.Count() + 1;
            this._productList.Add(product);
            return product;
        }

        public List<Product> GetAllProduct()
        {
            return _productList;
        }

        public Product GetProduct(int id)
        {
            return _productList.FirstOrDefault(prod => prod.Id == id);
        }
    }
}
