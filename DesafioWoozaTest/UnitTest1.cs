using DesafioWooza.Controllers;
using DesafioWooza.Models;
using DesafioWooza.Services.Interface;
using DesafioWoozaTest.FakeServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;

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
        public void Cadastrar_NovoPlano_Ok()
        {
            PlanoTelefonia plano = new PlanoTelefonia()
            {
                Codigo = "13",
                Minutos = 1300,
                FranquiaInternet = 15,
                Valor = 139.90m,
                Tipo = new PlanoTelefoniaTipo() { Id = new Guid(), Tipo = tipoPlano }
            };
        }
    }
}