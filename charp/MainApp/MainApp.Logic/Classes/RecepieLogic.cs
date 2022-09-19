using MainApp.Models.DBModels;
using MainApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Logic.Classes
{
    public class RecepieLogic
    {
        IRepository<Recepies> repo;

        public RecepieLogic(IRepository<Recepies> repo)
        {
            this.repo = repo;
        }

        public void Create(Recepies newEntity)
        {
            var recepie = this.repo.GetAll().FirstOrDefault(x => x.RecepieName.ToLower() == newEntity.RecepieName.ToLower());

            if (recepie != null)
                throw new ArgumentException("This Item is alredy in the database");

            this.repo.Create(newEntity);
        }

        public Recepies Read(int id)
        {
            var recepie = this.repo.Read(id);

            if (recepie == null)
                throw new ArgumentException("This item is not exists.");

            return recepie;
        }

        public void Update(Recepies newEntity)
        {
            this.repo.Update(newEntity);
        }
        public void Delete(int id)
        {
            this.repo.Delete(Read(id));
        }

        public IEnumerable<Recepies> GetAll()
        {
            return this.repo.GetAll();
        }
    }
}
