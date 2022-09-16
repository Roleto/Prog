using MainApp.Models.DBModels;
using MainApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Repository.Class
{
    public class BrandRepository : Repository<Brand>, IRepository<Brand>
    {
        public BrandRepository(BikeDbContext ctx) : base(ctx)
        {
        }
        public override Brand Read(int id)
        {
            return this.ctx.Brands.FirstOrDefault(x => x.BrandId == id);
        }

        public override void Update(Brand newEntity)
        {
            var oldBrand = Read(newEntity.BrandId);
            foreach (var item in oldBrand.GetType().GetProperties())
            {
                item.SetValue(oldBrand, item.GetValue(newEntity));
            }
            this.ctx.SaveChanges();
        }
    }
}
