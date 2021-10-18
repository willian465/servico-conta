using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conta.Responses;
using Conta.Services.Interfaces;
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
        private readonly IContaService _contaService;

        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }
        /// <summary>
        /// Método criar uma nova conta
        /// </summary>
        /// <param name="codigoCliente"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ContaResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ContaResponse>> CriarConta(int codigoCliente)
        {
            return Ok(await _contaService.CriarConta(codigoCliente));
        }
        [HttpPatch]
        [Route("{numeroConta}/sacar")]
        [ProducesResponseType(typeof(ContaResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ContaResponse>> Sacar(int numeroConta, double valorSaque)
        {
            return Ok(await _contaService.Sacar(numeroConta, valorSaque));
        }
        [HttpPatch]
        [Route("{numeroConta}/depositar")]
        [ProducesResponseType(typeof(ContaResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ContaResponse>> Depositar(int numeroConta, double valorDeposito)
        {
            return Ok(await _contaService.Depositar(numeroConta, valorDeposito));
        }
        [HttpGet]
        [Route("{numeroConta}")]
        [ProducesResponseType(typeof(ContaResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ContaResponse>> BuscarContaCliente(long numeroConta)
        {
            return Ok(await _contaService.BuscarConta(numeroConta));
        }
    }
}
