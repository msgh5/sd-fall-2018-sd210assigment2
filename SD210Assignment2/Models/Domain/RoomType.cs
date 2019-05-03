using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SD210Assignment2.Models.Domain
{
    public class RoomType
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Room> Rooms { get; set; }

        public RoomType()
        {
            Rooms = new List<Room>();
        }
    }
}