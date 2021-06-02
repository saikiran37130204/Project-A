using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBookingSystemMVC2.Services
{
  public  interface IBookingRepo<T>
    {
        IEnumerable<T> GetAll();
        void Add(T t);
        T Get(int id);
        void Delete(T t);
        void Update(int id, T t);
    }
}
