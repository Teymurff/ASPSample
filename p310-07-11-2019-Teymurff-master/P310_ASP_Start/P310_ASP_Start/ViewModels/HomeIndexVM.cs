using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P310_ASP_Start.Models;

namespace P310_ASP_Start.ViewModels
{
    public class HomeIndexVM
    {
        public IEnumerable<Slider> Sliders{ get; set; }
        public IEnumerable<NewArrival> NewArrivals { get; set; }
        public IEnumerable<Product> NewProducts { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> BestProducts { get; set; }
    }
}
