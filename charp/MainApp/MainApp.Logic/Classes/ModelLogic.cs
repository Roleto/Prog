using MainApp.Logic.Interfaces;
using MainApp.Models.DBModels;
using MainApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Logic.Classes
{
    public class ModelLogic : IModelLogic
    {
        IRepository<Model> repo;

        public ModelLogic(IRepository<Model> repo)
        {
            this.repo = repo;
        }

        public void Create(Model newEntity)
        {
            this.repo.Create(newEntity);
        }

        public Model Read(int id)
        {
            var model = this.repo.Read(id);

            if (model == null)
                throw new ArgumentException("Model not exists.");

            return model;
        }

        public void Update(Model newEntity)
        {
            this.repo.Update(newEntity);
        }
        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public IEnumerable<Model> GetAll()
        {
            return this.repo.GetAll();
        }
    }
}
