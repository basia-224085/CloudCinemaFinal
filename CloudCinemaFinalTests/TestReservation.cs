using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudCinema;

namespace CloudCinemaTest
{
    [TestClass]
    public class TestReservation
    {
        [TestMethod]
        public void TestAddTicket()
        {
            Movie movie = new Movie("Name", Genre.Action, 25, 120000);
            Reservation reservation = new Reservation(movie, null);
            Ticket t = new Ticket(movie.pricePerSeat, 0, 0, Discount.Child);

            Assert.AreEqual(reservation.AddTicket(t), true);
            Assert.AreEqual(movie.Seats[0, 0], true);
            Assert.AreEqual(movie.Seats[0, 1], false);
        }
    }
}
