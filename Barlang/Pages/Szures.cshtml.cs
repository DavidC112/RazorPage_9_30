using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Barlang.Data;
using Barlang.Models;

namespace Barlang.Pages
{
    public class SzuresModel : PageModel
    {
        private readonly Barlang.Data.BarlangDbContext _context;

        public SzuresModel(Barlang.Data.BarlangDbContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string KivalasztottBarlang { get; set; }

        public IList<Models.Barlang> Barlang { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Barlang = await _context.Barlangok.Where(x => x.Telepules == KivalasztottBarlang).ToListAsync();
        }
    }
}
