using DesafioWooza.Controllers;
using DesafioWooza.Models;
using DesafioWooza.Services.Interface;
using DesafioWoozaTest.FakeServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System.Collections.Generic;

namespace DesafioWoozaTest
{
    public class Tests
    {
        private readonly ILogger<PlanoTelefoniaController> _logger;
        PlanoTelefoniaController _planoTelefoniaController;
        IPlanoTelefoniaService _planoTelefoniaService;

        [SetUp]
        public void Setup()
        {
            _planoTelefoniaService = new FakePlanoTelefoniaService();
            _planoTelefoniaController = new PlanoTelefoniaController(_logger, _planoTelefoniaService);
        }

        [Test]
        public void Cadastrar_NovoPlano_Sucesso()
        {
            PlanoTelefonia plano = new PlanoTelefonia()
            {
                Codigo = "25",
                Minutos = 1300,
                FranquiaInternet = 15,
                Valor = 139.90m,
                Tipo = new PlanoTelefoniaTipo() { Tipo = "Pós" }
            };
            plano.DDDs = new List<PlanoTelefoniaDDD>
            {
                new PlanoTelefoniaDDD() { DDD = "33" }
            };

            var retorno = _planoTelefoniaController.Cadastrar(plano);

            Assert.NotNull(retorno);
            CreatedAtActionResult result = retorno as CreatedAtActionResult;

            Assert.NotNull(result);
            Assert.AreEqual(201, result.StatusCode);
        }
    }
}