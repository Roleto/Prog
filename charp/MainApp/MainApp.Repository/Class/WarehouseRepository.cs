using MainApp.Models.DBModels;
using MainApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Repository.Class
{
    public class WarehouseRepository : Repository<WareHouse>, IRepository<WareHouse>
    {
        public WarehouseRepository(StrongholdDbContext ctx) : base(ctx)
        {
        }

        public override WareHouse Read(int id)
        {
            return this.ctx.Warehouse.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(WareHouse newEntity)
        {
            var oldWarehouse = Read(newEntity.Id);
            foreach (var prop in oldWarehouse.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(oldWarehouse, prop.GetValue(newEntity));
                }
            }
            this.ctx.SaveChanges();
        }
    }
}
