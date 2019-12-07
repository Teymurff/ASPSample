using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P310_ASP_Start.DAL;
using P310_ASP_Start.Models;
using P310_ASP_Start.ViewModels;

namespace P310_ASP_Start.Controllers
{
    public class AjaxController : Controller
    {
        private readonly EliteContext _context;

        public AjaxController(EliteContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetProductsByCategoryId(int id)
        {
            //eager loading
            //var category = await _context.Categories.
            //                              Include(c => c.Products).
            //                              FirstOrDefaultAsync(c => c.Id == id);

            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return Json(new
                {
                    status = 404,
                    message = "There is no category with this id",
                    data = ""
                });
            }

            return Json(new
            {
                status = 200,
                message = "",
                data = category.Products
                //data = category.Products.Select(p => new
                //{
                //    p.Id, p.Name, p.Image, p.Price, p.HasDiscount, p.DiscountedPrice
                //})
            });
        }

        [HttpPost]
        public IActionResult LoadMoreProducts(int count)
        {
            var vm = new ProductsPartialViewModel {
                Products = _context.Products.Skip(count).Take(4),
                ShowPrice = true,
                ShowCategoryClass = false
            };

            return PartialView("_ProductsPartial", vm);

            //return Json( new
            //{
            //    status = 200,
            //    message = "salam",
            //    data = _context.Products.Skip(count).Take(4).ToList()
            //});
        }
    }
}