using Gigimu.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gigimu.Interface
{
    public interface IBookingDAL: ICrud<Booking>
    {
        IEnumerable<Booking> GetBookingByPasien(int pasienId);
        void DeteteByID(int id);
    }
}
