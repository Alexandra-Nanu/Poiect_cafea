using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Poiect_cafea.Data;
using Poiect_cafea.Models;
using Poiect_cafea.Models.ViewModels;

namespace Poiect_cafea.Pages.Blends
{
    public class IndexModel : PageModel
    {
        private readonly Poiect_cafea.Data.Poiect_cafeaContext _context;

        public IndexModel(Poiect_cafea.Data.Poiect_cafeaContext context)
        {
            _context = context;
        }

        public IList<Blend> Blend { get;set; } = default!;
        public BlendIndexData BlendData { get; set; }
        public int BlendID { get; set; }
        public int CoffeeID { get; set; }

        public async Task OnGetAsync(int? id, int? coffeeID)
        {
            BlendData = new BlendIndexData();
            BlendData.Blends = await _context.Blend
                .Include(b => b.CoffeeBlends)
                    .ThenInclude(cb => cb.Coffee)
                        .ThenInclude(c => c.Origin)
                .OrderBy(B => B.BlendName)
                .ToListAsync();

            if (id != null)
            {
                BlendID = id.Value;
                Blend blend = BlendData.Blends
                    .Where(i => i.ID == id.Value).Single();
                BlendData.Coffees = blend.CoffeeBlends
                    .Select(cb => cb.Coffee)
                    .ToList();
            }
        }
    }
}  

