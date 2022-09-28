using MainApp.Logic.Interfaces;
using MainApp.Models.DBModels;
using MainApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Logic.Classes
{
    public class BlacksmithLogic : IBlacksmithLogic
    {

        IRepository<Blacksmith> repo;

        public BlacksmithLogic(IRepository<Blacksmith> repo)
        {
            this.repo = repo;
        }

        public void Create(Blacksmith newEntity)
        {
            var smith = this.repo.GetAll().FirstOrDefault(x => x.Name.ToLower() == newEntity.Name.ToLower());

            if (smith != null)
                throw new ArgumentException("This Item is alredy in the database");

            this.repo.Create(newEntity);
        }

        public Blacksmith Read(int id)
        {
            var smith = this.repo.Read(id);

            if (smith == null)
                throw new ArgumentException("This item is not exists.");

            return smith;
        }

        public void Update(Blacksmith newEntity)
        {
            this.repo.Update(newEntity);
        }
        public void Delete(int id)
        {
            this.repo.Delete(Read(id));
        }

        public IEnumerable<Blacksmith> GetAll()
        {
            return this.repo.GetAll();
        }
        // non crud

        public IEnumerable<string> HowManyCreting(int materialid)
        {
            List<string> output = new List<string>();
            var querry = from w in this.repo.GetDbContext().Warehouse
                    from r in this.repo.GetDbContext().Recepies
                    where w.Id == materialid && r.MaterialId == materialid
                    select new
                    {
                        Name = w.Name,
                        Recept = r.RecepieName,
                        SumQuantity = w.Quantity,
                        Quantity = w.Quantity / r.MaterialQuantity

                    };
           
            foreach (var item in querry)
            {
                output.Add($"You have:{item.SumQuantity} {item.Name},and you can make {item.Quantity} {item.Recept}");
            }

            return output;
        }

        public IEnumerable<string> WhatCanCreateCreting()
        {
            List<string> output = new List<string>();

            var querry = from wares in this.repo.GetDbContext().Warehouse
                         from recepies in this.repo.GetDbContext().Recepies
                         from black in this.repo.GetAll()
                         where wares.Id == recepies.MaterialId && black.Name == recepies.RecepieName
                         select new
                         {
                             Id = wares.Id,
                             Name = recepies.RecepieName,
                             Material = wares.Name,
                             Quantity = wares.Quantity / recepies.MaterialQuantity
                         };

            foreach (var item in querry)
            {
                Console.WriteLine($"{item.Id}, {item.Name}, {item.Material}, {item.Quantity}");
            }
            Console.ReadLine();
            return output;
        }

        public IEnumerable<Blacksmith> BetterQuality(int Quality)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Blacksmith> NeedToRepair()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> AvgItemPrices()
        {
            throw new NotImplementedException();
        }
    }
}
