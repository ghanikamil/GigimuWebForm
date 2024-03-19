using Gigimu.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gigimu.Interface
{
    public interface IKonsultasiDAL : ICrud<Konsultasi>
    {
        IEnumerable<Konsultasi> GetKonsultasiWithDokterPasien();
        IEnumerable<Konsultasi> GetKonsultasiPasienByDokter(int dokterId);

    }
}
