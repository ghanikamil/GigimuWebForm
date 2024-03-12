using GigimuDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gigimu.InterfaceBLL
{
    public interface IBookingBLL
    {
        IEnumerable<BookingDTO> GetBookingByPasien(int pasienId);
        void Insert(AddBookingDTO entity);
        void Delete(int pasienId);
    }
}
