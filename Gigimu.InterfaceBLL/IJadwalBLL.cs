using GigimuDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gigimu.InterfaceBLL
{
    public interface IJadwalBLL
    {
        IEnumerable<JadwalDTO> GetJadwalByDokter(int dokterId);
        IEnumerable<JadwalDTO> GetJadwalWithDokter();
        void Insert(AddJadwalDTO jadwalDto);
        JadwalDTO GetJadwalById(int id);
        void Update(UpdateJadwalDTO entity);
        void Delete(int jadwalId);

        Task<IEnumerable<JadwalDTO>> GetJadwalByDokterAsync(int dokterId);
    }
}
