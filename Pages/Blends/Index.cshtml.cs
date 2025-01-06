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
    public class IndexModel : PageModel
    {
        private readonly Poiect_cafea.Data.Poiect_cafeaContext _context;

        public IndexModel(Poiect_cafea.Data.Poiect_cafeaContext context)
        {
            _context = context;
        }

        public IList<Blend> Blend { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Blend = await _context.Blend.ToListAsync();
        }
    }
}
