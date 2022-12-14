using MainApp.Logic.Interfaces;
using MainApp.Models.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MainApp.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BlacksmithNoneCrudController : ControllerBase
    {
        IBlacksmithLogic blacksmithLogic;

        public BlacksmithNoneCrudController(IBlacksmithLogic blacksmithLogic)
        {
            this.blacksmithLogic = blacksmithLogic;
        }

        [HttpGet("materialid")]
        public IEnumerable<string> HowManyCreting(int materialid)
        {
            return blacksmithLogic.HowManyCreting(materialid);
        }

        [HttpGet]
        public IEnumerable<string> HowManyHave()
        {
            return this.blacksmithLogic.HowManyHave();
        }
        
        [HttpGet("quality")]
        public IEnumerable<Blacksmith> BetterQuality(int quality)
        {
            return this.blacksmithLogic.BetterQuality(quality);
        }

        [HttpGet]
        public IEnumerable<Blacksmith> NeedToRepair()
        {
            return this.blacksmithLogic.NeedToRepair();
        }

        [HttpGet]
        public IEnumerable<string> AvgItemPrices()
        {
            return this.blacksmithLogic.AvgItemPrices();
        }
    }
}
