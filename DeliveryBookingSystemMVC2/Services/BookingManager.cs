using DeliveryBookingSystemMVC2.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBookingSystemMVC2.Services
{
    public class BookingManager : IBookingRepo<Booking>
    {
        public DeliveryContext _context;
        public ILogger<BookingManager> _logger;
        public BookingManager(DeliveryContext context, ILogger<BookingManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(Booking t)
        {
            try
            {
                _context.bookings.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public void Delete(Booking t)
        {
            try
            {
                _context.bookings.Remove(t);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public Booking Get(int id)
        {
            try
            {
                Booking booking = _context.bookings.FirstOrDefault(a => a.orderID == id);
                return booking;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Booking> GetAll()
        {
            try
            {
                if ((_context.bookings) == null)
                    return null;
                return _context.bookings.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public void Update(int id, Booking t)
        {
            Booking booking = Get(id);
            if (booking != null)
            {
                booking.weight = t.weight;
                booking.address = t.address;
                booking.phone = t.phone;
                booking.pincode = t.pincode;
                booking.status = t.status;
            }
            _context.SaveChanges();
        }
    }
}
