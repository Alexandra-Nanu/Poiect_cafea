using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Poiect_cafea.Data;
using Poiect_cafea.Models;

namespace Poiect_cafea.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly Poiect_cafea.Data.Poiect_cafeaContext _context;

        public DetailsModel(Poiect_cafea.Data.Poiect_cafeaContext context)
        {
            _context = context;
        }

        public Client Client { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FirstOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                Client = client;
            }
            return Page();
        }
    }
}
