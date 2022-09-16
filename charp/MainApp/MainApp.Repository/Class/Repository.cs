using MainApp.Models.DBModels;
using MainApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Repository.Class
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected BikeDbContext ctx;

        protected Repository(BikeDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(T newEntity)
        {
            ctx.Set<T>().Add(newEntity);
            ctx.SaveChanges();
        }

        public abstract T Read(int id);

        public abstract void Update(T newEntity);

        public void Delete(T Entity)
        {
            ctx.Set<T>().Remove(Entity);
            ctx.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }
    }
}
