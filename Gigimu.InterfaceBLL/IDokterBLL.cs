using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
