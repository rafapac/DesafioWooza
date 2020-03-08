﻿
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
                return CreatedAtAction(nameof(ListarPorPlano), new { id = plano.Codigo }, plano);
            else
                return BadRequest();
        }

        [HttpPut]
        public void Atualizar(PlanoTelefonia plano)
        {
            try
            {
                _planoTelefoniaService.Atualizar(plano);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }

        [HttpDelete]
        public void Remover(PlanoTelefonia plano)
        {
            try
            {
                _planoTelefoniaService.Remover(plano);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }

        [HttpGet]
        [Route("listarportipo")]
        public IEnumerable<PlanoTelefonia> ListarPorTipo(string tipo, string ddd)
        {
            IList<PlanoTelefonia> retorno = new List<PlanoTelefonia>();

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
        public IEnumerable<PlanoTelefonia> ListarPorOperadora(string operadora, string ddd)
        {
            IList<PlanoTelefonia> retorno = new List<PlanoTelefonia>();

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
        [Route("listarporplano")]
        public IEnumerable<PlanoTelefonia> ListarPorPlano(string plano, string ddd)
        {
            IList<PlanoTelefonia> retorno = new List<PlanoTelefonia>();

            try
            {
                retorno = _planoTelefoniaService.ListarPorPlano(plano, ddd);
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
