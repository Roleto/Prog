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
    public class WarehouseLogic : IWarehouseLogic
    {
        IRepository<Warehouse> repo;

        public WarehouseLogic(IRepository<Warehouse> repo)
        {
            this.repo = repo;
        }

        public void Create(Warehouse newEntity)
        {
            var wareh = this.repo.GetAll().FirstOrDefault(x => x.Name.ToLower() == newEntity.Name.ToLower());

            if (wareh != null)
                throw new ArgumentException("This Item is alredy in the database");

            this.repo.Create(newEntity);
        }

        public Warehouse Read(int id)
        {
            var wareh = this.repo.Read(id);

            if (wareh == null)
                throw new ArgumentException("Item not exists.");

            return wareh;
        }

        public void Update(Warehouse newEntity)
        {
            this.repo.Update(newEntity);
        }
        public void Delete(int id)
        {
            this.repo.Delete(Read(id));
        }

        public IEnumerable<Warehouse> GetAll()
        {
            return this.repo.GetAll();
        }

        public IEnumerable<Recepie> WhatCanCreateTheBlacksmith()
        {
            return from wares in this.repo.GetAll()
                   from recepie in this.repo.GetDbContext().Recepies
                   where wares.MaterialType.ToLower() == "ore"
                   && wares.Id == recepie.MaterialId
                   && wares.Quantity >= recepie.MaterialQuantity
                   select recepie;
        }

        private bool WhatKindOfMaterialNedded(bool isBlackSmith, string materialType)
        {
            string help = materialType.ToLower();
            if (isBlackSmith)
            {
                if (help == "ore" )
                {
                    return true;
                }
            }else
            {

            }
            return false;
        }

        public IEnumerable<Recepie> WhatCanCreateTheGeneralStorte()
        {
            return from wares in this.repo.GetAll()
                   from recepie in this.repo.GetDbContext().Recepies
                   where wares.MaterialType.ToLower() != "ore"
                   && wares.Id == recepie.MaterialId
                   && wares.Quantity >= recepie.MaterialQuantity
                   select recepie;
        }

        public IEnumerable<Recepie> RecepieWithMaterail(int materialId)
        {
            this.Read(materialId);
            return this.repo.GetDbContext().Recepies.Where(x => x.MaterialId == materialId);
        }

        public IEnumerable<string> AvgMaterialTypePrice()
        {
            var q = from ware in this.repo.GetAll()
                    group ware by ware.MaterialType into g
                    select new
                    {
                        MaterialType = g.Key,
                        Quntity = g.Where(y => y.MaterialType == g.Key).Count(),
                        Avg_Price = g.Average(y => y.Price)
                    } ;

            List<string> output = new List<string>();
            foreach (var item in q)
            {
                output.Add($"{item.MaterialType}, {item.Quntity} ,{item.Avg_Price}");
            }

            return output;
        }
    }
}
