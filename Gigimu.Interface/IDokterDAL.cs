using Gigimu.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gigimu.Interface
{
    public interface IDokterDAL : ICrud<Dokter>
    {
        IEnumerable<Dokter> GetByName(string name);
    }
}
