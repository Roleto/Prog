using MainApp.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Repository.Interface
{
    public interface IModelRepository
    {
        void Create(Model newModel);
        void Read(int id);
        void Update(Model newModel);
        void Delete(int id);    
        IQueryable<Model> GetAll();
    }
}
