using MainApp.Models.DBModels;

namespace MainApp.Logic.Interfaces
{
    public interface IGeneralstoreLogic
    {
        void Create(Generalstore newEntity);
        Generalstore Read(int id);
        void Update(Generalstore newEntity);
        void Delete(int id);
        IEnumerable<Generalstore> GetAll();

        public IEnumerable<Recepie> WhatCanCreate(int materialId);
        public IEnumerable<Generalstore> CloseToExpiring(int daysToExpire);
        public IEnumerable<string> HowManyItem();
        public IEnumerable<Generalstore> DiscontPrice();
        public IEnumerable<Generalstore> BetterQuality(int quality);
    }
}