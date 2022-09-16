using MainApp.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Logic.Interfaces
{
    public interface IExtraLogic
    {
        void Create(Extra newEntity);
        Brand Read(int id);
        void Update(Extra newEntity);
        void Delete(int id);
        IEnumerable<Extra> GetAll();
    }
}
