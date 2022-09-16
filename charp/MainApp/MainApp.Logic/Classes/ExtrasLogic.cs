using MainApp.Models.DBModels;
using MainApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Logic.Classes
{
    public class ExtrasLogic
    {
        IRepository<Extra> repo;

        public ExtrasLogic(IRepository<Extra> repo)
        {
            this.repo = repo;
        }

        public void Create(Extra newEntity)
        {
            this.repo.Create(newEntity);
        }

        public Extra Read(int id)
        {
            var extra = this.repo.Read(id);

            if (extra == null)
                throw new ArgumentException("Extra not exists.");

            return extra;
        }

        public void Update(Extra newEntity)
        {
            this.repo.Update(newEntity);
        }
        public void Delete(int id)
        {
            this.repo.Delete(Read(id));
        }

        public IEnumerable<Extra> GetAll()
        {
            return this.repo.GetAll();
        }
    }
}
