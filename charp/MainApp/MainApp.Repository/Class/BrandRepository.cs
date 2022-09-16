using MainApp.Models.DBModels;
using MainApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Repository.Class
{
    public class BrandRepository : IBrandRepository
    {
        BikeDbContext ctx;

        public BrandRepository(BikeDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(Brand newBrand)
        {
            this.ctx.Brands.Add(newBrand);
            this.ctx.SaveChanges();
        }

        public Brand Read(int id)
        {
            return this.ctx.Brands.FirstOrDefault(x => x.BrandId == id);
        }

        public IQueryable<Brand> GetAll()
        {
            return this.ctx.Brands;
        }
    }
}
