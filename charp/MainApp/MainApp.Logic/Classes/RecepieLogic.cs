using MainApp.Logic.Interfaces;
using MainApp.Models.DBModels;
using MainApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public IEnumerable<Recepie> WhatIsMissing(string table)
        {
            if (table.ToLower() == "blacksmith")
            {
                return //from smith in this.repo.GetDbContext().Blacksmith
                       from wares in this.repo.GetDbContext().Warehouse.Where(x=> x.MaterialType.ToLower() == "ore")
                       from recepies in this.repo.GetAll()
                       where wares.Id == recepies.MaterialId
                       join smith in this.repo.GetDbContext().Blacksmith
                       on wares.Id equals smith.MaterialId
                       where recepies.RecepieName != smith.Name
                       select recepies;
            }
            else if (table.ToLower() == "generalstore")
            {
                var items =  from wares in this.repo.GetDbContext().Warehouse.Where(x => x.MaterialType.ToLower() != "ore")
                             from recepies in this.repo.GetAll()
                             where wares.Id == recepies.MaterialId
                             join general in this.repo.GetDbContext().Generalstore
                             on wares.Id equals general.MaterialId
                             where recepies.RecepieName != general.Name
                             select recepies;
                ;
                return from item in items.GroupBy(x => x.RecepieId).ToList()//itt tartasz                     
                       from recepies in this.repo.GetAll()
                       where item.Key == recepies.RecepieId
                       select recepies;
            }
            else
            {
                throw new ArgumentException($"There is no {table} table in the database");
            }
        }

        public IEnumerable<string> WhatCanCreate()
        {
            throw new NotImplementedException();
        }

        public void HowManyCanCreate(int recepieId, int quantity)
        {
            throw new NotImplementedException();
        }

        public void WhatCanCreate(int id)
        {
            throw new NotImplementedException();
        }
    }
}
