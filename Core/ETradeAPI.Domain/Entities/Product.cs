using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    //Ürüne ait propertyler tanımlandı. Ortak olan propertyler için baseentitiyden kalıtım yapıldı.
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        //her ürünün bir kategorisi olduğu için ürünün ait olduğu kategori tanımlandı
        public Category Category { get; set; }
        public List<Order> Orders { get; set; }
    }
}
