using System;
using System.Collections.Generic;
using System.Text;

namespace Gigimu.Interface
{
    public interface ICrud<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
