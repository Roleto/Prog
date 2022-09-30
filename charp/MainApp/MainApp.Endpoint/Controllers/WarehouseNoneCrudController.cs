using MainApp.Logic.Interfaces;
using MainApp.Models.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MainApp.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class WarehouseNoneCrudController : ControllerBase
    {
        IWarehouseLogic wareLogic;

        public WarehouseNoneCrudController(IWarehouseLogic blacksmithLogic)
        {
            this.wareLogic = blacksmithLogic;
        }

        [HttpGet]
        public IEnumerable<Recepie> WhatCanCreateTheBlacksmith()
        {
            return wareLogic.WhatCanCreateTheBlacksmith();
        }

        [HttpGet]
        public IEnumerable<Recepie> WhatCanCreateTheGeneralStorte()
        {
            return wareLogic.WhatCanCreateTheGeneralStorte();
        }

        [HttpGet("materialid")]
        public IEnumerable<Recepie> RecepieWithMaterail(int materialId)
        {

            return this.wareLogic.RecepieWithMaterail(materialId);
        }

        [HttpGet]
        public IEnumerable<string> AvgMaterialTypePrice()
        {
            return this.wareLogic.AvgMaterialTypePrice();
        }

    }
}
