using MainApp.Logic.Interfaces;
using MainApp.Models.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MainApp.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RecepieNoneCrudController : ControllerBase
    {
        IRecepieLogic logic;

        public RecepieNoneCrudController(IRecepieLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet("table")]
        public IEnumerable<Recepie> WhatIsMissing(string table)
        {
            return this.logic.WhatIsMissing(table);
        }
    }
}
