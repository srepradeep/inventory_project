using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string  ProdType { get; set; }

        public string  ProcessorType { get; set; }

        public string Brand { get; set; }

        public int UsbPorts { get; set; }

        public int RamSlots { get; set; }

        public string FormFactor { get; set; }

        public int Quantity { get; set; }

        public Product(int id, string prodType,string processorType, string brand, int usbPorts, int ramSlots, string formFactor, int quantity)
        {
            this.Id = id;
            this.ProdType = prodType;
            this.ProcessorType = processorType;
            this.Brand = brand;
            this.UsbPorts = usbPorts;
            this.RamSlots = ramSlots;
            this.FormFactor = formFactor;
            this.Quantity = quantity;

        }
        public Product()
        {

        }
    }
}
