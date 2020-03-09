using DesafioWooza.Controllers;
using DesafioWooza.Models;
using DesafioWooza.Services.Interface;
using DesafioWooza.ViewModels;
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
        public void CadastrarPlano_Sucesso()
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

            ContentResult result = retorno as ContentResult;
            Assert.AreEqual(201, result.StatusCode);
        }

        [Test]
        public void CadastrarPlano_TipoPlano_Falha()
        {
            PlanoTelefonia plano = new PlanoTelefonia();

            var retorno = _planoTelefoniaController.Cadastrar(plano);

            ContentResult result = retorno as ContentResult;
            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public void AtualizarPlano_Sucesso()
        {
            PlanoTelefonia plano = new PlanoTelefonia()
            {
                Codigo = "12",
                Minutos = 1300,
                FranquiaInternet = 15,
                Valor = 139.90m,
                Tipo = new PlanoTelefoniaTipo() { Tipo = "Pós" }
            };
            plano.DDDs = new List<PlanoTelefoniaDDD>
            {
                new PlanoTelefoniaDDD() { DDD = "33" }
            };

            var retorno = _planoTelefoniaController.Atualizar(plano);

            ContentResult result = retorno as ContentResult;
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void AtualizarPlano_TipoPlano_Falha()
        {
            PlanoTelefonia plano = new PlanoTelefonia();

            var retorno = _planoTelefoniaController.Atualizar(plano);

            ContentResult result = retorno as ContentResult;
            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public void RemoverPlano_Sucesso()
        {
            PlanoTelefonia plano = new PlanoTelefonia()
            {
                Codigo = "12",
                Minutos = 1300,
                FranquiaInternet = 15,
                Valor = 139.90m,
                Tipo = new PlanoTelefoniaTipo() { Tipo = "Pós" }
            };
            plano.DDDs = new List<PlanoTelefoniaDDD>
            {
                new PlanoTelefoniaDDD() { DDD = "33" }
            };

            var retorno = _planoTelefoniaController.Remover(plano);

            OkObjectResult result = retorno as OkObjectResult;
            Assert.NotNull(result);
        }

        [Test]
        public void RemoverPlano_Falha()
        {
            PlanoTelefonia plano = new PlanoTelefonia();

            var retorno = _planoTelefoniaController.Remover(plano);

            BadRequestObjectResult result = retorno as BadRequestObjectResult;
            Assert.NotNull(result);
        }

        [Test]
        public void ListarPorTipo_Sucesso()
        {
            IList<PlanoTelefonia> retorno = _planoTelefoniaController.ListarPorTipo(new ListarPorTipoViewModel() { Tipo = "Controle", DDD = null });

            Assert.NotNull(retorno);
            Assert.AreEqual(6, retorno.Count);
        }

        [Test]
        public void ListarPorTipo_DDD_Sucesso()
        {
            var retorno = _planoTelefoniaController.ListarPorTipo(new ListarPorTipoViewModel() { Tipo = "Controle", DDD = "11" });

            Assert.NotNull(retorno);
            Assert.AreEqual(1, retorno.Count);
        }

        [Test]
        public void ListarPorOperadora_Sucesso()
        {
            IList<PlanoTelefonia> retorno = _planoTelefoniaController.ListarPorOperadora(new ListarPorOperadoraViewModel() { Operadora = "TIM", DDD = null });

            Assert.NotNull(retorno);
            Assert.AreEqual(3, retorno.Count);
        }

        [Test]
        public void ListarPorOperadora_DDD_Sucesso()
        {
            var retorno = _planoTelefoniaController.ListarPorOperadora(new ListarPorOperadoraViewModel() { Operadora = "TIM", DDD = "11" });

            Assert.NotNull(retorno);
            Assert.AreEqual(1, retorno.Count);
        }

        [Test]
        public void GetPorPlano_Sucesso()
        {
            PlanoTelefonia retorno = _planoTelefoniaController.GetPorPlano("1");

            Assert.NotNull(retorno);
        }
    }
}