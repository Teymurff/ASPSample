using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P310_ASP_Start.Controllers
{
    public class PostsController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public string GetAge(string year)
        {
            return year;
        }
    }
}
