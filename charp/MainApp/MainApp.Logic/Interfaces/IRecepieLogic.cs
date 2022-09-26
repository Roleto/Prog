using MainApp.Models.DBModels;

namespace MainApp.Logic.Interfaces
{
    public interface IRecepieLogic
    {
        void Create(Recepies newEntity);
        Recepies Read(int id);
        void Update(Recepies newEntity);
        void Delete(int id);
        IEnumerable<Recepies> GetAll();
    }
}