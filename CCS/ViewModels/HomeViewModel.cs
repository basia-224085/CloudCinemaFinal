using CCS.Models;
using System.Collections.Generic;

namespace CCS.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel(List<Show> shows)
        {
            Shows = shows;
        }
        public List<Show> Shows { get; set; }
    }
}