using System;
using System.Collections.Generic;
using System.Text;

namespace GigimuDTO
{
    public class JadwalDTO
    {
        public int JadwalDokterID { get; set; }
        public DateTime Tanggal { get; set; }
        public int MaxOrang { get; set; }
        public int DokterID { get; set; }
        public string Status { get; set; }
        public int PasienTerdaftar { get; set; }
        public DokterDTO Dokter { get; set; }
    }
}
