using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories.IRepository;

namespace BirdFarmShop.Pages.BirdManage
{
    public class DeleteModel : PageModel
    {
        private readonly IBirdRepository _birdRepository;

        public DeleteModel(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        [BindProperty]
      public Bird Bird { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null || _birdRepository.GetAllBird == null)
            {
                return NotFound();
            }

            Bird = _birdRepository.GetBirdById(id.Value);

            if (Bird == null)
            {
                return NotFound();
            }
            
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            
           var bird = _birdRepository.GetBirdById(id.Value);

            if (bird != null)
            {
                _birdRepository.DeleteBird(bird.BirdId);
            }

            return RedirectToPage("./Index");
        }
    }
}
