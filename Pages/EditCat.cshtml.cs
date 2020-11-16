using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ViewModels;
//druhý způsob... první je u psa
namespace WebApplication2.Pages
{
    public class EditSpecialModel : PageModel
    {
        private readonly WebApplication2.Data.ApplicationDbContext _context;

        public EditSpecialModel(WebApplication2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CatIM CatIM { get; set; }
        public Cat cat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            cat = await _context.Cats.FirstOrDefaultAsync(m => m.Id == id);
            CatIM = new CatIM
            {
                Id = cat.Id,
                Vek = cat.Vek,
                Jmeno = cat.Jmeno,
                Kocour = cat.Kocour
            };

            if (cat == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            cat = new Cat
            {
                Id = CatIM.Id,
                Kocour = CatIM.Kocour,
                Jmeno = CatIM.Jmeno,
                Vek = CatIM.Vek,
                MajitelId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value
            };
            _context.Attach(cat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatIMExists(CatIM.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./List");
        }

        private bool CatIMExists(int id)
        {
            return _context.CatIM.Any(e => e.Id == id);
        }
    }
}
