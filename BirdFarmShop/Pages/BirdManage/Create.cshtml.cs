using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;

namespace BirdFarmShop.Pages.BirdManage
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObjects.Models.BirdFarmShopContext _context;

        public CreateModel(BusinessObjects.Models.BirdFarmShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "Email");
            return Page();
        }

        [BindProperty]
        public Bird Bird { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Birds == null || Bird == null)
            {
                return Page();
            }

            _context.Birds.Add(Bird);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
