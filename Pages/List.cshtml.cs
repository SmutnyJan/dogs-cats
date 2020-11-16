using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
//Js123.
namespace WebApplication2.Pages
{
    [Authorize]
    public class ListModel : PageModel
    {
        private readonly WebApplication2.Data.ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;
        public string email { get; set; }
        public ListModel(WebApplication2.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Dog> Dog { get;set; }
        public IList<Cat> Cat { get; set; }

        public async Task OnGetAsync()
        {
            var AktualniUser = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            email = _userManager.Users.ToList().Where(c => AktualniUser == c.Id).FirstOrDefault().Email;
            Dog = await _context.Dogs.Where(n => n.MajitelId == AktualniUser).ToListAsync();
            Cat = await _context.Cats.Where(n => n.MajitelId == AktualniUser).ToListAsync();
        }
    }
}
