using System.Collections.Generic;

namespace SD210Assignment2.Models.Domain
{
    public class Room
    {
        public int Id { get; set; }

        public string RoomNumber { get; set; }

        public virtual RoomType Type { get; set; }
        public int TypeId { get; set; }

        public decimal DailyRate { get; set; }

        public List<Reservation> Reservations { get; set; }

        public Room()
        {
            Reservations = new List<Reservation>();
        }
    }
}