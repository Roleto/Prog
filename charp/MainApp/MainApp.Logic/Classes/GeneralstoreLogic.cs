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

        public IEnumerable<Generalstore> CloseToExpiring(int daysToExpire)
        {
            return this.repo.GetAll().Where(x=>x.ExpiringDate != null && x.ExpiringDate - daysToExpire <= 0);
        }

        public IEnumerable<string> HowManyItem()
        {
            return (IEnumerable<string>)this.repo.GetAll().GroupBy(x => x.Name).Select(x => new
            {
                Name = x.Key,
                Quantiy = x.Count(),
                AvgPrice = x.Average(y=> y.Price)
            });
        }

        public IEnumerable<Generalstore> DiscontPrice()
        {
            return this.repo.GetAll().Where(x => x.ExpiringDate != null && x.ExpiringDate <= 7)
                .Select(x => new Generalstore()
                {
                    Id = x.Id,
                    MaterialId=x.MaterialId,
                    Name = x.Name,
                    ExpiringDate = x.ExpiringDate,
                    Price = x.Price * 0.75,
                    Quality = x.Quality,
                });
        }

        public IEnumerable<Generalstore> BetterQuality(int quality)
        {
            return this.repo.GetAll().Where(x => x.Quality >= quality);
        }
    }
}
