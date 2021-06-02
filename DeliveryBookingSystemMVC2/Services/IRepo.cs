using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBookingSystemMVC2.Services
{
    public interface IRepo<T>
    {
        IEnumerable<T> GetAll();
        void Add(T t);
        int Login(T t);
        T Get(int id);
        void Update(int id, T t);
    }
}
