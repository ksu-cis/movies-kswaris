﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {

        public MovieDatabase MovieDatabase = new MovieDatabase();
        public MovieDatabase()
        {
            if(MovieDatabase == null)
            {
                using (StreamReader file = System.IO.File.OpenText("movies.json"))
                {
                    string json = file.ReadToEnd();
                    MovieDatabase = JsonConvert.DeserializeObject<List<Movie>>(json);
                }
            }
        }
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
            if(minIMDB is float min)
            {
                Movies = MovieDatabse.FilterByMinIMDB(Movies, minIMDB)
            }
            Movies = MovieDatabase.Search(search);

        }
    }
}
