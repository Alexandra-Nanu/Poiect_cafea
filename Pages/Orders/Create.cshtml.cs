using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Poiect_cafea.Data;
using Poiect_cafea.Models;

namespace Poiect_cafea.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly Poiect_cafea.Data.Poiect_cafeaContext _context;

        public CreateModel(Poiect_cafea.Data.Poiect_cafeaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var coffeeList = _context.Coffee
                .Include(c => c.Producer)
                .Include(c => c.Origin)
                .Select(x => new
                {
                    x.ID,
                    CoffeeFullName = x.Name + " - "+ x.Producer.ProducerName+ " - " + x.Origin.OriginName
                });
            ViewData["CoffeeID"] = new SelectList(coffeeList, "ID", "CoffeeFullName");
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "FullName");

            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
