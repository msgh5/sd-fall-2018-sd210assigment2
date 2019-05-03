using SD210Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SD210Assignment2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dbContext = new ApplicationDbContext();

            var currentDate = DateTime.Now;
            var checkIn = new DateTime(2019, 05, 9);
            var checkOut = new DateTime(2019, 05, 14);
            var days = Convert.ToDecimal(checkOut.Subtract(checkIn).TotalDays);

            var query1 = dbContext
                .Rooms
                .Where(p => p.Reservations.All(t => t.CheckOut < checkIn
                || t.CheckIn > checkOut))
                .Select(p => new
                {
                    RoomNumber = p.RoomNumber,
                    RoomType = p.Type.Name,
                    TotalPrice = p.DailyRate * days
                }).ToList();

            var query2 = dbContext
                .Reservations
                .Where(p => p.CheckOut > currentDate)
                .Select(p => new
                {
                    Code = p.Code,
                    RoomNumber = p.Room.RoomNumber,
                    RoomType = p.Room.Type.Name,
                    CheckInt = p.CheckIn,
                    Checkout = p.CheckOut,
                    TotalPrice = p.Total,
                    CustomerFirstName = p.Customer.FirstName,
                    CustomerLastName = p.Customer.LastName,
                    CustomerPhoneNumber = p.Customer.PhoneNumber
                }).ToList();

            var date = DateTime.Now.Date;

            var query3 = dbContext
                .Rooms
                .Select(p => new
                {
                    RoomNumber = p.RoomNumber,
                    RoomType = p.Type.Name,
                    //Total = p.Reservations.Any() ? p.Reservations.Sum(t => t.Total) : 0
                    Total = p.Reservations.Where(y => y.CheckIn < currentDate).Sum(t => (decimal?)t.Total) ?? 0
                })
                .ToList();


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}