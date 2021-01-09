using CCS.Models;
using System.Collections.Generic;
using System.Linq;

namespace CCS.DataRepository
{
    public class Repository
    {
        CloudDBDataContext db = new CloudDBDataContext();
        public List<Movies> getMoviesOfTheDay(int movie_date)
        {
            var list = (from s in db.Schedule where (s.movie_date == movie_date) select s.movie_id).Distinct();
            List<Movies> returnList = new List<Movies>();
            foreach (var s in list)
            {
                returnList.Add(db.Movies.Where(p => p.movie_id == s).First());
            }
            return returnList;
        }

        public List<Show> getShows()
        {
            List<Show> shows = new List<Show>();
            var data = from s in db.Schedule
                       from m in db.Movies
                       where s.movie_id == m.movie_id
                       from g in db.Genre
                       where m.genre_id == g.genre_id
                       select new
                       {
                           s.schedule_id,
                           s.movie_date,
                           s.movie_hour,
                           s.parking_zone,
                           s.capacity,
                           s.reserved_spots,
                           g.name,
                           m.title,
                           m.trailer,
                           m.price_per_spot,
                           m.description,
                           m.poster
                       };
            foreach (var item in data)
            {
                shows.Add(new Show(item.schedule_id,
                           item.movie_date,
                           item.movie_hour,
                           item.parking_zone,
                           item.capacity,
                           item.reserved_spots,
                           item.name,
                           item.title,
                           item.trailer,
                           item.price_per_spot,
                           item.description,
                           item.poster));
            }
            return shows;
        }
        public void updateReservedSpots(int schedule_id, int new_reserved_spots)
        {
            Schedule schedule = db.Schedule.Where(p => p.schedule_id == schedule_id).First();
            schedule.reserved_spots = new_reserved_spots;
            db.SubmitChanges();
        }
        public string getEmailByUserId(string user_id)
        {
            AspNetUsers user = db.AspNetUsers.Where(p => p.Id == user_id).First();
            return user.Email;
        }
        public void addReservation(int schedule_id, string user_id)
        {
            Reservations reservation = new Reservations();
            reservation.schedule_id = schedule_id;
            reservation.Id = user_id;
            db.Reservations.InsertOnSubmit(reservation);
            db.SubmitChanges();
        }

        public List<ReservationRecord> getReservations(string user_id)
        {
            List<ReservationRecord> reservations = new List<ReservationRecord>();
            var data = from r in db.Reservations
                       where r.Id == user_id
                       from s in db.Schedule
                       where r.schedule_id == s.schedule_id
                       from m in db.Movies
                       where s.movie_id == m.movie_id
                       select new
                       {
                           r.reservation_id,
                           r.Id,
                           s.movie_date,
                           s.movie_hour,
                           s.parking_zone,
                           m.title
                       };
            foreach (var item in data)
            {
                reservations.Add(new ReservationRecord(
                            item.reservation_id,
                            item.Id,
                            item.movie_date,
                            item.movie_hour,
                            item.parking_zone,
                            item.title));
            }
            return reservations;
        }
    }
}