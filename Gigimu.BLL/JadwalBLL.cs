using Gigimu.DAL;
using Gigimu.Interface;
using Gigimu.InterfaceBLL;
using GigimuDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gigimu.BLL
{
    public class JadwalBLL : IJadwalBLL
    {
        private readonly IJadwalDAL _jadwalDAL;
        public JadwalBLL()
        {
            _jadwalDAL = new JadwalDAL();
        }
        public IEnumerable<JadwalDTO> GetJadwalByDokter(int dokterId)
        {
            List<JadwalDTO> jadwals = new List<JadwalDTO>();
            var jadwalFromDAL = _jadwalDAL.GetJadwalByDokter(dokterId);
            foreach (var jadwal in jadwalFromDAL)
            {
                jadwals.Add(new JadwalDTO
                {
                    JadwalDokterID = jadwal.JadwalDokterID,
                    Tanggal = jadwal.Tanggal,
                    MaxOrang = jadwal.MaxOrang,
                    DokterID = jadwal.DokterID,
                    Status = jadwal.Status,
                    PasienTerdaftar = jadwal.PasienTerdaftar,
                    Dokter = new DokterDTO
                    {
                        DokterID = jadwal.Dokter.DokterID,
                        Nama = jadwal.Dokter.Nama,
                        Email = jadwal.Dokter.Email,
                        IsSpesialis = jadwal.Dokter.IsSpesialis,
                        Password = jadwal.Dokter.Password,
                        Spesialis = jadwal.Dokter.Spesialis
                    }
                });
            }
            return jadwals;
        }
    }
}
