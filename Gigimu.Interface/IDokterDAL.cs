using Gigimu.BO;
using GigimuDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gigimu.Interface
{
    public interface IDokterDAL : ICrud<Dokter>
    {
        IEnumerable<Dokter> GetByName(string name);
        Dokter Login(string email, string password);
        void AddUserToRole(int dokterId, int roleId);
        IEnumerable<Role> GetAllRoles();
    }
}
