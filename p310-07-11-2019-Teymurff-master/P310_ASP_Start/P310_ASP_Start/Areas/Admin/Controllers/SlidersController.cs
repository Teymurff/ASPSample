using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using P310_ASP_Start.DAL;
using P310_ASP_Start.Extensions;
using static P310_ASP_Start.Extensions.IFormFileExtensions;
using P310_ASP_Start.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace P310_ASP_Start.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly EliteContext _context;
        private readonly IHostingEnvironment _env;

        public SlidersController(EliteContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_context.Sliders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider) //Model binding
        {
            if(!ModelState.IsValid)
            {
                return View(slider);
            }

            //check photo
            if(slider.Photo == null)
            {
                ModelState.AddModelError("Photo", "Image should be selected");
                return View(slider);
            }

            //save new slider to db with new image
            if(!slider.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Image type is not valid");
                return View(slider);
            }

            //image type is ok, check size
            if(!slider.Photo.IsSmaller(1))
            {
                ModelState.AddModelError("Photo", "Image size can be maximum 1 mb");
                return View(slider);
            }

            slider.Image = await slider.Photo.SaveFileAsync(_env.WebRootPath, "img");

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            Slider slider = await _context.Sliders.FindAsync(id);

            if (slider == null) return NotFound();

            return View(slider);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Slider slider)
        {
            if(!ModelState.IsValid)
            {
                return View(slider);
            }
            var sliderDb = await _context.Sliders.FindAsync(slider.Id);

            if (slider.Photo != null)
            {
                //new photo exists, so delete old one, save new one
                try
                {
                    var newPhoto = await slider.Photo.SaveFileAsync(_env.WebRootPath, "img");

                    IFormFileExtensions.Delete(_env.WebRootPath, "img", sliderDb.Image);

                    sliderDb.Image = newPhoto;
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "Unexpected error happened while saving image. Please, try again.");
                    return View(slider);
                }
            }

            sliderDb.Title = slider.Title;
            sliderDb.SubTitle = slider.SubTitle;

            await _context.SaveChangesAsync();

            TempData["success_message"] = "Slider was updated successfully";

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(_context.Sliders.Count() <= 2)
            {
                return RedirectToAction(nameof(Index));
            }

            if (id == null) return NotFound();

            Slider slider = await _context.Sliders.FindAsync(id);

            if (slider == null) return NotFound();

            return View(slider);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();

            Slider slider = await _context.Sliders.FindAsync(id);

            if (slider == null) return NotFound();


            IFormFileExtensions.Delete(_env.WebRootPath, "img", slider.Image);
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();

            TempData["success_message"] = "Slider was removed successfully";

            return RedirectToAction(nameof(Index));
        }
    }
}