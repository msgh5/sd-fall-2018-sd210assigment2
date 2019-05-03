using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SD210Assignment2.Models.Domain
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual List<Reservation> Reservations { get; set; }

        public Customer()
        {
            Reservations = new List<Reservation>();
        }
    }
}