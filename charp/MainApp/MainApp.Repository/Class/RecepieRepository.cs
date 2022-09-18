using System;
using MainApp.Models.DBModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainApp.Repository.Interface;

namespace MainApp.Repository.Class
{
    public class RecepieRepository : Repository<Recepies>, IRepository<Recepies>
    {
        public RecepieRepository(StrongholdDbContext ctx) : base(ctx)
        {
        }

        public override Recepies Read(int id)
        {
            return this.ctx.Recepies.FirstOrDefault(x => x.RecepieId == id);
        }

        public override void Update(Recepies newEntity)
        {
            var oldRecepie = Read(newEntity.RecepieId);
            foreach (var item in oldRecepie.GetType().GetProperties())
            {
                item.SetValue(oldRecepie, item.GetValue(newEntity));
            }
            this.ctx.SaveChanges();
        }
    }
}
