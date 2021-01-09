using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCS.Models
{
    public class ReservationRecord
    {
        public ReservationRecord(int reservation_id, string id, int movie_date, string movie_hour, string parking_zone, string title)
        {
            Reservation_id = reservation_id;
            Id = id;
            Movie_date = movie_date;
            Movie_hour = movie_hour;
            Parking_zone = parking_zone;
            Title = title;
        }

        public int Reservation_id { get; set; }
        public string Id { get; set; }
        public int Movie_date { get; set; }
        public string Movie_hour { get; set; }
        public string Parking_zone { get; set; }
        public string Title { get; set; }

    }
}