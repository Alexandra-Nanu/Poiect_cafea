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

namespace Poiect_cafea.Pages.Coffees
{
    public class EditModel : CoffeeBlendsPageModel
    {
        private readonly Poiect_cafea.Data.Poiect_cafeaContext _context;

        public EditModel(Poiect_cafea.Data.Poiect_cafeaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Coffee Coffee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Coffee = await _context.Coffee
                .Include(c => c.Producer)
                .Include(c => c.Origin)
                .Include(c => c.CoffeeBlends)
                    .ThenInclude(c => c.Blend)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            //var coffee =  await _context.Coffee.FirstOrDefaultAsync(m => m.ID == id);
            if (Coffee == null)
            {
                return NotFound();
            }
            PopulateAssignedBlendData(_context, Coffee);

            // Coffee = coffee;
            //ViewData["OriginID"] = new SelectList(_context.Set<Origin>(), "ID", "OriginName");
           // ViewData["ProducerID"] = new SelectList(_context.Set<Producer>(), "ID", "ProducerName");
           ViewData["OriginID"] = new SelectList(_context.Origin, "ID", "OriginName");
           ViewData["ProducerID"] = new SelectList(_context.Producer, "ID", "ProducerName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedBlends)
        {
            /* if (!ModelState.IsValid)
             {
                 return Page();
             }

             _context.Attach(Coffee).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!CoffeeExists(Coffee.ID))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return RedirectToPage("./Index");*/
            if (id == null)
            {
                return NotFound();
            }

            var coffeeToUpdate = await _context.Coffee
                .Include(i => i.Producer)
                .Include(i => i.Origin)
                .Include(i => i.CoffeeBlends)
                    .ThenInclude(i => i.Blend)
                .FirstOrDefaultAsync(s => s.ID == id);
            if (coffeeToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Coffee>(
                coffeeToUpdate,
                "Coffee",
                i => i.Name, i => i.OriginID,
                i => i.Price, i => i.ExpirationDate, i => i.ProducerID))
            {
                UpdateCoffeeBlends(_context, selectedBlends, coffeeToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateCoffeeBlends(_context, selectedBlends, coffeeToUpdate);
            PopulateAssignedBlendData(_context, coffeeToUpdate);
            return Page();
        }
    }
}

      /*  private bool CoffeeExists(int id)
        {
            return _context.Coffee.Any(e => e.ID == id);
        }*/

