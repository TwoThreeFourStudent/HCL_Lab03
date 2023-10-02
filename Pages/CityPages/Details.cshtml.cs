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
public class DetailsModel : PageModel
    {
        private readonly ProvinceAndCities.Data.ApplicationDbContext _context;

        public DetailsModel(ProvinceAndCities.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public City City { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City = await _context.Cities
                .Include(c => c.Province) // Include the Province property
                .FirstOrDefaultAsync(m => m.CityID == id);

            if (City == null)
            {
                return NotFound();
            }

            return Page();
        }

    }
}
