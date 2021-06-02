using DeliveryBookingSystemMVC2.Models;
using DeliveryBookingSystemMVC2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBookingSystemMVC2.Controllers
{
    public class UserController : Controller
    {
        public readonly ILogger<UserController> _logger;
        public readonly IRepo<Customer> _repo1;
        public readonly IRepo<DeliveryExecutive> _repo2;
        public readonly IBookingRepo<Booking> _repo3;
       // public readonly IRepo<Booking> _repo4;

        public UserController(ILogger<UserController> logger, IRepo<Customer> repo1, IRepo<DeliveryExecutive> repo2, IBookingRepo<Booking> repo3)
        {
            _logger = logger;
            _repo1 = repo1;
            _repo2 = repo2;
            _repo3 = repo3;
        }



        //customer
        [HttpGet]
        public IActionResult Index1()
        {
            List<Customer> customers = _repo1.GetAll().ToList();
            return View(customers);
        }
        public IActionResult Create1()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create1(Customer customer)
        {
            customer.isVerified = "null";
            _repo1.Add(customer);

            return RedirectToAction("Login1");
        }
        public ActionResult Login1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login1(Customer customer)
        {
            int id = _repo1.Login(customer);
            try
            {
                if (id!= 0)
                {
                    TempData["customerID"]=id;
                    return RedirectToAction("CustomerHome");
                }
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return RedirectToAction("Error");
        }
        //public ActionResult Details1(int )
        //{

        //}
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        public IActionResult Edit1(int id)
        {
            Customer customer = _repo1.Get(id);
            //customer.password = "1";
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit1(int id, Customer customer)
        {
           // customer.password = "1";
            _repo1.Update(id, customer);
           
            return RedirectToAction("Index1");
        }
        public IActionResult CustomerBookingList()
        {
            // int id = HttpContext.Session.GetInt32("ExecutiveId") == null ? 0 : HttpContext.Session.GetInt32("ExecutiveId").Value;
            int id = Convert.ToInt32(TempData.Peek("customerID"));

            List<Booking> booking = _repo3.GetAll().Where(a => a.customerID == id /*&& a.status=="Accepted"*/).ToList();
            if (booking.Count() != 0)
            {
                return View(booking);
            }
            else if (booking.Count() == 0)
            {
                return View("NoBookings");
            }
            return View();
        }
        public IActionResult NoBookings()
        {
            return View();
        }
        public IActionResult CustBookingEdit(int id)
        {
            Booking booking = _repo3.Get(id);
            return View(booking);
        }
        [HttpPost]
        public IActionResult CustBookingEdit(int id, Booking booking)
        {
            _repo3.Update(id, booking);
            return RedirectToAction("CustomerBookingList");
        }
        public IActionResult CustomerHome()
        {
            return View();
        }
       

        //deliveryExecutive
        [HttpGet]
        public IActionResult Index2()
        {
            List<DeliveryExecutive> executive = _repo2.GetAll().ToList();
            return View(executive);
        }
        public IActionResult ExecutiveList()
        {
            List<DeliveryExecutive> executive = _repo2.GetAll().Where(i=>i.isVerified=="yes").ToList();
            return View(executive);
        }
        public IActionResult Create2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create2(DeliveryExecutive executive)
        {
            executive.isVerified = "null";
            _repo2.Add(executive);

            return RedirectToAction("Index2");
        }
        public ActionResult Login2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login2(DeliveryExecutive executive)
        {
            int id = _repo2.Login(executive);
            try
            {
                if (id!= 0)
                {
                    TempData["executiveId"] = id;
                  //HttpContext.Session.Set("executiveID", executive.executiveID.);
                    return RedirectToAction("ExecutiveHome");
                }
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return RedirectToAction("Error");
        }
        
        public ActionResult Details2(DeliveryExecutive executive)
        {
            executive = new DeliveryExecutive();
            _repo2.Get(executive.executiveID);
            return View(executive);      
        }
        public IActionResult Edit2(int id)
        {
            DeliveryExecutive delivery = _repo2.Get(id);
            return View(delivery);
        }
        [HttpPost]
        public IActionResult Edit2(int id,DeliveryExecutive delivery)
        {
            _repo2.Update(id, delivery);
            return RedirectToAction("Index2");
        }
        public IActionResult RequestsPending()
        {
            // int id = HttpContext.Session.GetInt32("ExecutiveId") == null ? 0 : HttpContext.Session.GetInt32("ExecutiveId").Value;
            int id = Convert.ToInt32(TempData.Peek("executiveId"));

            List<Booking> book = _repo3.GetAll().Where(a => a.executiveID == id && a.status=="Requested").ToList();
            if (book.Count() != 0)
            {
                return View(book);
            }
            else if (book.Count() == 0)
            {
                return View("NoRequests");
            }
            return View();
        }
        public IActionResult NoRequests()
        {
            return View();
        }
        public IActionResult AcceptedList()
        {
            // int id = HttpContext.Session.GetInt32("ExecutiveId") == null ? 0 : HttpContext.Session.GetInt32("ExecutiveId").Value;
            int id = Convert.ToInt32(TempData.Peek("executiveId"));

            List<Booking> booking = _repo3.GetAll().Where(a => a.executiveID == id && a.status == "Accepted").ToList();
            if (booking.Count() != 0)
            {
                return View(booking);
            }
            else if (booking.Count() == 0)
            {
                return View("NoDeliveries");
            }
            return View();
        }
        public IActionResult NoDeliveries()
        {
            return View();
        }
        public IActionResult DeliveredList()
        {
            // int id = HttpContext.Session.GetInt32("ExecutiveId") == null ? 0 : HttpContext.Session.GetInt32("ExecutiveId").Value;
            int id = Convert.ToInt32(TempData.Peek("executiveId"));

            List<Booking> booking = _repo3.GetAll().Where(a => a.executiveID == id && a.status == "Delivered").ToList();
            if (booking.Count() != 0)
            {
                return View(booking);
            }
            else if (booking.Count() == 0)
            {
                return View("NotDelivered");
            }
            return View();
        }
        public IActionResult NotDelivered()
        {
            return View();
        }
        public IActionResult ExecutiveHome()
        {
            return View();
        }

        //booking
        public IActionResult Index3()
        {
            List<Booking> executive = _repo3.GetAll().ToList();
            return View(executive);
        }
        public IActionResult Create3()
        { 
            int id = Convert.ToInt32(TempData.Peek("customerID"));
            Booking book = new Booking();
            book.customerID = id;
            return View(book);
        }
        public IActionResult Delete3()
        {
            return View();
        }
        
            [HttpPost]
        public IActionResult Delete3(int id)
        {
            Booking booking = _repo3.Get(id);
            try 
            {
                if(booking!=null)
                {
                    _repo3.Delete(booking);
                    return RedirectToAction("Index3");
                }
            }
            catch(Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
            
        }
        [HttpPost]
        public IActionResult Create3(Booking booking)
        {
            booking.price = 500;
           booking.status = "Requested";

            _repo3.Add(booking);

            return RedirectToAction("AddedInDatabase");
        }
        public IActionResult AddedInDatabase()
        {
            return View();
        }
        public IActionResult Edit3(int id)
        {
            Booking booking = _repo3.Get(id);
            return View(booking);
        }
        [HttpPost]
        public IActionResult Edit3(int id, Booking booking)
        {
            _repo3.Update(id, booking);
            return RedirectToAction("AcceptedList");
        }

        public IActionResult Details3(int id)
        {
            Booking booking = _repo3.Get(id);
            return View(booking);
        }
        

        public ActionResult Register(User user)
        { 
            if (user.UserType == "Customer")
            {
                return RedirectToAction("Create1");
            }
            else if (user.UserType == "Executive")
            {
                return RedirectToAction("Create2");
            }
            return View();
        }
        public ActionResult Login(User user)
        {
            if (user.UserType == "Customer")
            {
                return RedirectToAction("Login1");
            }
            else if (user.UserType == "Executive")
            {
                return RedirectToAction("Login2");
            }
            else if(user.UserType=="Admin")
            {
                return RedirectToAction("Login4");
            }
            return View();
        }

        

        //Admin
        public IActionResult Login4()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login4(User login)
        {
            if (login.Username == "Admin" && login.Password == "1234")
            {
                return RedirectToAction("AdminHome");
            }
            else
            {
                return View();
            }
        }
        public IActionResult AdminHome()
        {
            return View();
        }
        public IActionResult AdminHomePage(User u)
        {
            if (u.UserType == "Customer")
            {
                return this.RedirectToAction("Index1");
            }
            else if (u.UserType == "Executive")
            {
                return this.RedirectToAction("Index2");
            }
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
