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
    public class JadwalBLL : IJadwalBLL
    {
        private readonly IJadwalDAL _jadwalDAL;
        public JadwalBLL()
        {
            _jadwalDAL = new JadwalDAL();
        }

        public void Delete(int jadwalId)
        {
            try
            {
                _jadwalDAL.DeteteByID(jadwalId);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
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

        public async Task<IEnumerable<JadwalDTO>> GetJadwalByDokterAsync(int dokterId)
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

        public JadwalDTO GetJadwalById(int id)
        {
            JadwalDTO jadwal = new JadwalDTO();
            var jadwalFromDAL = _jadwalDAL.GetById(id);
            if (jadwalFromDAL == null)
            {
                throw new ArgumentException($"Data article with id:{id} not found");
            }
            jadwal.JadwalDokterID = jadwalFromDAL.JadwalDokterID;
            jadwal.Tanggal = jadwalFromDAL.Tanggal;
            jadwal.MaxOrang = jadwalFromDAL.MaxOrang;
            jadwal.DokterID = jadwalFromDAL.DokterID;
            jadwal.Status = jadwalFromDAL.Status;
            jadwal.PasienTerdaftar = jadwalFromDAL.PasienTerdaftar;

            return jadwal;
        }

        public IEnumerable<JadwalDTO> GetJadwalWithDokter()
        {
            List<JadwalDTO> jadwals = new List<JadwalDTO>();
            var jadwalFromDAL = _jadwalDAL.GetJadwalWithDokter();
            foreach (var jadwal in jadwalFromDAL)
            {
                jadwals.Add(new JadwalDTO
                {
                    JadwalDokterID = jadwal.JadwalDokterID,
                    MaxOrang = jadwal.MaxOrang,
                    PasienTerdaftar = jadwal.PasienTerdaftar,
                    DokterID = jadwal.DokterID,
                    Status = jadwal.Status,
                    Tanggal = jadwal.Tanggal,
                    Dokter = new DokterDTO
                    {
                        DokterID = jadwal.Dokter.DokterID,
                        Email = jadwal.Dokter.Email,
                        Nama = jadwal.Dokter.Nama,
                        Spesialis = jadwal.Dokter.Spesialis
                    }
                });
            }
            return jadwals;
        }

        public void Insert(AddJadwalDTO jadwalDto)
        {
            try
            {
                var jadwal = new Jadwal
                {
                    DokterID = jadwalDto.DokterID,
                    Tanggal = jadwalDto.Tanggal
                };
                _jadwalDAL.Insert(jadwal);
            }
            catch (System.Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Update(UpdateJadwalDTO entity)
        {
            if (entity.MaxOrang<= 0)
            {
                throw new ArgumentException("maxorang is required");
            }
            try
            {
                var jadwal = new Jadwal
                {
                    JadwalDokterID = entity.JadwalDokterID,
                    MaxOrang = entity.MaxOrang
                };
                _jadwalDAL.Update(jadwal);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
