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
    public class IndexModel : PageModel
    {
        private readonly Asp_Stefan_Alexandru_Ioan_Rp.Data.MoviesContext _context;

        public IndexModel(Asp_Stefan_Alexandru_Ioan_Rp.Data.MoviesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
