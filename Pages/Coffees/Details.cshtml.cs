using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Poiect_cafea.Data;
using Poiect_cafea.Models;

namespace Poiect_cafea.Pages.Coffees
{
    public class DetailsModel : PageModel
    {
        private readonly Poiect_cafea.Data.Poiect_cafeaContext _context;

        public DetailsModel(Poiect_cafea.Data.Poiect_cafeaContext context)
        {
            _context = context;
        }

        public Coffee Coffee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffee.FirstOrDefaultAsync(m => m.ID == id);
            if (coffee == null)
            {
                return NotFound();
            }
            else
            {
                Coffee = coffee;
            }
            return Page();
        }
    }
}
