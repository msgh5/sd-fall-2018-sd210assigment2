namespace SD210Assignment2.Migrations
{
    using SD210Assignment2.Models.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SD210Assignment2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SD210Assignment2.Models.ApplicationDbContext context)
        {
            context.RoomTypes.AddOrUpdate(p => p.Name,
                new RoomType { Name = "Single", Description = "A room assigned to one person. May have one or more beds." },
                new RoomType { Name = "Double", Description = "A room assigned to two people. May have one or more beds." },
                new RoomType { Name = "Queen", Description = "A room with a queen-sized bed. May be occupied by one or more people." },
                new RoomType { Name = "King", Description = "A room with a king-sized bed. May be occupied by one or more people." },
                new RoomType { Name = "Master suite", Description = "A parlour or living room connected to one or more bedrooms." });

            context.SaveChanges();

            context.Rooms.AddOrUpdate(p => p.RoomNumber,
                new Room { RoomNumber = "1A", Type = context.RoomTypes.First(p => p.Name == "Single"), DailyRate = 50},
                new Room { RoomNumber = "1B", Type = context.RoomTypes.First(p => p.Name == "Single"), DailyRate = 50},
                new Room { RoomNumber = "2A", Type = context.RoomTypes.First(p => p.Name == "Double"), DailyRate = 90},
                new Room { RoomNumber = "2B", Type = context.RoomTypes.First(p => p.Name == "Double"), DailyRate = 90},
                new Room { RoomNumber = "3A", Type = context.RoomTypes.First(p => p.Name == "Queen"), DailyRate = 130},
                new Room { RoomNumber = "3B", Type = context.RoomTypes.First(p => p.Name == "Queen"), DailyRate = 130},
                new Room { RoomNumber = "3C", Type = context.RoomTypes.First(p => p.Name == "Queen"), DailyRate = 130},
                new Room { RoomNumber = "4A", Type = context.RoomTypes.First(p => p.Name == "King"), DailyRate = 200},
                new Room { RoomNumber = "4B", Type = context.RoomTypes.First(p => p.Name == "King"), DailyRate = 200},
                new Room { RoomNumber = "5A", Type = context.RoomTypes.First(p => p.Name == "Master suite"), DailyRate = 250});

            context.SaveChanges();

            context.Customers.AddOrUpdate(p => p.Email,
                new Customer { FirstName = "Alan", LastName = "Foster", Email = "alanfoster@assignment2.com", PhoneNumber = "(204) – 111-1111" },
                new Customer { FirstName = "Harley", LastName = "Moore", Email = "harleymoore@assignment2.com", PhoneNumber = "(204) – 222-2222" },
                new Customer { FirstName = "Kara", LastName = "Rogers", Email = "kararogers@assignment2.com", PhoneNumber = "(204) – 333-3333" },
                new Customer { FirstName = "Lara", LastName = "Mason", Email = "laramason@assignment2.com", PhoneNumber = "(204) – 444-4444" },
                new Customer { FirstName = "Amber", LastName = "Hunt", Email = "amberhunt@assignment2.com", PhoneNumber = "(204) – 555-5555" });

            context.SaveChanges();

            context.Reservations.AddOrUpdate(p => p.Code,
                new Reservation { Code = "PMJYW5WH2", Room = context.Rooms.First(p => p.RoomNumber == "1A"), Customer = context.Customers.First(p => p.Email == "alanfoster@assignment2.com"), CheckIn = new DateTime(2019, 04, 8), CheckOut = new DateTime(2019, 04, 12), Total = 250 },
                new Reservation { Code = "Y1SNW2YQ3", Room = context.Rooms.First(p => p.RoomNumber == "1B"), Customer = context.Customers.First(p => p.Email == "harleymoore@assignment2.com"), CheckIn = new DateTime(2019, 04, 15), CheckOut = new DateTime(2019, 04, 19), Total = 250 },
                new Reservation { Code = "ICKU0JMMN", Room = context.Rooms.First(p => p.RoomNumber == "1A"), Customer = context.Customers.First(p => p.Email == "alanfoster@assignment2.com"), CheckIn = new DateTime(2019, 04, 22), CheckOut = new DateTime(2019, 04, 24), Total = 150 },
                new Reservation { Code = "EW4X1NWEU", Room = context.Rooms.First(p => p.RoomNumber == "3A"), Customer = context.Customers.First(p => p.Email == "kararogers@assignment2.com"), CheckIn = new DateTime(2019, 05, 1), CheckOut = new DateTime(2019, 05, 10), Total = 1300 },
                new Reservation { Code = "7XLLBVZYB", Room = context.Rooms.First(p => p.RoomNumber == "4B"), Customer = context.Customers.First(p => p.Email == "amberhunt@assignment2.com"), CheckIn = new DateTime(2019, 05, 6), CheckOut = new DateTime(2019, 05, 10), Total = 1000 },
                new Reservation { Code = "WD4EFAINV", Room = context.Rooms.First(p => p.RoomNumber == "4B"), Customer = context.Customers.First(p => p.Email == "laramason@assignment2.com"), CheckIn = new DateTime(2019, 05, 13), CheckOut = new DateTime(2019, 05, 17), Total = 1000 },
                new Reservation { Code = "Y4Y97Q4WG", Room = context.Rooms.First(p => p.RoomNumber == "1A"), Customer = context.Customers.First(p => p.Email == "alanfoster@assignment2.com"), CheckIn = new DateTime(2019, 05, 13), CheckOut = new DateTime(2019, 05, 15), Total = 150 });

            context.SaveChanges();
        }
    }
}
