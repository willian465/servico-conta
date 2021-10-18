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
        /// <summary>
        /// Método para sacar de uma conta
        /// </summary>
        /// <param name="numeroConta"></param>
        /// <param name="valorSaque"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{numeroConta}/sacar")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult<ContaResponse>> Sacar(int numeroConta, double valorSaque)
        {
            return Ok(await _contaService.Sacar(numeroConta, valorSaque));
        }
        /// <summary>
        /// Método para depositar em uma conta
        /// </summary>
        /// <param name="numeroConta"></param>
        /// <param name="valorDeposito"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{numeroConta}/depositar")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult<ContaResponse>> Depositar(int numeroConta, double valorDeposito)
        {
            return Ok(await _contaService.Depositar(numeroConta, valorDeposito));
        }
        /// <summary>
        /// Método para buscar uma conta
        /// </summary>
        /// <param name="numeroConta"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{numeroConta}")]
        [ProducesResponseType(typeof(ContaResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ContaResponse>> BuscarContaCliente(long numeroConta)
        {
            return Ok(await _contaService.BuscarConta(numeroConta));
        }
        /// <summary>
        /// Método para deletar uma conta
        /// </summary>
        /// <param name="numeroConta"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{numeroConta}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult<ContaResponse>> DeletarConta(long numeroConta)
        {
            return Ok(await _contaService.DeltetarConta(numeroConta));
        }
    }
}
