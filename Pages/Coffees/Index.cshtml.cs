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
        public string NameSort { get; set; }
        public string OriginSort { get; set; }
        public string ProducerSort { get; set; }
        public string CurrentFilter { get; set; }


        public async Task OnGetAsync(int? id, int? blendID, string sortOrder, string searchString)
        {
            CoffeeD = new CoffeeData();

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            OriginSort = sortOrder == "origin" ? "origin_desc" : "origin";
            ProducerSort = sortOrder == "producer" ? "producer_desc" : "producer";

            CurrentFilter = searchString;


            CoffeeD.Coffees = await _context.Coffee
                  .Include(c => c.Producer)
                  .Include(c => c.Origin)
                  .Include(c => c.CoffeeBlends)
                    .ThenInclude(c => c.Blend)
                  .AsNoTracking()
                  .OrderBy(c => c.Name)
                  .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                CoffeeD.Coffees = CoffeeD.Coffees.Where(s => s.Origin.OriginName.Contains(searchString)
                                                         || s.Producer.ProducerName.Contains(searchString)
                                                         || s.Name.Contains(searchString));
            }                               
            
            if (id != null)
            {
                CoffeeID = id.Value;
                Coffee coffee = CoffeeD.Coffees
                    .Where(i => i.ID == id.Value).Single();
                CoffeeD.Blends = coffee.CoffeeBlends.Select(s => s.Blend);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    CoffeeD.Coffees = CoffeeD.Coffees.OrderByDescending(s => s.Name);
                    break;
                case "origin_desc":
                    CoffeeD.Coffees = CoffeeD.Coffees.OrderByDescending(s => s.Origin.OriginName);
                    break;
                case "producer_desc":
                    CoffeeD.Coffees = CoffeeD.Coffees.OrderByDescending(s => s.Producer.ProducerName);
                    break;
                case "origin":
                    CoffeeD.Coffees = CoffeeD.Coffees.OrderBy(s => s.Origin.OriginName);
                    break;
                case "producer":
                    CoffeeD.Coffees = CoffeeD.Coffees.OrderBy(s => s.Producer.ProducerName);
                    break;
                default:
                    CoffeeD.Coffees = CoffeeD.Coffees.OrderBy(s => s.Name);
                    break;

            }
        }
    }
}
