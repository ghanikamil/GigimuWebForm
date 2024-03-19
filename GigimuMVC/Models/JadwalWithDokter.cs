using GigimuDTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GigimuMVC.Models
{
    public class JadwalWithDokter
    {
        public int DokterID { get; set; }
        public SelectList Dokters { get; set; }
        public List<JadwalDTO> Jadwals { get; set; }
    }
}
