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
    public class IndexModelVols : PageModel
    {
        private readonly HL.MyAirport.EF.MyAirportContext _context;

        public IndexModelVols(HL.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public IList<Vol> Vol { get;set; }

        public async Task OnGetAsync()
        {
            Vol = await _context.Vols.ToListAsync();
        }
    }
}
