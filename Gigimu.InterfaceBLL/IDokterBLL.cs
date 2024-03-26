using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GigimuDTO;

namespace Gigimu.InterfaceBLL
{
    public interface IDokterBLL
    {
        void Delete(int  id);
        IEnumerable<DokterDTO> GetAll();
        DokterDTO GetById(int id);
        IEnumerable<DokterDTO> GetByName(string name);
        void Insert(AddDokterDTO entty);
        void Update(AddDokterDTO entty);
        DokterDTO LoginMVC(LoginDokterDTO loginDokterDTO);
        void AddUserToRole(int dokterId, int roleId);
        IEnumerable<RoleDTO> GetAllRoles();
        Task<IEnumerable<DokterDTO>> GetAllAsync();
    }
}
