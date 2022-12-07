using MainApp.Models.DBModels;

namespace MainApp.Logic.Interfaces
{
    public interface IWarehouseLogic
    {
        void Create(Warehouse newEntity);
        Warehouse Read(int id);
        void Update(Warehouse newEntity);
        void Delete(int id);
        IEnumerable<Warehouse> GetAll();

        IEnumerable<Recepie> WhatCanCreateTheBlacksmith();
        IEnumerable<Recepie> WhatCanCreateTheGeneralStorte();
        IEnumerable<Recepie> RecepieWithMaterail(int materialId);
        IEnumerable<string> AvgMaterialTypePrice();
    }
}