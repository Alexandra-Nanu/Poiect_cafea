using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Poiect_cafea.Data;
using Poiect_cafea.Models;
using Poiect_cafea.Models.ViewModels;

namespace Poiect_cafea.Pages.Producers
{
    public class IndexModel : PageModel
    {
        private readonly Poiect_cafea.Data.Poiect_cafeaContext _context;

        public IndexModel(Poiect_cafea.Data.Poiect_cafeaContext context)
        {
            _context = context;
        }

        public IList<Producer> Producer { get; set; } = default!;
        public ProducerIndexData ProducerData { get; set; }
        public int ProducerID { get; set; }
        public int CoffeeID { get; set; }

        public async Task OnGetAsync(int? id, int? coffeeID)
        {
            ProducerData = new ProducerIndexData();
            ProducerData.Producers = await _context.Producer
                .Include(i => i.Coffees)
                    .ThenInclude(b => b.Origin)
                .OrderBy(i => i.ProducerName)
                .ToListAsync();

            if (id != null)
            {
                ProducerID = id.Value;
                Producer producer = ProducerData.Producers
                    .Where(i => i.ID == id.Value).Single();
                ProducerData.Coffees = producer.Coffees;
            }

        }
    }
}
