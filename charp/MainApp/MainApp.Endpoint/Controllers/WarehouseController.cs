using MainApp.Logic.Interfaces;
using MainApp.Models.DBModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace MainApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {

        IWarehouseLogic logic;
        IHubContext<SignalRHub> hub;      

        public WarehouseController(IWarehouseLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Warehouse> ReadAll()
        {
            return this.logic.GetAll();
        } 

        [HttpGet("{id}")]
        public Warehouse Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Warehouse value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("WarehouseCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Warehouse value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("WarehouseUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var wareToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("WarehpuseDeleted", wareToDelete);
        }
    }
}
