
namespace CCS.Models
{
    public class Show
    {
        public Show(int schedule_id, int movie_date, string movie_hour, string parking_zone, int capacity, int reserved_spots, string genre, string title, string trailer, decimal price_per_spot, string description)
        {
            Schedule_id = schedule_id;
            Movie_date = movie_date;
            Movie_hour = movie_hour;
            Parking_zone = parking_zone;
            Capacity = capacity;
            Reserved_spots = reserved_spots;
            Genre = genre;
            Title = title;
            Trailer = trailer;
            Price_per_spot = price_per_spot;
            Description = description;
        }

        public int Schedule_id { get; set; }
        public int Movie_date { get; set; }
        public string Movie_hour { get; set; }
        public string Parking_zone { get; set; }
        public int Capacity { get; set; }
        public int Reserved_spots { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public string Trailer { get; set; }
        public decimal Price_per_spot { get; set; }
        public string Description { get; set; }

    }
}