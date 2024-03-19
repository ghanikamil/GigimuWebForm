using Gigimu.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gigimu.Interface
{
    public interface IJadwalDAL : ICrud<Jadwal>
    {
        IEnumerable<Jadwal> GetJadwalWithDokter();
        IEnumerable<Jadwal> GetJadwalByDokter(int dokterId);
        void DeteteByID(int id);
    }
}
