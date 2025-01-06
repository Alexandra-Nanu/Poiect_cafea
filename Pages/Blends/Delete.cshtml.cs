using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Poiect_cafea.Data;
using Poiect_cafea.Models;

namespace Poiect_cafea.Pages.Blends
{
    public class DeleteModel : PageModel
    {
        private readonly Poiect_cafea.Data.Poiect_cafeaContext _context;

        public DeleteModel(Poiect_cafea.Data.Poiect_cafeaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Blend Blend { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blend = await _context.Blend.FirstOrDefaultAsync(m => m.ID == id);

            if (blend == null)
            {
                return NotFound();
            }
            else
            {
                Blend = blend;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blend = await _context.Blend.FindAsync(id);
            if (blend != null)
            {
                Blend = blend;
                _context.Blend.Remove(Blend);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
