using MainApp.Logic.Interfaces;
using MainApp.Models.DBModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MainApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GeneralStoreController : ControllerBase
    {
        IGeneralstoreLogic logic;
        IHubContext<SignalRHub> hub;
        public GeneralStoreController(IGeneralstoreLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("WarehouseCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Generalstore value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("WarehouseUpdate", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var generalToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("WarehouseDelete", generalToDelete);
        }
    }
}
