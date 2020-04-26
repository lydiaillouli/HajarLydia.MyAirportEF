using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HL.MyAirport.EF;

namespace MyAirport.Razor
{
    public class CreateModelBagages : PageModel
    {
        private readonly HL.MyAirport.EF.MyAirportContext _context;

        public CreateModelBagages(HL.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }
        

        public IActionResult OnGet()
        {

            ViewData["VolId"] = new SelectList(_context.Set<Vol>(), "VolId", "Compagnie");
                return Page();
        }

        [BindProperty]
        public Bagage Bagage { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bagages.Add(Bagage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
