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

        [HttpGet]
        public IEnumerable<string> WhatCanCreateCreting()
        {
            return this.blacksmithLogic.WhatCanCreateCreting();
        }
        
        [HttpGet("Quality")]
        public IEnumerable<Blacksmith> BetterQuality(int Quality)
        {
            return this.blacksmithLogic.BetterQuality(Quality);
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
