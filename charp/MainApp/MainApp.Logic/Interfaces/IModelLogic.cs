using MainApp.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Logic.Interfaces
{
    public interface IModelLogic
    {
        void Create(Model newEntity);
        Model Read(int id);
        void Update(Model newEntity);
        void Delete(int id);
        IEnumerable<Model> GetAll();
    }
}
