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
    public class DeleteModel : PageModel
    {
        private readonly Poiect_cafea.Data.Poiect_cafeaContext _context;

        public DeleteModel(Poiect_cafea.Data.Poiect_cafeaContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var origin = await _context.Origin.FindAsync(id);
            if (origin != null)
            {
                Origin = origin;
                _context.Origin.Remove(Origin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
