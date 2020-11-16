using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Pages
{
    public class DeleteCatModel : PageModel
    {
        private readonly WebApplication2.Data.ApplicationDbContext _context;

        public DeleteCatModel(WebApplication2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cat Cat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cat = await _context.Cats.FirstOrDefaultAsync(m => m.Id == id);

            if (Cat == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cat = await _context.Cats.FindAsync(id);

            if (Cat != null)
            {
                _context.Cats.Remove(Cat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./List");
        }
    }
}
