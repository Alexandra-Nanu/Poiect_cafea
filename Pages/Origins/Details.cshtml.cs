using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Poiect_cafea.Data;
using Poiect_cafea.Models;

namespace Poiect_cafea.Pages.Origins
{
    public class DetailsModel : PageModel
    {
        private readonly Poiect_cafea.Data.Poiect_cafeaContext _context;

        public DetailsModel(Poiect_cafea.Data.Poiect_cafeaContext context)
        {
            _context = context;
        }

        public Origin Origin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var origin = await _context.Origin.FirstOrDefaultAsync(m => m.ID == id);
            if (origin == null)
            {
                return NotFound();
            }
            else
            {
                Origin = origin;
            }
            return Page();
        }
    }
}
