using MainApp.Logic.Interfaces;
using MainApp.Models.DBModels;
using MainApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public IEnumerable<Recepie> WhatCanCreate(int materialId)
        {
           
                if(this.GetAll().FirstOrDefault(x=> x.MaterialId == materialId) == null)
                        throw new ArgumentException("This MaterialId is not int the GeneralstoreTable.");

            return from stores in this.repo.GetAll().ToList().GroupBy(x=> x.MaterialId)
                        join recepies in this.repo.GetDbContext().Recepies
                        on stores.Key equals recepies.MaterialId
                        where stores.Key == materialId
                        select new Recepie()
                        {
                            RecepieId = recepies.RecepieId,
                            MaterialId = recepies.MaterialId,
                            RecepieName = recepies.RecepieName,
                            MaterialQuantity = recepies.MaterialQuantity
                        };
        }

        public IEnumerable<Blacksmith> CloseToExpiring(int daysToExpire)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> HowManyItem()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Blacksmith> DiscontPrice()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Blacksmith> BetterQuality(int quality)
        {
            throw new NotImplementedException();
        }
    }
}
