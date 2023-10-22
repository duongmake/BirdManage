using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace BirdFarmShop.Pages.BirdManage
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObjects.Models.BirdFarmShopContext _context;

        public IndexModel(BusinessObjects.Models.BirdFarmShopContext context)
        {
            _context = context;
        }

        public IList<Bird> Bird { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Birds != null)
            {
                Bird = await _context.Birds
                .Include(b => b.User).ToListAsync();
            }
        }
    }
}
