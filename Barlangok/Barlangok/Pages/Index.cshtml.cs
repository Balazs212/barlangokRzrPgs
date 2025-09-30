using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Barlangok.Models;
using Barlangok.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barlangok.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BarlangokContext _context;

        public IndexModel(BarlangokContext context)
        {
            _context = context;
        }

        public IList<Barlang> Barlangok { get; set; } = new List<Barlang>();

        [BindProperty(SupportsGet = true)]
        public string TelepulesFilter { get; set; }

        public async Task OnGetAsync()
        {
            var query = _context.Barlang.AsQueryable();

            if (!string.IsNullOrWhiteSpace(TelepulesFilter))
            {
                query = query.Where(b => b.Telepules.Contains(TelepulesFilter));
            }

            Barlangok = await query.ToListAsync();
        }
    }
}
