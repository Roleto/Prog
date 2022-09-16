using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        void Create(T newEntity);
        T Read(int id);
        void Update(T newEntity);
        void Delete(T Entity);

        IQueryable<T> GetAll();

    }
}
