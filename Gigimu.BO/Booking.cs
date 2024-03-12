using System;
using System.Collections.Generic;
using System.Text;

namespace Gigimu.BO
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int PasienID { get; set; }
        public int JadwalDokterID { get; set; }
        public DateTime JamBooking {  get; set; }
        public Jadwal jadwal { get; set; }
        public Pasien pasien { get; set; }
        public Dokter dokter { get; set; }
    }
}
