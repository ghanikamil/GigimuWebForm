using GigimuDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gigimu.InterfaceBLL
{
    public interface IPasienBLL
    {
        void ChangePassword(string username, string newPassword);
        void Delete(string username);
        IEnumerable<PasienDTO> GetAll();
        PasienDTO GetByUsername(string username);
        PasienDTO GetById(int id);
        PasienDTO Login(string email, string password);
        void Insert(AddPasienDTO entity);
        void Update(UpdateProfilePasienDTO entity);
        IEnumerable<PasienDTO> GetKonsultasiPasienByDokter(int dokterId);
        Task<PasienDTO> LoginAsync(string email, string password);
        Task InsertAsync(AddPasienDTO entity);
        Task UpdateAsync(UpdateProfilePasienDTO entity);
    }
}
