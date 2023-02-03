using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProvinceCity.Data;

namespace ProvinceCity.Pages.CityPages
{
    public class DetailsModel : PageModel
    {
        private readonly ProvinceCity.Data.ApplicationDbContext _context;

        public DetailsModel(ProvinceCity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public City City { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cities == null)
            {
                return NotFound();
            }

            var city = await _context.Cities.FirstOrDefaultAsync(m => m.CityId == id);
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
    }
}
