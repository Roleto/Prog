using MainApp.Models.DBModels;
using MainApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Repository.Class
{
    public class WarehouseRepository : Repository<Blacksmith>, IRepository<Blacksmith>
    {
        public WarehouseRepository(StrongholdDbContext ctx) : base(ctx)
        {
        }

        public override Blacksmith Read(int id)
        {
            return this.ctx.Warehouse.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Blacksmith newEntity)
        {
            var oldWarehouse = Read(newEntity.Id);
            foreach (var item in oldWarehouse.GetType().GetProperties())
            {
                item.SetValue(oldWarehouse, item.GetValue(newEntity));
            }
            this.ctx.SaveChanges();
        }
    }
}
