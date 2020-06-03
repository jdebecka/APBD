using Tutorial12.Models;


using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Tutorial12.Models
{
    public class MovieGenreViewModel
    {
        public List<Movie> Movies { get; set; }
        public SelectList Genres { get; set; }
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}