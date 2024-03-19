using GigimuDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gigimu.InterfaceBLL
{
    public interface IKonsultasiBLL
    {
        IEnumerable<KonsultasiDTO> GetKonsultasiWithDokterPasien();
        void Insert(AddKonsultasiDTO konsultasiDto);
    }
}
