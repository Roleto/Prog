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
    public class BrandLogic : IBrandLogic
    {
        IRepository<Brand> repo;

        public BrandLogic(IRepository<Brand> repo)
        {
            this.repo = repo;
        }

        public void Create(Brand newEntity)
        {
            this.repo.Create(newEntity);
        }

        public Brand Read(int id)
        {
            var brand = this.repo.Read(id);

            if (brand == null)
                throw new ArgumentException("Brand not exists.");

            return brand;
        }

        public void Update(Brand newEntity)
        {
            this.repo.Update(newEntity);
        }
        public void Delete(int id)
        {
            this.repo.Delete(Read(id));
        }

        public IEnumerable<Brand> GetAll()
        {
            return this.repo.GetAll();
        }
    }
}
