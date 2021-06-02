using DeliveryBookingSystemMVC2.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBookingSystemMVC2.Services
{
    public class ExecutiveManager : IRepo<DeliveryExecutive>
    {
        public DeliveryContext _context;
        public ILogger<ExecutiveManager> _logger;
        public ExecutiveManager(DeliveryContext context, ILogger<ExecutiveManager> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(DeliveryExecutive t)
        {
            try
            {
                _context.deliveryExecutives.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public DeliveryExecutive Get(int id)
        {
            try
            {
                DeliveryExecutive delivery = _context.deliveryExecutives.FirstOrDefault(a => a.executiveID == id);
                return delivery;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<DeliveryExecutive> GetAll()
        {
            try
            {
                if ((_context.deliveryExecutives) == null)
                    return null;
                return _context.deliveryExecutives.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;

        }

        
        public int Login(DeliveryExecutive t)
        {
            DeliveryExecutive obj = _context.deliveryExecutives.Where(i => i.username.Equals(t.username) &&
            i.password.Equals(t.password)&& i.isVerified.Equals("yes")).FirstOrDefault();
            try
            {
                if (obj != null)
                {
                    return obj.executiveID;
                }
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return 0;
        }
        public void Update(int id, DeliveryExecutive t)
        {
            DeliveryExecutive delivery = Get(id);
            if(delivery!=null)
            {
                delivery.isVerified = t.isVerified;
            }
            _context.SaveChanges();
        }
    }
}
