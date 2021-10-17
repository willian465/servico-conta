using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Conta.Controllers
{
    [Route("V{version:ApiVersion}/contas")]
    [ApiController]
    [ApiVersion("1")]
    public class ContaController : ControllerBase
    {
        public ContaController()
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public string Get()
        {
            return "ok";
        }
    }
}
