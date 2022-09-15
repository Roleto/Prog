using MainApp.Models.DBModels;
using MainApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Repository.Class
{
    public class ModelRepository : IModelRepository
    {
        BikeDbContext ctx;

        public ModelRepository(BikeDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(Model newModel)
        {
            this.ctx.Models.Add(newModel);
            this.ctx.SaveChanges();
        }
        public Model Read(int id)
        {
            return this.ctx.Models.FirstOrDefault(x => x.ModelId == id);
        }

        public void Update(Model newModel)
        {
            var oldModel = Read(newModel.ModelId);
            oldModel.ModelName = newModel.ModelName;
            oldModel.BasePrice = newModel.BasePrice;
            this.ctx.SaveChanges();
        }
        public void Delete(int id)
        {
            this.ctx.Models.Remove(Read(id));
            this.ctx.SaveChanges();
        }

        public IQueryable<Model> GetAll()
        {
            return this.ctx.Models; 
        }
    }
}
