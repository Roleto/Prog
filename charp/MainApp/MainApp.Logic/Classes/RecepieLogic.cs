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
    public class RecepieLogic : IRecepieLogic
    {
        IRepository<Recepie> repo;

        public RecepieLogic(IRepository<Recepie> repo)
        {
            this.repo = repo;
        }

        public void Create(Recepie newEntity)
        {
            var recepie = repo.GetAll().FirstOrDefault(x => x.RecepieName.ToLower() == newEntity.RecepieName.ToLower());

            if (recepie != null)
                throw new ArgumentException("This Item is alredy in the database");

            repo.Create(newEntity);
        }

        public Recepie Read(int id)
        {
            var recepie = repo.Read(id);

            if (recepie == null)
                throw new ArgumentException("This item is not exists.");

            return recepie;
        }

        public void Update(Recepie newEntity)
        {
            repo.Update(newEntity);
        }
        public void Delete(int id)
        {
            repo.Delete(Read(id));
        }

        public IEnumerable<Recepie> GetAll()
        {
            return repo.GetAll();
        }
    }
}
