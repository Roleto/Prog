using MainApp.Logic.Interfaces;
using MainApp.Models.DBModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MainApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {

        IWarehouseLogic logic;

        public WarehouseController(IWarehouseLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<WareHouse> ReadAll()
        {
            return this.logic.GetAll();
        } 

        [HttpGet("{id}")]
        public WareHouse Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] WareHouse value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] WareHouse value)
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
