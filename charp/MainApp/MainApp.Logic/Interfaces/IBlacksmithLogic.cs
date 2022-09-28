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
        public IEnumerable<Blacksmith> BetterQuality(int Quality);
        public IEnumerable<Blacksmith> NeedToRepair();
        public IEnumerable<string> AvgItemPrices();
    }
    public class AvgClass
    {
        public string Name { get; set; }
        public double? AvgPrice { get; set; }

        public override bool Equals(object obj)
        {
            AvgClass b = obj as AvgClass;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.Name == b.Name
                    && this.AvgPrice == b.AvgPrice;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.AvgPrice);
        }
    }
}