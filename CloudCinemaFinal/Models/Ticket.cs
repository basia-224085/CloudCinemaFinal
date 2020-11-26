using System;
using System.Collections.Generic;
using System.Text;



namespace CloudCinema
{
    public class Ticket
    {
        public Ticket(float price, int row, int col, Discount discount)
        {
            Price = price;
            Seat = new int[2];
            Seat[0] = row;
            Seat[1] = col;
            Disc = discount;
        }

        public float Price { get; }
        public int[] Seat { get; }
        public Discount Disc{ get; }

        public float CalculatePriceAfterDiscount()
        {
            return (float)Math.Round(Price * ((float)(100 - (int)Disc) / 100), 2);
        }
    }
}
