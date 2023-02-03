using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProvinceCity.Data;

namespace ProvinceCity.Pages.ProvincePages
{
    public class IndexModel : PageModel
    {
        private readonly ProvinceCity.Data.ApplicationDbContext _context;

        public IndexModel(ProvinceCity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Province> Province { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Provinces != null)
            {
                Province = await _context.Provinces.ToListAsync();
            }
        }
    }
}
