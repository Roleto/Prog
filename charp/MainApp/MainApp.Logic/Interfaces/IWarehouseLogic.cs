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

        IEnumerable<Blacksmith> WHatCanCreateTheBlacksmith();
        IEnumerable<Generalstore> WHatCanCreateTheGeneralStorte();
        IEnumerable<Recepie> RecepieWithMaterail(int materialId);
        double? AvgQantity();
        IEnumerable<string> MaterialTypes();
    }
}