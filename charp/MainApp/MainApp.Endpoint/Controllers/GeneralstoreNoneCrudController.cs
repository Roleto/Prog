using MainApp.Logic.Interfaces;
using MainApp.Models.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MainApp.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GeneralstoreNoneCrudController : ControllerBase
    {
        IGeneralstoreLogic generalstoreLogic;

        public GeneralstoreNoneCrudController(IGeneralstoreLogic blacksmithLogic)
        {
            this.generalstoreLogic = blacksmithLogic;
        }

        [HttpGet("materialid")]
        public IEnumerable<Recepie> WhatCanCreate(int materialId)
        {
            return generalstoreLogic.WhatCanCreate(materialId);
        }

        [HttpGet("daysToExpire")]
        public IEnumerable<Generalstore> CloseToExpiring(int daysToExpire)
        {
            return this.generalstoreLogic.CloseToExpiring(daysToExpire);
        }

        [HttpGet]
        public IEnumerable<string> HowManyItem()
        {

            return this.generalstoreLogic.HowManyItem();
        }

        [HttpGet]
        public IEnumerable<Generalstore> DiscontPrice()
        {
            return this.generalstoreLogic.DiscontPrice();
        }

        [HttpGet("quality")]
        public IEnumerable<Generalstore> BetterQuality(int quality)
        {
            return this.generalstoreLogic.BetterQuality(quality);
        }
    }
}
