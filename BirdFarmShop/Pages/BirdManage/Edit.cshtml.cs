using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories.IRepository;

namespace BirdFarmShop.Pages.BirdManage
{
    public class EditModel : PageModel
    {
        private readonly IBirdRepository _birdRepository;

        public EditModel(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        [BindProperty]
        public Bird Bird { get; set; } = default!;

        public int userId;

        public IActionResult OnGet(int? id)
        {
            if (id == null || _birdRepository.GetAllBird == null)
            {
                return NotFound();
            }

            var bird = _birdRepository.GetBirdById(id.Value);
            if (bird == null)
            {
                return NotFound();
            }
            Bird = bird;
           //ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost(int? id)
        {
            
            _birdRepository.UpdateBird(Bird);

            return RedirectToPage("./Index");
        }

        
    }
}
