using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Poiect_cafea.Data;
using Poiect_cafea.Models;

namespace Poiect_cafea.Pages.Coffees
{
    public class CreateModel : CoffeeBlendsPageModel
    {
        private readonly Poiect_cafea.Data.Poiect_cafeaContext _context;

        public CreateModel(Poiect_cafea.Data.Poiect_cafeaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //ViewData["OriginID"] = new SelectList(_context.Set<Origin>(), "ID", "OriginName");
            //ViewData["ProducerID"] = new SelectList(_context.Set<Producer>(), "ID", "ProducerName");

            ViewData["OriginID"] = new SelectList(_context.Origin, "ID", "OriginName");
            ViewData["ProducerID"] = new SelectList(_context.Producer, "ID", "ProducerName");

            var coffee = new Coffee();
            coffee.CoffeeBlends = new List<CoffeeBlend>();

            PopulateAssignedBlendData(_context, coffee);

            return Page();
        }

        [BindProperty]
        public Coffee Coffee { get; set; } = default!;


        /* public async Task<IActionResult> OnPostAsync()
         {
             if (!ModelState.IsValid)
             {
                 return Page();
             }

             _context.Coffee.Add(Coffee);
             await _context.SaveChangesAsync();

             return RedirectToPage("./Index");
         }*/
        public async Task<IActionResult> OnPostAsync(string[] selectedBlends)
        {
            var newCoffee = new Coffee();
            if (selectedBlends != null)
            {
                newCoffee.CoffeeBlends = new List<CoffeeBlend>();
                foreach (var ble in selectedBlends)
                {
                    var bleToAdd = new CoffeeBlend
                    {
                        BlendID = int.Parse(ble)
                    };
                    newCoffee.CoffeeBlends.Add(bleToAdd);
                }
            }

            Coffee.CoffeeBlends = newCoffee.CoffeeBlends;
            _context.Coffee.Add(Coffee);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
