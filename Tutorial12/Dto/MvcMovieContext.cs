using Microsoft.EntityFrameworkCore;
using Tutorial12.Models;

namespace Tutorial12.Dto
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options) : base(options)
        {
            
        }
        
        public DbSet<Movie> Movie { get; set; }
    }
}