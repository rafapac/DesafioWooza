
using DesafioWooza.Models;
using DesafioWooza.Services.Interface;
using DesafioWooza.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;

namespace DesafioWooza.Controllers
{
    [ApiController]
    [Route("api/")]
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
        [Route("cadastrar")]
        public IActionResult Cadastrar(PlanoTelefonia plano)
        {
            var retorno = _planoTelefoniaService.Cadastrar(plano);

            return new ContentResult
            {
                Content = retorno.Messages != null ? string.Join("\n", retorno.Messages) : string.Empty,
                ContentType = "text/plain",
                StatusCode = (int)retorno.StatusCode
            };
        }

        [HttpPost]
        [Route("atualizar")]
        public IActionResult Atualizar(PlanoTelefonia plano)
        {
            var retorno = _planoTelefoniaService.Atualizar(plano);

            return new ContentResult
            {
                Content = retorno.Messages != null ? string.Join("\n", retorno.Messages) : string.Empty,
                ContentType = "text/plain",
                StatusCode = (int)retorno.StatusCode
            };
        }

        [HttpPost]
        [Route("remover")]
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
        public IList<PlanoTelefonia> ListarPorTipo(ListarPorTipoViewModel model)
        {
            IList<PlanoTelefonia> retorno = null;

            try
            {
                retorno = _planoTelefoniaService.ListarPorTipo(model.Tipo, model.DDD);
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
        public IList<PlanoTelefonia> ListarPorOperadora(ListarPorOperadoraViewModel model)
        {
            IList<PlanoTelefonia> retorno = null;

            try
            {
                retorno = _planoTelefoniaService.ListarPorOperadora(model.Operadora, model.DDD);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return retorno;
        }

        [HttpGet]
        [Route("getporcodigo")]
        public PlanoTelefonia GetPorCodigo(GetPorCodigoViewModel plano)
        {
            PlanoTelefonia retorno = null;

            try
            {
                retorno = _planoTelefoniaService.GetPorCodigo(plano.Codigo);
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
