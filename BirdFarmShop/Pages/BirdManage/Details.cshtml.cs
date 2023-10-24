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
    public class DetailsModel : PageModel
    {
        private readonly IBirdRepository _birdRepository;

        public DetailsModel(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

      public Bird Bird { get; set; } = default!; 

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
            else 
            {
                Bird = bird;
            }
            return Page();
        }
    }
}
