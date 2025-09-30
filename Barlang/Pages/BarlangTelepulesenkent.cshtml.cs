using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Barlang.Data;
using Barlang.Models;
using Barlang.DTOs;

namespace Barlang.Pages
{
    public class BarlangTelepulesenkentModel : PageModel
    {
        private readonly Barlang.Data.BarlangDbContext _context;

        public BarlangTelepulesenkentModel(Barlang.Data.BarlangDbContext context)
        {
            _context = context;
        }

        public IList<DTOs.BarlangDTO> Barlang { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Barlang = await _context.Barlangok.GroupBy(b => b.Telepules)
                .Select(g => new BarlangDTO{ Telepules = g.Key, Darab = g.Count() })
                .ToListAsync();
        }
    }
}
