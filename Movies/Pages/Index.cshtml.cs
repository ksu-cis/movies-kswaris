using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {

        public MovieDatabase MovieDatabase = new MovieDatabase();
        public List<Movie> Movies;
        public void OnGet()
        {
            Movies = MovieDatabase.All;
        }
        public void OnPost(string search, List<string> mpaa)
        {
            if(search != null && mpaa.Count > 0)
            {
                Movies = MovieDatabase.Search(search);
                Movies = MovieDatabase.FilterByMPAA(Movies, mpaa);
            }
            else if(search != null)
            {
                Movies = MovieDatabase.Search(search);
            }
            else if(mpaa.Count > 0)
            {
                Movies = MovieDatabase.FilterByMPAA(Movies, mpaa);
            }
            else
            {
                Movies = MovieDatabase.All;
            }
            Movies = MovieDatabase.Search(search);

        }
    }
}
