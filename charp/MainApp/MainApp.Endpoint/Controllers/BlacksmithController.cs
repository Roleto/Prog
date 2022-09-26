using MainApp.Logic.Interfaces;
using MainApp.Models.DBModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MainApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlacksmithController : ControllerBase
    {
        IBlacksmithLogic logic;

        public BlacksmithController(IBlacksmithLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Put([FromBody] Blacksmith value)
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
