using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Norbit.Sap.Georgiev.CSharpLastTask.Api.DB.DBDataProvider.Linq2DB;
using Norbit.Sap.Georgiev.CSharpLastTask.Api.DB.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Norbit.Sap.Georgiev.CSharpLastTask.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly Linq2DBDataProvider _linq2DBDataProvider;

        public UserController(Linq2DBDataProvider linq2DBDataProvider)
        {
            _linq2DBDataProvider = linq2DBDataProvider;
        }

        [HttpGet]
        //[Route("lastDealByData")]
        public ActionResult<List<Data>> GetAllData()
        {
            try
            {
                return Ok(_linq2DBDataProvider.GetLastDeal());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
