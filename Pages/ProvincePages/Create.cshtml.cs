using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProvinceAndCities.Data;
using ProvinceAndCities.Models;

namespace ProvinceAndCities.Pages.ProvincePages
{
    public class CreateModel : PageModel
    {
        private readonly ProvinceAndCities.Data.ApplicationDbContext _context;

        public CreateModel(ProvinceAndCities.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Province Province { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Provinces == null || Province == null)
            {
                return Page();
            }

            _context.Provinces.Add(Province);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
