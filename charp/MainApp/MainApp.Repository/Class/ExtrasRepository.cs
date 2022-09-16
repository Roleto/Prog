using MainApp.Models.DBModels;
using MainApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Repository.Class
{
    public class ExtrasRepository : Repository<Extra>, IRepository<Extra>
    {
        public ExtrasRepository(BikeDbContext ctx) : base(ctx)
        {
        }

        public override Extra Read(int id)
        {
            return this.ctx.Extras.FirstOrDefault(x => x.ExtraId == id);
        }

        public override void Update(Extra newEntity)
        {
            var oldExtra = Read(newEntity.ExtraId);
            foreach (var item in oldExtra.GetType().GetProperties())
            {
                item.SetValue(oldExtra, item.GetValue(newEntity));
            }
            this.ctx.SaveChanges();
        }
    }
}
