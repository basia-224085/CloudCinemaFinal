using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.Models
{
    public class Movie
    {
        public Movie(string title, string genre, float pricePerSeat, int duration)
        {
            Title = title;
            Genre = genre;
            this.pricePerSeat = pricePerSeat;
            Duration = duration;
            Seats = new bool[6,8];
        }

        public string Title { get; }
        public string Genre { get; }
        public string trailer { get; set; }
        public float pricePerSeat { get;  }
        public string Description { get; set; }
        public int Duration { get;  }
        public bool[,] Seats { get; }
    }
}
