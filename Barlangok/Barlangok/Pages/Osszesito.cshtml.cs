using Microsoft.AspNetCore.Mvc.RazorPages;
using Barlangok.Data;
using Barlangok.Models;
using System.Collections.Generic;
using System.Linq;

namespace Barlangok.Pages
{
    public class OsszesitoModel : PageModel
    {
        private readonly BarlangokContext _context;

        public List<BarlangOsszesitesDTO> Osszesites { get; set; }

        public OsszesitoModel(BarlangokContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Osszesites = _context.Barlang
                .GroupBy(b => b.Telepules)
                .Select(g => new BarlangOsszesitesDTO
                {
                    Varos = g.Key,
                    BarlangCount = g.Count()
                })
                .OrderBy(x => x.Varos)
                .ToList();
        }
    }
}
