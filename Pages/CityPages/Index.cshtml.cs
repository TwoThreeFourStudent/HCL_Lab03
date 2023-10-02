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
    public class IndexModel : PageModel
    {
        private readonly ProvinceAndCities.Data.ApplicationDbContext _context;

        public IndexModel(ProvinceAndCities.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<City> City { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cities != null)
            {
                City = await _context.Cities
                .Include(c => c.Province).ToListAsync();
            }
        }
    }
}
