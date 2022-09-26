using MainApp.Logic.Interfaces;
using MainApp.Models.DBModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MainApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GeneralStoreController : ControllerBase
    {
        IGeneralstoreLogic logic;

        public GeneralStoreController(IGeneralstoreLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Generalstore> GetAll()
        {
            return this.logic.GetAll();
        }

        [HttpGet("{id}")]
        public Generalstore Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Generalstore value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Generalstore value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
