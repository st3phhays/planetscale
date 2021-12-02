using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Planetscale.Data;
using planetscale.Modals;

namespace planetscale.Pages.CustomerInformation
{
    public class IndexModel : PageModel
    {
        private readonly Planetscale.Data.PlanetscaleContext _context;

        public IndexModel(Planetscale.Data.PlanetscaleContext context)
        {
            _context = context;
        }

        public IList<CustomerInformationModal> CustomerInformation { get;set; }

        public async Task OnGetAsync()
        {
            CustomerInformation = await _context.CustomerInformation.ToListAsync();
        }
    }
}
