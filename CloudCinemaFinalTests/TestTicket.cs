using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudCinema;

namespace CloudCinemaTest
{
    [TestClass]
    public class TestTicket
    {
        [TestMethod]
        public void TestPrice()
        {
            Ticket t = new Ticket(21, 0, 0, Discount.Student);
            Assert.AreEqual(t.Price, 21);
        }

        [TestMethod]
        public void TestSeat()
        {
            Ticket t = new Ticket(0, 1, 2, Discount.Child);
            Assert.AreEqual(t.Seat[0], 1);
            Assert.AreEqual(t.Seat[1], 2);
        }

        [TestMethod]
        public void TestDiscount()
        {
            Ticket t = new Ticket(0, 1, 2, Discount.Child);
            Assert.AreEqual((int)t.Disc, 40);
        }

        [TestMethod]
        public void TestCalculatePriceAfterDiscount()
        {
            Ticket t = new Ticket(100, 1, 2, Discount.Child);
            Assert.AreEqual(t.CalculatePriceAfterDiscount(), 60.00);
        }
    }
}
