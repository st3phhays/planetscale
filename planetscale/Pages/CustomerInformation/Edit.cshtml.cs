using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Planetscale.Data;
using planetscale.Modals;

namespace planetscale.Pages.CustomerInformation
{
    public class EditModel : PageModel
    {
        private readonly Planetscale.Data.PlanetscaleContext _context;

        public EditModel(Planetscale.Data.PlanetscaleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerInformationModal CustomerInformation { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomerInformation = await _context.CustomerInformation.FirstOrDefaultAsync(m => m.Id == id);

            if (CustomerInformation == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CustomerInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerInformationModalExists(CustomerInformation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerInformationModalExists(long id)
        {
            return _context.CustomerInformation.Any(e => e.Id == id);
        }
    }
}
