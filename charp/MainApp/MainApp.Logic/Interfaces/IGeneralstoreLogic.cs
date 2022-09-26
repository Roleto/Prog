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
    }
}