using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P310_ASP_Start.Models;

namespace P310_ASP_Start.ViewModels
{
    public class ProductsPartialViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public bool ShowPrice { get; set; }
        public bool ShowCategoryClass { get; set; }
    }
}
