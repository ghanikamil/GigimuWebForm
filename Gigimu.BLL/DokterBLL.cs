using Gigimu.BO;
using Gigimu.DAL;
using Gigimu.Interface;
using Gigimu.InterfaceBLL;
using GigimuDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Gigimu.BLL
{
    public class DokterBLL : IDokterBLL
    {
        private readonly IDokterDAL _dokterDAL;
        public DokterBLL()
        {
            _dokterDAL = new DokterDAL();
        }

        public void AddUserToRole(int dokterId, int roleId)
        {
            try
            {
                _dokterDAL.AddUserToRole(dokterId, roleId);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DokterDTO> GetAll()
        {
            List<DokterDTO> listDokterDto = new List<DokterDTO>();
            var dokters = _dokterDAL.GetAll();
            foreach ( var dokter in dokters)
            {
                listDokterDto.Add(new DokterDTO
                {
                    DokterID = dokter.DokterID,
                    Nama = dokter.Nama,
                    Spesialis = dokter.Spesialis,
                    Email = dokter.Email,
                    Password = dokter.Password,
                    IsSpesialis = dokter.IsSpesialis
                });
            }
            return listDokterDto;
        }

        public async Task<IEnumerable<DokterDTO>> GetAllAsync()
        {
            List<DokterDTO> listDokterDto = new List<DokterDTO>();
            var dokters = _dokterDAL.GetAll();
            foreach (var dokter in dokters)
            {
                listDokterDto.Add(new DokterDTO
                {
                    DokterID = dokter.DokterID,
                    Nama = dokter.Nama,
                    Spesialis = dokter.Spesialis,
                    Email = dokter.Email,
                    Password = dokter.Password,
                    IsSpesialis = dokter.IsSpesialis
                });
            }
            return listDokterDto;
        }

        public IEnumerable<RoleDTO> GetAllRoles()
        {
            var results = _dokterDAL.GetAllRoles();
            var resultsDTO = new List<RoleDTO>();
            foreach (var item in results)
            {
                resultsDTO.Add(new RoleDTO
                {
                    RoleID = item.RoleID,
                    RoleName = item.RoleName
                });
            }
            return resultsDTO;
        }

        public DokterDTO GetById(int id)
        {
            DokterDTO dokterDto = new DokterDTO();
            var dokter = _dokterDAL.GetById(id);
            if (dokter != null)
            {
                dokterDto.DokterID = dokter.DokterID;
                dokterDto.Nama = dokter.Nama;
                dokterDto.Spesialis = dokter.Spesialis;
                dokterDto.Email = dokter.Email;
                dokterDto.Password = dokter.Password;
                dokterDto.IsSpesialis = dokter.IsSpesialis;
            }else
            {
                throw new ArgumentException($"Category {id} not found");
            }
            return dokterDto;
        }

        public IEnumerable<DokterDTO> GetByName(string name)
        {
            var dokters = _dokterDAL.GetByName(name);
            //Mapping ke DTO
            List<DokterDTO> listDoktersDto = new List<DokterDTO>();
            foreach (var dokter in dokters)
            {
                listDoktersDto.Add(new DokterDTO
                {
                    DokterID = dokter.DokterID,
                    Nama = dokter.Nama,
                    Spesialis = dokter.Spesialis,
                    Email = dokter.Email,
                    Password = dokter.Password,
                    IsSpesialis = dokter.IsSpesialis
                });
            }
            return listDoktersDto;
        }

        public void Insert(AddDokterDTO entty)
        {
            if (string.IsNullOrEmpty(entty.Nama))
            {
                throw new ArgumentException("Name is required");
            }
            else if (entty.Nama.Length > 50)
            {
                throw new ArgumentException("Name max length is 50");
            }

            try
            {
                var newDokter = new Dokter
                {
                    Nama = entty.Nama,
                    Spesialis= entty.Spesialis,
                    Email = entty.Email,
                    Password = entty.Password
                };
                _dokterDAL.Insert(newDokter);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DokterDTO LoginMVC(LoginDokterDTO loginDokterDTO)
        {
            if (string.IsNullOrEmpty(loginDokterDTO.Email))
            {
                throw new ArgumentException("Email is required");
            }
            if (string.IsNullOrEmpty(loginDokterDTO.Password))
            {
                throw new ArgumentException("Password is required");
            }
            try
            {
                var result = _dokterDAL.Login(loginDokterDTO.Email,loginDokterDTO.Password);
                if (result == null)
                {
                    throw new ArgumentException("Username or Password is wrong");
                }

                var lstRolesDto = new List<RoleDTO>();
                var roles = result.Roles;
                foreach (var role in roles)
                {
                    lstRolesDto.Add(new RoleDTO
                    {
                        RoleID = role.RoleID,
                        RoleName = role.RoleName
                    });
                }
                DokterDTO dokterDTO = new DokterDTO
                {
                    DokterID = result.DokterID,
                    Email = result.Email,
                    Password = result.Password,
                    Nama = result.Nama,
                    Spesialis = result.Spesialis,
                    IsSpesialis = result.IsSpesialis,
                    Roles = lstRolesDto
                };

                return dokterDTO;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Update(AddDokterDTO entty)
        {
            throw new NotImplementedException();
        }
    }
}
