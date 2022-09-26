using System;
using MainApp.Models.DBModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainApp.Repository.Interface;

namespace MainApp.Repository.Class
{
    public class RecepieRepository : Repository<Recepie>, IRepository<Recepie>
    {
        public RecepieRepository(StrongholdDbContext ctx) : base(ctx)
        {
        }

        public override Recepie Read(int id)
        {
            return this.ctx.Recepies.FirstOrDefault(x => x.RecepieId == id);
        }

        public override void Update(Recepie newEntity)
        {
            var oldRecepie = Read(newEntity.RecepieId);
            foreach (var prop in oldRecepie.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(oldRecepie, prop.GetValue(newEntity));
                }
            }
            this.ctx.SaveChanges();
        }
    }
}
