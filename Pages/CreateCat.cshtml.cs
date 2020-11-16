using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Pages
{
    public class CreateCatModel : PageModel
    {
        private readonly WebApplication2.Data.ApplicationDbContext _context;

        public CreateCatModel(WebApplication2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CatIM Input { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var UserId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value; ;
            Cat newCat = new Cat
            {
                Kocour = Input.Kocour,
                Jmeno = Input.Jmeno,
                Vek = Input.Vek,
                MajitelId = UserId
            };
            _context.Cats.Add(newCat);

            await _context.SaveChangesAsync();

            return RedirectToPage("./List");
        }
    }
}
