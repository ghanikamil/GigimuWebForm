using GigimuDTO;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
