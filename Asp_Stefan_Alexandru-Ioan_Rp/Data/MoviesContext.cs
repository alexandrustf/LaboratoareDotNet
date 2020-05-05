using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Asp_Stefan_Alexandru_Ioan_Rp.Models;

namespace Asp_Stefan_Alexandru_Ioan_Rp.Data
{
    public class MoviesContext : DbContext
    {
        public MoviesContext (DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public DbSet<Asp_Stefan_Alexandru_Ioan_Rp.Models.Movie> Movie { get; set; }
    }
}
