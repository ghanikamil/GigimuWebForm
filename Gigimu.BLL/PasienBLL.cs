using Gigimu.BO;
using Gigimu.DAL;
using Gigimu.Interface;
using Gigimu.InterfaceBLL;
using GigimuDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gigimu.BLL
{
    public class PasienBLL : IPasienBLL
    {
        private readonly IPasienDAL pasienDAL;
        public PasienBLL()
        {
            pasienDAL = new PasienDAL();
        }
        public void ChangePassword(string username, string newPassword)
        {
            throw new NotImplementedException();
        }

        public void Delete(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PasienDTO> GetAll()
        {
            List<PasienDTO> listPasienDto = new List<PasienDTO>();
            var pasiens = pasienDAL.GetAll();
            foreach (var pasien in pasiens)
            {
                listPasienDto.Add(new PasienDTO
                {
                    PasienID = pasien.PasienID,
                    Alamat = pasien.Alamat,
                    Email = pasien.Email,
                    Nama = pasien.Nama,
                    Telepon = pasien.Telepon,
                });
            }
            return listPasienDto;
        }

        public PasienDTO GetById(int id)
        {
            PasienDTO pasienDTO = new PasienDTO();
            var pasien = pasienDAL.GetById(id);
            if (pasien != null)
            {
                pasienDTO.PasienID = pasien.PasienID;
                pasienDTO.Nama = pasien.Nama;
                pasienDTO.Alamat = pasien.Alamat;
                pasienDTO.Telepon = pasien.Telepon;
                pasienDTO.Email = pasien.Email;
            }
            else
            {
                throw new ArgumentException($"Pasien {id} not found");
            }
            return pasienDTO;
        }

        public PasienDTO GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PasienDTO> GetKonsultasiPasienByDokter(int dokterId)
        {
            List<PasienDTO> pasiens = new List<PasienDTO>();
            var pasienFromDAL = pasienDAL.GetKonsultasiPasienByDokter(dokterId);
            foreach (var pasien in pasienFromDAL)
            {
                pasiens.Add(new PasienDTO
                {
                    PasienID = pasien.PasienID,
                    Nama = pasien.Nama,
                });
            }
            return pasiens;
        }

        public void Insert(AddPasienDTO entity)
        {
            if (string.IsNullOrEmpty(entity.Password))
            {
                throw new ArgumentException("Password is required");
            }
            if (string.IsNullOrEmpty(entity.Nama))
            {
                throw new ArgumentException("Nama is required");
            }
            if (string.IsNullOrEmpty(entity.Alamat))
            {
                throw new ArgumentException("Alamat is required");
            }
            if (string.IsNullOrEmpty(entity.Email))
            {
                throw new ArgumentException("Email is required");
            }
            if (string.IsNullOrEmpty(entity.Telepon))
            {
                throw new ArgumentException("Telepon is required");
            }
            // Trim the Telepon value to remove leading and trailing whitespaces
            string trimmedTelepon = entity.Telepon.Trim();

            // Check if Telepon contains only numeric characters
            if (!trimmedTelepon.All(char.IsDigit))
            {
                throw new ArgumentException("Telepon must contain only numeric characters");
            }
            if (entity.Password != entity.Repassword)
            {
                throw new ArgumentException("Password and Re-Password must be same");
            }
            try
            {
                var newPasien = new Pasien
                {
                    Nama = entity.Nama,
                    Alamat = entity.Alamat,
                    Email = entity.Email,
                    Telepon = trimmedTelepon,
                    Password = entity.Password,
                };
                pasienDAL.Insert(newPasien);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("2627"))
                {
                    throw new ArgumentException("Username already exists");
                }

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task InsertAsync(AddPasienDTO entity)
        {
            string trimmedTelepon = entity.Telepon.Trim();

            // Check if Telepon contains only numeric characters
            if (!trimmedTelepon.All(char.IsDigit))
            {
                throw new ArgumentException("Telepon must contain only numeric characters");
            }
            try
            {
                var newPasien = new Pasien
                {
                    Nama = entity.Nama,
                    Alamat = entity.Alamat,
                    Email = entity.Email,
                    Telepon = trimmedTelepon,
                    Password = entity.Password,
                };
                pasienDAL.Insert(newPasien);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("2627"))
                {
                    throw new ArgumentException("Username already exists");
                }

                throw new ArgumentException(ex.Message);
            }
        }

        public PasienDTO Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("email is required");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("password is required");
            }
            try
            {
                var result = pasienDAL.Login(email, password);
                if (result == null)
                {
                    throw new ArgumentException("email or password is wrong");
                }
                PasienDTO pasienDTO = new PasienDTO
                {
                    PasienID = result.PasienID,
                    Nama = result.Nama,
                    Alamat = result.Alamat,
                    Telepon = result.Telepon,
                    Email = result.Email
                };
                return pasienDTO;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<PasienDTO> LoginAsync(string email, string password)
        {
            try
            {
                var result = pasienDAL.Login(email, password);
                if (result == null)
                {
                    throw new ArgumentException("email or password is wrong");
                }
                PasienDTO pasienDTO = new PasienDTO
                {
                    PasienID = result.PasienID,
                    Nama = result.Nama,
                    Alamat = result.Alamat,
                    Telepon = result.Telepon,
                    Email = result.Email
                };
                return pasienDTO;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public void Update(UpdateProfilePasienDTO entity)
        {
            try
            {
                var updatePasien = new Pasien
                {
                    PasienID = entity.PasienID,
                    Nama = entity.Nama,
                    Alamat = entity.Alamat,
                    Telepon = entity.Telepon,
                };
                pasienDAL.Update(updatePasien);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task UpdateAsync(UpdateProfilePasienDTO entity)
        {
            try
            {
                var updatePasien = new Pasien
                {
                    PasienID = entity.PasienID,
                    Nama = entity.Nama,
                    Alamat = entity.Alamat,
                    Telepon = entity.Telepon,
                };
                pasienDAL.Update(updatePasien);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
