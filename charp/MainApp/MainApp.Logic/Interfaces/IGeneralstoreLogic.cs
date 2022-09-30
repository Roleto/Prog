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

        public IEnumerable<string> WhatCanCreate(int id);
        public IEnumerable<Blacksmith> CloseToExpiring(int daysToExpire);
        public IEnumerable<string> HowManyItem();
        public IEnumerable<Blacksmith> DiscontPrice();
        public IEnumerable<Blacksmith> BetterQuality(int quality);
    }
}