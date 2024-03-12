using System;
using System.Collections.Generic;
using System.Text;

namespace GigimuDTO
{
    public class AddBookingDTO
    {
        public int PasienID { get; set; }
        public int JadwalDokterID { get; set; }
        public DateTime JamBooking { get; set; }
    }
}
