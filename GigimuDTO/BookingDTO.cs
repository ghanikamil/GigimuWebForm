using System;
using System.Collections.Generic;
using System.Text;

namespace GigimuDTO
{
    public class BookingDTO
    {
        public int BookingID { get; set; }
        public int PasienID { get; set; }
        public int JadwalDokterID { get; set; }
        public DateTime JamBooking { get; set; }
        public JadwalDTO Jadwal { get; set; }
        public DokterDTO Dokter { get; set; }
    }
}
