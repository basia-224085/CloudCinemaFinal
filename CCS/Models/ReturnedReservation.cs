using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCS.Models
{
    public class ReturnedReservation
    {
        public int Returned_schedule_id { get; set; }
        public string Returned_user_email { get; set; }
        public int Returned_reserved_spots{ get; set; }
    }
}