using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using P310_ASP_Start.Models;
using P310_ASP_Start.DAL;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace P310_ASP_Start.Controllers
{
    public class CartController : Controller
    {
        private readonly EliteContext _context;

        public CartController(EliteContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Add(int id)
        {

            var cart = new List<CardItem>();

            var cartSession = HttpContext.Session.GetString("cart");
            if (cartSession != null)
            {                cart = JsonConvert.DeserializeObject<List<CardItem>>(cartSession);
                
                if(cart.Any(c => c.ProductId == id))
                {
                    CardItem cardItem = cart.First(c => c.ProductId == id);
                    cardItem.Count++;
                }
                else
                {
                    var product = await _context.Products.
                                                Include(p => p.Category).
                                                FirstOrDefaultAsync(p => p.Id == id);
                    cart.Add(new CardItem
                    {
                        ProductName = product.Name,
                        ProductPrice = product.Price,
                        ProductId = product.Id,
                        CategoryName = product.Category.Name,
                        Image = product.Image,
                        Count = 1
                    });
                }
            }
            else
            {
                var product = await _context.Products.
                                                Include(p => p.Category).
                                                FirstOrDefaultAsync(p => p.Id == id);
                cart.Add(new CardItem
                {
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    ProductId = product.Id,
                    CategoryName = product.Category.Name,
                    Image = product.Image,
                    Count = 1
                });
            }
            
            string jsonList = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("cart", jsonList);

            return Json(new
            {
                status = 200,
                message = "New product was successfully added to cart",
                //data = cart.Count
                data = cart.Sum(c => c.Count)
            }) ;
        }

        public IActionResult Checkout()
        {
            List<CardItem> cart = new List<CardItem>();
            string cartSting = HttpContext.Session.GetString("cart");

            if (cartSting != null)
            {
                cart = JsonConvert.DeserializeObject<List<CardItem>>(cartSting);
            }

            return View(cart);
        }
    }
}