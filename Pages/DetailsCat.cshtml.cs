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
    public class DetailsCatModel : PageModel
    {
        private readonly WebApplication2.Data.ApplicationDbContext _context;

        public DetailsCatModel(WebApplication2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Cat Cats { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cats = await _context.Cats.FirstOrDefaultAsync(m => m.Id == id);

            if (Cats == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
