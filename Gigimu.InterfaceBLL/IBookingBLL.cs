using GigimuDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gigimu.InterfaceBLL
{
    public interface IBookingBLL
    {
        IEnumerable<BookingDTO> GetBookingByPasien(int pasienId);
        void Insert(AddBookingDTO entity);
        void Delete(int pasienId);
        Task<IEnumerable<BookingDTO>> GetBookingByPasienAsync(int pasienId);
        Task InsertAsync(AddBookingDTO entity);
        Task DeleteAsync(int bookingId);
    }
}
