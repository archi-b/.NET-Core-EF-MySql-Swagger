using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace controller.usuario.Controllers
{
    public interface ICore<T> where T : class
    {
        T Insert(T item);
        T Get(int id);
        void Update(T item);
        bool Delete(int id);
        List<T> GetList(int id);
        List<T> GetAll();
    }
}
