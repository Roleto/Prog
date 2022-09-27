using MainApp.Logic.Interfaces;
using MainApp.Models.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MainApp.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NoneCrudController : ControllerBase
    {
        IBlacksmithLogic blacksmithLogic;

        public NoneCrudController(IBlacksmithLogic blacksmithLogic)
        {
            this.blacksmithLogic = blacksmithLogic;
        }

        [HttpGet("materialid")]
        public IEnumerable<string> HowManyCreting(int materialid)
        {
            return blacksmithLogic.HowManyCreting(materialid);
        }
    }
}
