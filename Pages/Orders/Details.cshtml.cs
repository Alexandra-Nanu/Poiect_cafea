using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Poiect_cafea.Data;
using Poiect_cafea.Models;

namespace Poiect_cafea.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly Poiect_cafea.Data.Poiect_cafeaContext _context;

        public DetailsModel(Poiect_cafea.Data.Poiect_cafeaContext context)
        {
            _context = context;
        }

        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                Order = order;
            }
            return Page();
        }
    }
}
