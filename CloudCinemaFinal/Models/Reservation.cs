using System;
using System.Collections.Generic;
using System.Text;

namespace CloudCinema
{
    public class Reservation
    {
        public Reservation(Movie movie, User user)
        {
            this.Movie = movie;
            this.User = user;
            Tickets = new List<Ticket>();
        }

        public Movie Movie { get;  }
        public User User { get; }
        public List<Ticket> Tickets { get; }
        public float TotalPrice { get; }

        public bool AddTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
            Movie.Seats[ticket.Seat[0], ticket.Seat[1]] = true;
            return Tickets.Contains(ticket);
        }
    }
}
