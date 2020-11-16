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
//jeden způsob... druhý je u kočky
namespace WebApplication2.Pages
{
    public class EditModel : PageModel
    {
        private readonly WebApplication2.Data.ApplicationDbContext _context;

        public EditModel(WebApplication2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dog Dog { get; set; }
        public string majitelId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            majitelId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            if (id == null)
            {
                return NotFound();
            }

            Dog = await _context.Dogs
                .Include(d => d.Majitel).FirstOrDefaultAsync(m => m.Id == id);

            if (Dog == null)
            {
                return NotFound();
            }
           ViewData["MajitelId"] = new SelectList(_context.Users, "Id", "Id");
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

            _context.Attach(Dog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogExists(Dog.Id))
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

        private bool DogExists(int id)
        {
            return _context.Dogs.Any(e => e.Id == id);
        }
    }
}
