using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using planetscale.Modals;
using Microsoft.EntityFrameworkCore;
using System.Threading;
namespace Planetscale.Data
{
    public class PlanetscaleContext : DbContext
    {
        public PlanetscaleContext(DbContextOptions<PlanetscaleContext> options) : base(options)
        {
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL();
        }*/

        public DbSet<CustomerInformationModal> CustomerInformation { get; set; }
    }
}
