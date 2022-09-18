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
        IRepository<WareHouse> repo;

        public WarehouseLogic(IRepository<WareHouse> repo)
        {
            this.repo = repo;
        }

        public void Create(WareHouse newEntity)
        {
            var wareh = this.repo.GetAll().FirstOrDefault(x => x.Name.ToLower() == newEntity.Name.ToLower());

            if (wareh != null)
                throw new ArgumentException("This Item is alredy in the database");

            this.repo.Create(newEntity);
        }

        public WareHouse Read(int id)
        {
            var wareh = this.repo.Read(id);

            if (wareh == null)
                throw new ArgumentException("Item not exists.");

            return wareh;
        }

        public void Update(WareHouse newEntity)
        {
            this.repo.Update(newEntity);
        }
        public void Delete(int id)
        {
            this.repo.Delete(Read(id));
        }

        public IEnumerable<WareHouse> GetAll()
        {
            return this.repo.GetAll();
        }
    }
}
