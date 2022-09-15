using MainApp.Models.DBModels;
using MainApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Repository.Class
{
    public class ExtrasRepository : IExtrasRepository
    {
        BikeDbContext ctx;

        public ExtrasRepository(BikeDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(Extra newExtra)
        {
            this.ctx.Extras.Add(newExtra);
            ctx.SaveChanges();
        }
        public Extra Read(int id)
        {
            return this.ctx.Extras.FirstOrDefault(x => x.ExtraId == id);
        }

        public void Update(Extra newExtra)
        {
            var oldExtra = Read(newExtra.ExtraId);
            oldExtra.Name = newExtra.Name;
            oldExtra.Price = newExtra.Price;
            this.ctx.SaveChanges();
        }
        public void Delete(int id)
        {
            this.ctx.Extras.Remove(Read(id));
            this.ctx.SaveChanges();
        }

        public IQueryable<Extra> GetAll()
        {
            return this.ctx.Extras.AsQueryable();
        }
    }
}
