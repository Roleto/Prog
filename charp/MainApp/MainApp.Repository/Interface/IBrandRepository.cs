using MainApp.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Repository.Interface
{
    public interface IBrandRepository
    {
        void Create(Brand newBrand);
        Brand Read(int id);
        void Update(Brand newBrand);
        void Delete(int id);
        IQueryable<Brand> GetAll();

    }
}
