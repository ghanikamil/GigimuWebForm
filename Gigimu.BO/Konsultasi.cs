using System;
using System.Collections.Generic;
using System.Text;

namespace Gigimu.BO
{
    public class Konsultasi
    {
        public int KonsultasiID { get; set; }
        public int DokterID { get; set; }
        public int PasienID { get; set; }
        public DateTime Tanggal { get; set; }
        public string Keluhan { get; set; }
        public string Diagnosa { get; set; }
        public string ResepObat { get; set; }
        public decimal TotalPay { get; set; }
        public Dokter Dokter { get; set; }
        public Pasien Pasien { get; set; }
    }
}
