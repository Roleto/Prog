using MainApp.Models.DBModels;

namespace MainApp.Logic.Interfaces
{
    public interface IBrandLogic
    {
        void Create(Brand newEntity);
        Brand Read(int id);
        void Update(Brand newEntity);
        void Delete(int id);
        IEnumerable<Brand> GetAll();
    }
}