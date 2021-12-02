using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Planetscale.Data;
using planetscale.Modals;

namespace planetscale.Pages.CustomerInformation
{
    public class CreateModel : PageModel
    {
        private readonly Planetscale.Data.PlanetscaleContext _context;

        public CreateModel(Planetscale.Data.PlanetscaleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CustomerInformationModal CustomerInformation { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CustomerInformation.Add(CustomerInformation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
