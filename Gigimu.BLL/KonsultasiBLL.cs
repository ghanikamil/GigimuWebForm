using Gigimu.BO;
using Gigimu.DAL;
using Gigimu.Interface;
using Gigimu.InterfaceBLL;
using GigimuDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gigimu.BLL
{
    public class KonsultasiBLL : IKonsultasiBLL
    {
        private readonly IKonsultasiDAL _konsultasiDAL;
        public KonsultasiBLL()
        {
            _konsultasiDAL = new KonsultasiDAL();
        }
        public IEnumerable<KonsultasiDTO> GetKonsultasiWithDokterPasien()
        {
            List<KonsultasiDTO> konsultasis = new List<KonsultasiDTO>();
            var konsulFromDAL = _konsultasiDAL.GetKonsultasiWithDokterPasien();
            foreach (var konsul in konsulFromDAL)
            {
                konsultasis.Add(new KonsultasiDTO
                {
                    KonsultasiID = konsul.KonsultasiID,
                    DokterID = konsul.DokterID,
                    PasienID = konsul.PasienID,
                    Diagnosa = konsul.Diagnosa,
                    Keluhan = konsul.Keluhan,
                    Tanggal = konsul.Tanggal,
                    ResepObat = konsul.ResepObat,
                    TotalPay = konsul.TotalPay,
                    Dokter = new DokterDTO
                    {
                        DokterID = konsul.Dokter.DokterID,
                        Nama = konsul.Dokter.Nama
                    },
                    Pasien = new PasienDTO
                    {
                        PasienID = konsul.Pasien.PasienID,
                        Nama = konsul.Pasien.Nama
                    }
                });
            }
            return konsultasis;
        }

        public void Insert(AddKonsultasiDTO konsultasiDto)
        {
            try
            {
                var konsultasi = new Konsultasi
                {
                    DokterID = konsultasiDto.DokterID,
                    PasienID = konsultasiDto.PasienID,
                    Diagnosa = konsultasiDto.Diagnosa,
                    Keluhan = konsultasiDto.Keluhan,
                    ResepObat = konsultasiDto.ResepObat,
                    Tanggal = konsultasiDto.Tanggal,
                    TotalPay = konsultasiDto.TotalPay
                };
                _konsultasiDAL.Insert(konsultasi);
            }
            catch (System.Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
