using MainApp.Logic.Interfaces;
using MainApp.Models.DBModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MainApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlacksmithController : ControllerBase
    {
        IBlacksmithLogic logic;
        IHubContext<SignalRHub> hub;

        public BlacksmithController(IBlacksmithLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Blacksmith> GetAll()
        {
            return this.logic.GetAll();
        }

        [HttpGet("{id}")]
        public Blacksmith Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Blacksmith value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("BlacksmithCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Blacksmith value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("Blacksmithupdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var blackToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("BlacksmithDeleted", blackToDelete);
        }
    }
}
