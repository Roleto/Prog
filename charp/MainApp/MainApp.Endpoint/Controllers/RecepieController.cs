using MainApp.Logic.Interfaces;
using MainApp.Models.DBModels;
using Microsoft.AspNetCore.Mvc;


namespace MainApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecepieController : ControllerBase
    {
        IRecepieLogic logic;

        public RecepieController(IRecepieLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Recepies> GetAll()
        {
            return this.logic.GetAll();
        }

        [HttpGet("{id}")]
        public Recepies Get(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Recepies value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Recepies value)
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
