using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P310_ASP_Start.DAL;
using P310_ASP_Start.Models;
using P310_ASP_Start.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace P310_ASP_Start.Controllers
{
    public class HomeController : Controller
    {
        private readonly EliteContext _context;

        public HomeController(EliteContext context)
        {
            _context = context;
        }

        public ViewResult Index()
        {
            HomeIndexVM homeIndexVM = new HomeIndexVM()
            {
                Sliders = _context.Sliders,
                NewArrivals = _context.NewArrivals,
                NewProducts = _context.Products.Where(p => p.IsNew).ToList(),
                BestProducts = _context.Products.Take(4).ToList(),
                Categories = _context.Categories
            };

            ViewData["total_products_count"] = _context.Products.Count();

            return View(homeIndexVM);
        }

        public IActionResult About()
        {
            //int? counter = HttpContext.Session.GetInt32("counter");

            //if(counter == null)
            //{
            //    counter = 1;
            //}
            //else
            //{
            //    counter += 1;
            //}

            //HttpContext.Session.SetInt32("counter", (int)counter);

            //return Content(counter.ToString());

            return View();
        }

        public IActionResult Contact()
        {
            return View(_context.Categories);
        }

        public IActionResult Cookies()
        {
            ViewData["mode"] = Request.Cookies["mode"];
            return View();
        }

        public IActionResult Change(int id)
        {
            string value = "";
            switch (id)
            {
                case 1:
                    value = "default";
                    break;
                case 2:
                    value = "dark";
                    break;
                case 3:
                    value = "light";
                    break;
                default:
                    break;
            }

            Response.Cookies.Append("mode", value);

            return Json(new
            {
                status = 200,
                data = "",
                message = "Successfully changed"
            });
        }
    }
}