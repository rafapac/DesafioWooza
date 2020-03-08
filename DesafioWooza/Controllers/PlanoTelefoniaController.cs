
using DesafioWooza.Models;
using DesafioWooza.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;

namespace DesafioWooza.Controllers
{
    [ApiController]
    [System.Web.Http.Route("api/[controller]")]
    public class PlanoTelefoniaController : ControllerBase
    {

        private readonly ILogger<PlanoTelefoniaController> _logger;
        private readonly IPlanoTelefoniaService _planoTelefoniaService;

        public PlanoTelefoniaController(
            ILogger<PlanoTelefoniaController> logger,
            IPlanoTelefoniaService planoTelefoniaService)
        {
            _logger = logger;
            _planoTelefoniaService = planoTelefoniaService;
        }

        [HttpPost]
        public IActionResult Cadastrar(PlanoTelefonia plano)
        {
            var retorno = _planoTelefoniaService.Cadastrar(plano);

            if (retorno.StatusCode == HttpStatusCode.Created)
                return CreatedAtAction(nameof(GetPorPlano), new { id = plano.Codigo }, plano);
            else
                return BadRequest(retorno.Messages);
        }

        [HttpPut]
        public IActionResult Atualizar(PlanoTelefonia plano)
        {
            var retorno = _planoTelefoniaService.Atualizar(plano);

            if (retorno.StatusCode == HttpStatusCode.OK)
                return Ok(retorno.Messages);
            else
                return BadRequest(retorno.Messages);
        }

        [HttpDelete]
        public IActionResult Remover(PlanoTelefonia plano)
        {
            var retorno = _planoTelefoniaService.Remover(plano);

            if (retorno.StatusCode == HttpStatusCode.OK)
                return Ok(retorno.Messages);
            else
                return BadRequest(retorno.Messages);
        }

        [HttpGet]
        [Route("listarportipo")]
        public IList<PlanoTelefonia> ListarPorTipo(string tipo, string ddd)
        {
            IList<PlanoTelefonia> retorno = null;

            try
            {
                retorno = _planoTelefoniaService.ListarPorTipo(tipo, ddd);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return retorno;
        }

        [HttpGet]
        [Route("listarporoperadora")]
        public IList<PlanoTelefonia> ListarPorOperadora(string operadora, string ddd)
        {
            IList<PlanoTelefonia> retorno = null;

            try
            {
                retorno = _planoTelefoniaService.ListarPorOperadora(operadora, ddd);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return retorno;
        }

        [HttpGet]
        [Route("getporplano")]
        public PlanoTelefonia GetPorPlano(string plano)
        {
            PlanoTelefonia retorno = null;

            try
            {
                retorno = _planoTelefoniaService.GetPorPlano(plano);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return retorno;
        }
    }
}
