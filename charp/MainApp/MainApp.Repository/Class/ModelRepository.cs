using MainApp.Models.DBModels;
using MainApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Repository.Class
{
    public class ModelRepository : Repository<Model>, IRepository<Model>
    {
        public ModelRepository(BikeDbContext ctx) : base(ctx)
        {
        }

        public override Model Read(int id)
        {
            return this.ctx.Models.FirstOrDefault(x => x.ModelId == id);
        }

        public override void Update(Model newEntity)
        {
            var oldModel = Read(newEntity.ModelId);
            foreach (var item in oldModel.GetType().GetProperties())
            {
                item.SetValue(oldModel, item.GetValue(newEntity));
            }
            this.ctx.SaveChanges();
        }
    }
}
