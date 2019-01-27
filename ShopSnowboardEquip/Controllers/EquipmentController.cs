using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopSnowboardEquip.Data;
using ShopSnowboardEquip.Data.interfaces;
using ShopSnowboardEquip.Models;
using ShopSnowboardEquip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSnowboardEquip.Controllers
{
	public class EquipmentController : Controller

    {
		private readonly ICategoryRepository _categoryRepository;
		private readonly IEquipmentRepository _equipmentRepository;
		private readonly IGenderRepository _genderRepository;
	    private readonly AppDbContext _context;


        public EquipmentController(AppDbContext context, ICategoryRepository categoryRepository, IEquipmentRepository equipmentRepository, IGenderRepository genderRepository)
		{
			_categoryRepository = categoryRepository;
			_equipmentRepository = equipmentRepository;
            _genderRepository = genderRepository;
            _context = context;
        }

        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Equipment> equipments;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                equipments = _equipmentRepository.Equipments.OrderBy(p => p.EquipmentId);
                currentCategory = "All equipments";
            }
            else
            {
                if (string.Equals("SnowAccessories", _category, StringComparison.OrdinalIgnoreCase))
                    equipments = _equipmentRepository.Equipments.Where(p => p.Category.CategoryName.Equals("SnowAccessories")).OrderBy(p => p.Name);
                else
                    equipments = _equipmentRepository.Equipments.Where(p => p.Category.CategoryName.Equals("SnowOutfit")).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            return View(new EquipmentListViewModel
            {
                Equipment = equipments,
                CurrentCategory = currentCategory
            });
        }

		[Authorize(Roles = "Admin")]
		// GET: Equipments
		public async Task<IActionResult> Index()
		{
			var appDbContext = _context.Equipments.Include(e => e.Category).Include(e => e.Gender);
			return View(await appDbContext.ToListAsync());
		}

		// GET: Equipments/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var equipment = await _context.Equipments
				.Include(e => e.Category)
				.Include(e => e.Gender)
				.FirstOrDefaultAsync(m => m.EquipmentId == id);
			if (equipment == null)
			{
				return NotFound();
			}

			return View(equipment);
		}

		[Authorize(Roles = "Admin")]
		// GET: Equipments/Create
		public IActionResult Create()
		{
			ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
			ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "GenderId");
			return View();
		}

		// POST: Equipments/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("EquipmentId,Name,ShortDescription,LongDescription,Price,ImageUrl,ImageThumbnailUrl,IsPreferredEquipment,InStock,CategoryId,GenderId")] Equipment equipment)
		{
			if (ModelState.IsValid)
			{
				_context.Add(equipment);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", equipment.CategoryId);
			ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "GenderId", equipment.GenderId);
			return View(equipment);
		}
		[Authorize(Roles = "Admin")]
		// GET: Equipments/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var equipment = await _context.Equipments.FindAsync(id);
			if (equipment == null)
			{
				return NotFound();
			}
			ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", equipment.CategoryId);
			ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "GenderId", equipment.GenderId);
			return View(equipment);
		}

		// POST: Equipments/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int EquipmentId, [Bind("EquipmentId,Name,ShortDescription,LongDescription,Price,ImageUrl,ImageThumbnailUrl,IsPreferredEquipment,InStock,CategoryId,GenderId")] Equipment equipment)
		{
			if (EquipmentId != equipment.EquipmentId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(equipment);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!EquipmentExists(equipment.EquipmentId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", equipment.CategoryId);
			ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "GenderId", equipment.GenderId);
			return View(equipment);
		}
		[Authorize(Roles = "Admin")]
		// GET: Equipments/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var equipment = await _context.Equipments
				.Include(e => e.Category)
				.Include(e => e.Gender)
				.FirstOrDefaultAsync(m => m.EquipmentId == id);
			if (equipment == null)
			{
				return NotFound();
			}

			return View(equipment);
		}

		// POST: Equipments/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int EquipmentId)
		{
			var equipment = await _context.Equipments.FindAsync(EquipmentId);
			_context.Equipments.Remove(equipment);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool EquipmentExists(int id)
		{
			return _context.Equipments.Any(e => e.EquipmentId == id);
		}
	}
}