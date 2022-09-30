using MainApp.Models.DBModels;

namespace MainApp.Logic.Interfaces
{
    public interface IBlacksmithLogic
    {
        void Create(Blacksmith newEntity);
        Blacksmith Read(int id);
        void Update(Blacksmith newEntity);
        void Delete(int id);
        IEnumerable<Blacksmith> GetAll();
        public IEnumerable<string> HowManyCreting(int materialid);
        public IEnumerable<string> HowManyHave();
        public IEnumerable<Blacksmith> BetterQuality(int quality);
        public IEnumerable<Blacksmith> NeedToRepair();
        public IEnumerable<string> AvgItemPrices();
    }
}