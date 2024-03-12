using GigimuDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gigimu.InterfaceBLL
{
    public interface IJadwalBLL
    {
        IEnumerable<JadwalDTO> GetJadwalByDokter(int dokterId);
    }
}
