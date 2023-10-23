using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories.IRepository;
using BusinessObjects.DTOs;

namespace BirdFarmShop.Pages.BirdManage
{
    public class CreateModel : PageModel
    {
        private readonly IBirdRepository _birdRepository;

        public CreateModel(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }
       

        [BindProperty]
        public Bird Bird { get; set; } = default!;

        public int userId;
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            userId = (int)HttpContext.Session.GetInt32("UserID")!;
            var bird = new Bird()
            {
                BirdName = Bird.BirdName,
                UserId = userId,
                Estimation = Bird.Estimation,
                Gender = Bird.Gender,
                WeightofBirds = Bird.WeightofBirds,
                BirdDescription = Bird.BirdDescription,
                BirdStatus = Bird.BirdStatus,
            };
            _birdRepository.AddNewBird(bird);

            return RedirectToPage("./Index");




        }
    }
}
