using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Barlang.Data;
using Barlang.Models;

namespace Barlang.Pages
{
    public class EditModel : PageModel
    {
        private readonly Barlang.Data.BarlangDbContext _context;

        public EditModel(Barlang.Data.BarlangDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Barlang Barlang { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barlang =  await _context.Barlangok.FirstOrDefaultAsync(m => m.Id == id);
            if (barlang == null)
            {
                return NotFound();
            }
            Barlang = barlang;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Barlang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarlangExists(Barlang.Id))
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

        private bool BarlangExists(int id)
        {
            return _context.Barlangok.Any(e => e.Id == id);
        }
    }
}
