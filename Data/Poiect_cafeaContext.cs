using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Poiect_cafea.Models;

namespace Poiect_cafea.Data
{
    public class Poiect_cafeaContext : DbContext
    {
        public Poiect_cafeaContext (DbContextOptions<Poiect_cafeaContext> options)
            : base(options)
        {
        }

        public DbSet<Poiect_cafea.Models.Coffee> Coffee { get; set; } = default!;
        public DbSet<Poiect_cafea.Models.Producer> Producer { get; set; } = default!;
        public DbSet<Poiect_cafea.Models.Origin> Origin { get; set; } = default!;
        public DbSet<Poiect_cafea.Models.Blend> Blend { get; set; } = default!;
    }
}
