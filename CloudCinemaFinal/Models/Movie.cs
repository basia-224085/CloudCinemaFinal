using System;
using System.Collections.Generic;
using System.Text;

namespace CloudCinema
{
    public class Movie
    {
        public Movie(string title, Genre genre, float pricePerSeat, int duration)
        {
            Title = title;
            Genre = genre;
            this.pricePerSeat = pricePerSeat;
            Duration = duration;
            Seats = new bool[6,8];
        }

        public string Title { get; }
        public Genre Genre { get; }
        public string trailer { get; set; }
        public float pricePerSeat { get;  }
        public string Description { get; set; }
        public int Duration { get;  }
        public bool[,] Seats { get; }
    }
}
