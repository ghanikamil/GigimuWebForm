using System;
using System.Collections.Generic;
using System.Text;

namespace GigimuDTO
{
    public class KonsultasiDTO
    {
        public int KonsultasiID { get; set; }
        public int DokterID { get; set; }
        public int PasienID { get; set; }
        public DateTime Tanggal { get; set; }
        public string Keluhan { get; set; }
        public string Diagnosa { get; set; }
        public string ResepObat { get; set; }
        public decimal TotalPay { get; set; }
        public DokterDTO Dokter { get; set; }
        public PasienDTO Pasien { get; set; }
    }
}
