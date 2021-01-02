﻿using CCS.Models;
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
                           m.description
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
                           item.description));
            }
            return shows;
        }
        public void updateReservedSpots(int schedule_id, int new_reserved_spots)
        {
            Schedule schedule = db.Schedule.Where(p => p.schedule_id == schedule_id).First();
            schedule.reserved_spots = new_reserved_spots;
            db.SubmitChanges();
        }
        public string getUserIdByEmail(string user_email)
        {
            AspNetUsers user = db.AspNetUsers.Where(p => p.Email == user_email).First();
            return user.Id;
        }
        public void addReservation(int schedule_id, string user_email)
        {
            Reservations reservation = new Reservations();
            reservation.schedule_id = schedule_id;
            reservation.Id = getUserIdByEmail(user_email);
            db.Reservations.InsertOnSubmit(reservation);
            db.SubmitChanges();
        }
    }
}