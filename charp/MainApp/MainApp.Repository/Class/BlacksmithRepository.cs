using MainApp.Models.DBModels;
using MainApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Repository.Class
{
    public class BlacksmithRepository : Repository<Blacksmith>, IRepository<Blacksmith>
    {
        public BlacksmithRepository(StrongholdDbContext ctx) : base(ctx)
        {
        }

        public override Blacksmith Read(int id)
        {
            return this.ctx.Blacksmith.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Blacksmith newEntity)
        {
            var oldBlacksmith = Read(newEntity.Id);
            foreach (var item in oldBlacksmith.GetType().GetProperties())
            {
                item.SetValue(oldBlacksmith, item.GetValue(newEntity));
            }
            this.ctx.SaveChanges();
        }
    }
}
