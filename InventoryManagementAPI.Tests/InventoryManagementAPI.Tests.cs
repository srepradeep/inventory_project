using Microsoft.VisualStudio.TestTools.UnitTesting;
using InventoryManagementAPI.Models;
using InventoryManagementAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace InventoryManagementAPI.Tests
{
    [TestClass]
    public class InventoryManagementAPITest
    {
        private T GetValueFromJsonResult<T>(JsonResult jsonResult, string propertyName)
        {
            var property =
                jsonResult.Value.GetType().GetProperties()
                .Where(p => string.Compare(p.Name, propertyName) == 0)
                .FirstOrDefault();

            if (null == property)
                throw new System.ArgumentException("propertyName not found", "propertyName");
            return (T)property.GetValue(jsonResult.Value, null);
        }

        [TestMethod]
        public void GetAllProduct_InvokeAPI_Return2Products()
        {
            //Arrange
            IProductRepository _productRepository = new MockProductRepository();
            ProductController controller = new ProductController(_productRepository);

            //ACT
            JsonResult actualResult = controller.Get();

            var result = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(JsonConvert.SerializeObject(actualResult));
            var actProduct = JsonConvert.DeserializeObject<List<Product>>(result.SelectToken("Value").ToString());

            
            //ASSERT
            Product expProduct = new Product()
            {
                Id = 1,
                ProdType = "Desktop",
                ProcessorType = "P7",
                Brand = "Dell",
                UsbPorts = 3,
                RamSlots = 2,
                FormFactor = "Tower",
                Quantity = 10
            };


            Assert.AreEqual(actProduct[0].Id, expProduct.Id);
            Assert.AreEqual(actProduct[0].ProdType, expProduct.ProdType);
            Assert.AreEqual(actProduct[0].Brand, expProduct.Brand);
            Assert.AreEqual(actProduct[0].ProcessorType, expProduct.ProcessorType);
            Assert.AreEqual(actProduct[0].Quantity, expProduct.Quantity);
            Assert.AreEqual(actProduct[0].UsbPorts, expProduct.UsbPorts);
            Assert.AreEqual(actProduct[0].RamSlots, expProduct.RamSlots);
            Assert.AreEqual(actProduct[0].FormFactor, expProduct.FormFactor);

        }

        [TestMethod]
        public void AddNewProduct_InvokeAPI_ReturnNewProduct()
        {
            //Arrange
            IProductRepository _productRepository = new MockProductRepository();
            ProductController controller = new ProductController(_productRepository);

            Product newProduct = new Product()
            {
                ProdType = "Desktop1",
                ProcessorType = "P71",
                Brand = "Dell1",
                UsbPorts = 3,
                RamSlots = 2,
                FormFactor = "Tower1",
                Quantity = 10
            };

            //ACT
            JsonResult actualResult = controller.Post(newProduct);

            //var result = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(JsonConvert.SerializeObject(actualResult));
            //var actProduct = JsonConvert.DeserializeObject<string>(result.SelectToken("Value").ToString());

            //ASSERT
            Assert.AreEqual(actualResult.Value.ToString(), "Product Added Successfully");

            JsonResult actualResult1 = controller.Get();

            var result1 = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(JsonConvert.SerializeObject(actualResult1));
            var actProduct1 = JsonConvert.DeserializeObject<List<Product>>(result1.SelectToken("Value").ToString());


            //ASSERT
            Product expProduct = new Product()
            {
                Id = 2,
                ProdType = "Desktop1",
                ProcessorType = "P71",
                Brand = "Dell1",
                UsbPorts = 3,
                RamSlots = 2,
                FormFactor = "Tower1",
                Quantity = 10
            };


            Assert.AreEqual(actProduct1[1].Id, expProduct.Id);
            Assert.AreEqual(actProduct1[1].ProdType, expProduct.ProdType);
            Assert.AreEqual(actProduct1[1].Brand, expProduct.Brand);
            Assert.AreEqual(actProduct1[1].ProcessorType, expProduct.ProcessorType);
            Assert.AreEqual(actProduct1[1].Quantity, expProduct.Quantity);
            Assert.AreEqual(actProduct1[1].UsbPorts, expProduct.UsbPorts);
            Assert.AreEqual(actProduct1[1].RamSlots, expProduct.RamSlots);
            Assert.AreEqual(actProduct1[1].FormFactor, expProduct.FormFactor);

        }
    }
}
