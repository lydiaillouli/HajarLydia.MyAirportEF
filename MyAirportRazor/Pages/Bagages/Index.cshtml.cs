using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HL.MyAirport.EF;

namespace MyAirport.Razor
{
    public class IndexModelBagages : PageModel
    {
        private readonly HL.MyAirport.EF.MyAirportContext _context;

        public IndexModelBagages(HL.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public IList<Bagage> Bagage { get;set; }

        public async Task OnGetAsync()
        {
            Bagage = await _context.Bagages.ToListAsync();
        }
    }
}
