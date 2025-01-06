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
    public class IndexModel : PageModel
    {
        private readonly Poiect_cafea.Data.Poiect_cafeaContext _context;

        public IndexModel(Poiect_cafea.Data.Poiect_cafeaContext context)
        {
            _context = context;
        }

        public IList<Coffee> Coffee { get; set; } = default!;
        public CoffeeData CoffeeD { get; set; }
        public int CoffeeID { get; set; }
        public int BlendID { get; set; }


        public async Task OnGetAsync(int? id, int? blendID)
        {
            CoffeeD = new CoffeeData();

            CoffeeD.Coffees = await _context.Coffee
                  .Include(c => c.Producer)
                  .Include(c => c.Origin)
                  .Include(c => c.CoffeeBlends)
                    .ThenInclude(c => c.Blend)
                  .AsNoTracking()
                  .OrderBy(c => c.Name)
                  .ToListAsync();

            if (id != null)
            {
                CoffeeID = id.Value;
                Coffee coffee = CoffeeD.Coffees
                    .Where(i => i.ID == id.Value).Single();
                CoffeeD.Blends = coffee.CoffeeBlends.Select(s => s.Blend);
            }

        }
    }
}
