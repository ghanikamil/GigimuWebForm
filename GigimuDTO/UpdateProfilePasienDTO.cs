using System;
using System.Collections.Generic;
using System.Text;

namespace GigimuDTO
{
    public class UpdateProfilePasienDTO
    {
        public int PasienID { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Telepon { get; set; }
    }
}
