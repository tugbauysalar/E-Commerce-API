using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        // sipariş için gerekli propertyler tanımlandı.
        public decimal Price { get; set; }
        public decimal PurchasedPrice { get; set; }
        public string Address { get; set; }
        public List<Product> Products { get; set; }
    }
}
