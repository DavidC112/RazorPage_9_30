using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Barlang.Data;
using Barlang.Models;

namespace Barlang.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Barlang.Data.BarlangDbContext _context;

        public CreateModel(Barlang.Data.BarlangDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Barlang Barlang { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Barlangok.Add(Barlang);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
