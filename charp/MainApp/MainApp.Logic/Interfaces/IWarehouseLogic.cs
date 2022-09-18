using MainApp.Models.DBModels;

namespace MainApp.Logic.Interfaces
{
    public interface IWarehouseLogic
    {
        void Create(WareHouse newEntity);
        WareHouse Read(int id);
        void Update(WareHouse newEntity);
        void Delete(int id);
        IEnumerable<WareHouse> GetAll();
    }
}