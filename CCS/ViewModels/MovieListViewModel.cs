using CCS.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCS.ViewModels
{
    public class MovieListViewModel
    {
        public MovieListViewModel(List<Movies> movies)
        {
            Movies = movies;
        }

        public List<Movies> Movies { get; set; }
    }
}