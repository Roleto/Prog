using MainApp.Models.DBModels;
using MainApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Repository.Class
{
    public class GeneralstoreRepository : Repository<Generalstore>, IRepository<Generalstore>
    {
        public GeneralstoreRepository(StrongholdDbContext ctx) : base(ctx)
        {
        }

        public override Generalstore Read(int id)
        {
            return this.ctx.Generalstore.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Generalstore newEntity)
        {
            var oldStore = Read(newEntity.Id);
            foreach (var item in oldStore.GetType().GetProperties())
            {
                item.SetValue(oldStore, item.GetValue(newEntity));
            }
            this.ctx.SaveChanges();
        }
    }
}
