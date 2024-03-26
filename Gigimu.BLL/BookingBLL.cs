using Gigimu.BO;
using Gigimu.DAL;
using Gigimu.Interface;
using Gigimu.InterfaceBLL;
using GigimuDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gigimu.BLL
{
    public class BookingBLL : IBookingBLL
    {
        private readonly IBookingDAL _bookingDAL;
        public BookingBLL()
        {
            _bookingDAL = new BookingDAL();
        }
        public void Delete(int pasienId)
        {
            try
            {
                _bookingDAL.DeteteByID(pasienId);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task DeleteAsync(int bookingId)
        {
            try
            {
                _bookingDAL.DeteteByID(bookingId);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<BookingDTO> GetBookingByPasien(int pasienId)
        {
            List<BookingDTO> books = new List<BookingDTO>();
            var bookingFromDAL = _bookingDAL.GetBookingByPasien(pasienId);
            foreach (var book in bookingFromDAL)
            {
                books.Add(new BookingDTO
                {
                    BookingID = book.BookingID,
                    JadwalDokterID = book.JadwalDokterID,
                    PasienID = book.PasienID,
                    JamBooking = book.JamBooking,
                    Dokter = new DokterDTO
                    {
                        Nama = book.dokter.Nama,
                        Spesialis = book.dokter.Spesialis,
                    },
                    Jadwal = new JadwalDTO
                    {
                        Tanggal = book.jadwal.Tanggal,
                    }
                });
            }
            return books;
            //List<JadwalDTO> jadwals = new List<JadwalDTO>();
            //var jadwalFromDAL = _jadwalDAL.GetJadwalByDokter(dokterId);
            //foreach (var jadwal in jadwalFromDAL)
            //{
            //    jadwals.Add(new JadwalDTO
            //    {
            //        JadwalDokterID = jadwal.JadwalDokterID,
            //        Tanggal = jadwal.Tanggal,
            //        MaxOrang = jadwal.MaxOrang,
            //        DokterID = jadwal.DokterID,
            //        Status = jadwal.Status,
            //        PasienTerdaftar = jadwal.PasienTerdaftar,
            //        Dokter = new DokterDTO
            //        {
            //            DokterID = jadwal.Dokter.DokterID,
            //            Nama = jadwal.Dokter.Nama,
            //            Email = jadwal.Dokter.Email,
            //            IsSpesialis = jadwal.Dokter.IsSpesialis,
            //            Password = jadwal.Dokter.Password,
            //            Spesialis = jadwal.Dokter.Spesialis
            //        }
            //    });
            //}
            //return jadwals;
        }

        public async Task<IEnumerable<BookingDTO>> GetBookingByPasienAsync(int pasienId)
        {
            List<BookingDTO> books = new List<BookingDTO>();
            var bookingFromDAL = _bookingDAL.GetBookingByPasien(pasienId);
            foreach (var book in bookingFromDAL)
            {
                books.Add(new BookingDTO
                {
                    BookingID = book.BookingID,
                    JadwalDokterID = book.JadwalDokterID,
                    PasienID = book.PasienID,
                    JamBooking = book.JamBooking,
                    Dokter = new DokterDTO
                    {
                        Nama = book.dokter.Nama,
                        Spesialis = book.dokter.Spesialis,
                    },
                    Jadwal = new JadwalDTO
                    {
                        Tanggal = book.jadwal.Tanggal,
                    }
                });
            }
            return books;
        }

        public void Insert(AddBookingDTO entity)
        {
            try
            {
                var newBook = new Booking
                {
                    JadwalDokterID = entity.JadwalDokterID,
                    PasienID = entity.PasienID,
                    JamBooking = entity.JamBooking
                };
                _bookingDAL.Insert(newBook);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("2627"))
                {
                    throw new ArgumentException("");
                }

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task InsertAsync(AddBookingDTO entity)
        {
            try
            {
                var newBook = new Booking
                {
                    JadwalDokterID = entity.JadwalDokterID,
                    PasienID = entity.PasienID,
                    JamBooking = entity.JamBooking
                };
                _bookingDAL.Insert(newBook);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("2627"))
                {
                    throw new ArgumentException("");
                }

                throw new ArgumentException(ex.Message);
            }
        }
    }
}
