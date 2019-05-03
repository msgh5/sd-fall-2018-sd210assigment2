using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SD210Assignment2.Models.Domain
{
    public class Reservation
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public virtual Room Room { get; set; }
        public int RoomId { get; set; }

        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public decimal Total { get; set; }
    }
}