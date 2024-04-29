using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebsitePlant.Models;
using WebsitePlant.Repository;
namespace WebsitePlant.Controllers
{
    public class PlantsController : Controller
    {
        private readonly IPlantRepository _context;

        public PlantsController(IPlantRepository context)
        {
            _context = context;
        }

        // GET: Plants
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAllAsync());
        }

        // GET: Plants/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var plant = await _context.GetByIdAsync(id);
            if (plant == null)
            {
                return NotFound();
            }
            return View(plant);
        }



        // GET: Plants/Create
        public IActionResult Create()
        {
            return View();
        }
        private async Task<string> SaveImage(IFormFile image)
        {
            var savePath = Path.Combine("wwwroot/images", image.FileName);
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/images/" + image.FileName;
        }

        // POST: Plants/Create
        [HttpPost]
        public async Task<IActionResult> Create(Plant plant, IFormFile imageUrl)
        {
            if (ModelState.IsValid)
            {
                if (imageUrl != null)
                {
                    plant.ImageUrl = await SaveImage(imageUrl);
                }
                await _context.AddAsync(plant);
                return RedirectToAction(nameof(Index));
            }
            return View(plant);
        }

        // GET: Plants/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plant = await _context.GetByIdAsync(id);
            if (plant == null)
            {
                return NotFound();
            }
            return View(plant);
        }

        // POST: Plants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlantId,CommonName,OtherNames,ScientificName,Family,PlantPartUsed,PlantUse,ImageUrl")] Plant plant)
        {
            if (id != plant.PlantId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _context.UpdateAsync(plant);
                return RedirectToAction(nameof(Index));
            }
            return View(plant);
        }

        // GET: Plants/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var product = await _context.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Plants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
