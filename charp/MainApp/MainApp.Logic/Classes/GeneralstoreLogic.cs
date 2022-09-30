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
    public class GeneralstoreLogic : IGeneralstoreLogic
    {

        IRepository<Generalstore> repo;

        public GeneralstoreLogic(IRepository<Generalstore> repo)
        {
            this.repo = repo;
        }

        public void Create(Generalstore newEntity)
        {
            var store = this.repo.GetAll().FirstOrDefault(x => x.Name.ToLower() == newEntity.Name.ToLower());

            if (store != null)
                throw new ArgumentException("This Item is alredy in the database");

            this.repo.Create(newEntity);
        }

        public Generalstore Read(int id)
        {
            var store = this.repo.Read(id);

            if (store == null)
                throw new ArgumentException("This item is not exists.");

            return store;
        }

        public void Update(Generalstore newEntity)
        {
            this.repo.Update(newEntity);
        }
        public void Delete(int id)
        {
            this.repo.Delete(Read(id));
        }

        public IEnumerable<Generalstore> GetAll()
        {
            return this.repo.GetAll();
        }

       
    }
}
