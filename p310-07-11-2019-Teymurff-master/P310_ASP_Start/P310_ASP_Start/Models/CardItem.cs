using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P310_ASP_Start.Models;

namespace P310_ASP_Start.Models
{
    public class CardItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public byte Count { get; set; }
    }
}
