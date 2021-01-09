using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCS.ViewModels
{
    public class MyReservationsViewModel
    {
        public MyReservationsViewModel(List<ReservationRecord> reservations)
        {
            ReservationRecords = reservations;
        }
        public List<ReservationRecord> ReservationRecords { get; set; }
    }
}