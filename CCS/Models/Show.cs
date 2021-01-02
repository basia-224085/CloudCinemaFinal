
namespace CCS.Models
{
    public class Show
    {
        public Show(int schedule_id, int movie_date, string movie_hour, string parking_zone, int capacity, int reserved_spots, string genre, string title, string trailer, decimal price_per_spot, string description)
        {
            /*"{"Schedule_id":12,
             * "Movie_date":1,
             * "Movie_hour":"20:00",
             * "Parking_zone":"A",
             * "Capacity":50,
             * "Reserved_spots":5,
             * "Genre":"drama",
             * "Title":"Intouchables",
             * "Trailer":"https://www.youtube.com/embed/34WIbmXkewU",
             * "Price_per_spot":20,
             * "Description":"After he becomes a quadriplegic from a paragliding accident,
             * an aristocrat hires a young man from the projects to be his caregiver."}" */
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
        public Show()
        {

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