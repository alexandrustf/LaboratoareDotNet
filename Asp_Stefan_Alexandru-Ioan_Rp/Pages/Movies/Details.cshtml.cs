using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asp_Stefan_Alexandru_Ioan_Rp.Data;
using Asp_Stefan_Alexandru_Ioan_Rp.Models;

namespace Asp_Stefan_Alexandru_Ioan_Rp.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly Asp_Stefan_Alexandru_Ioan_Rp.Data.MoviesContext _context;

        public DetailsModel(Asp_Stefan_Alexandru_Ioan_Rp.Data.MoviesContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
