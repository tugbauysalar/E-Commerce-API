using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }

        //kategoriye ait ürünleri tutmak için bir liste tanımlandı
        public List<Product> Products { get; set; }
    }
}
