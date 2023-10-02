using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProvinceAndCities.Data;
using ProvinceAndCities.Models;

namespace ProvinceAndCities.Pages.CityPages
{
    public class DeleteModel : PageModel
    {
        private readonly ProvinceAndCities.Data.ApplicationDbContext _context;

        public DeleteModel(ProvinceAndCities.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public City City { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cities == null)
            {
                return NotFound();
            }

            var city = await _context.Cities.FirstOrDefaultAsync(m => m.CityID == id);

            if (city == null)
            {
                return NotFound();
            }
            else 
            {
                City = city;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cities == null)
            {
                return NotFound();
            }
            var city = await _context.Cities.FindAsync(id);

            if (city != null)
            {
                City = city;
                _context.Cities.Remove(City);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
