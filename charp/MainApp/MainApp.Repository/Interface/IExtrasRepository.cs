using MainApp.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Repository.Interface
{
    public interface IExtrasRepository
    {
        void Create(Extra newExtra);
        Extra Read(int id);
        void Update(Extra newExtra);
        void Delete(int id);
        IQueryable<Extra> GetAll();
    }
}
