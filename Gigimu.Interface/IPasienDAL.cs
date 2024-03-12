using Gigimu.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gigimu.Interface
{
    public interface IPasienDAL : ICrud<Pasien>
    {
        Pasien Login(string email, string password);
    }
}
