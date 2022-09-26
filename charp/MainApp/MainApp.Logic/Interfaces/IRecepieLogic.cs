using MainApp.Models.DBModels;

namespace MainApp.Logic.Interfaces
{
    public interface IRecepieLogic
    {
        void Create(Recepie newEntity);
        Recepie Read(int id);
        void Update(Recepie newEntity);
        void Delete(int id);
        IEnumerable<Recepie> GetAll();
    }
}