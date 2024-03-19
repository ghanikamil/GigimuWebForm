using System;
using System.Collections.Generic;
using System.Text;

namespace GigimuDTO
{
    public class DokterDTO
    {
        public int DokterID { get; set; }
        public string Nama { get; set; }
        public string Spesialis { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsSpesialis { get; set; }
        public IEnumerable<RoleDTO> Roles { get; set; }
    }
}
