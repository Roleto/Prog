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

        IEnumerable<Recepie> WhatCanCreateTheBlacksmith();
        IEnumerable<Recepie> WhatCanCreateTheGeneralStorte();
        IEnumerable<Recepie> RecepieWithMaterail(int materialId);
        IEnumerable<string> AvgMaterialTypePrice();
    }
}