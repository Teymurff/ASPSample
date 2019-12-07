using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using P310_ASP_Start.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections;

namespace P310_ASP_Start.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserAndRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserAndRolesController(RoleManager<IdentityRole> roleManager,
                                      UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles);
        }

        public IActionResult Create()
        {
            //delete role
            //var role =  _roleManager.FindByIdAsync(id);
            //_roleManager.DeleteAsync(role);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole identityRole)
        {
            if(!ModelState.IsValid)
            {
                return View(identityRole);
            }

            var result = await _roleManager.CreateAsync(identityRole);

            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(identityRole);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Users(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if(role == null)
            {
                return RedirectToAction(nameof(Index));
            }

            IEnumerable<ApplicationUser> users = await _userManager.GetUsersInRoleAsync(role.Name);

            return View(users);
        }
    }
}