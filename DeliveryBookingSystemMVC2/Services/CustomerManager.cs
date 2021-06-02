using DeliveryBookingSystemMVC2.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBookingSystemMVC2.Services
{
    public class CustomerManager:IRepo<Customer>
    {
        public DeliveryContext _context;
        public ILogger<CustomerManager> _logger;
        public CustomerManager(DeliveryContext context, ILogger<CustomerManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(Customer t)
        {
            try
            {
                _context.customers.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public Customer Get(int id)
        {
            try
            {
                Customer customer = _context.customers.FirstOrDefault(a => a.customerID == id);
                return customer;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Customer> GetAll()
        {
            try
            {
                if ((_context.customers) == null)
                    return null;
                return _context.customers.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public int Login(Customer t)
        {
            Customer obj = _context.customers.Where(i => i.username.Equals(t.username) && i.password.Equals(t.password)&&i.isVerified.Equals("yes")).FirstOrDefault();
            try
            {
                if (obj != null)
                {
                    return obj.customerID;
                }
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return 0;
        }

        public void Update(int id, Customer t)
        {
            Customer customer = Get(id);
            if (customer != null)
            {
                customer.isVerified = t.isVerified;
            }
            _context.SaveChanges();
        }
    }
}
