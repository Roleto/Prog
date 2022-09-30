﻿using MainApp.Logic.Interfaces;
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

        [HttpGet("materialid")]
        public IEnumerable<Generalstore> CloseToExpiring(int daysToExpire)
        {
            return this.generalstoreLogic.CloseToExpiring(daysToExpire);
        }

        [HttpGet]
        public IEnumerable<string> HowManyItem()
        {
            try
            {
            return this.generalstoreLogic.HowManyItem();

            }
            catch (ArgumentException e)
            {

                return new List<string>() { e.Message };
            }
        }

        [HttpGet]
        public IEnumerable<Blacksmith> DiscontPrice()
        {
            return this.generalstoreLogic.DiscontPrice();
        }

        [HttpGet("quality")]
        public IEnumerable<Blacksmith> BetterQuality(int quality)
        {
            return this.generalstoreLogic.BetterQuality(quality);
        }
    }
}
