using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementAPI.Models;

namespace InventoryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_productRepository.GetAllProduct());
        }
        [HttpPost]
        public JsonResult Post(Product product)
        {
            if (product != null)
            {
                Product p = this._productRepository.AddProduct(product);
            }
            return new JsonResult("Product Added Successfully");
        }

    }
}
