using DesafioWooza.Models;
using DesafioWooza.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace DesafioWoozaTest.FakeServices
{
    public class FakePlanoTelefoniaService : IPlanoTelefoniaService
    {

        private readonly List<PlanoTelefonia> _planosTelefonia;
        private readonly PlanoTelefoniaTipo[] _tiposPlano = new PlanoTelefoniaTipo[3] { new PlanoTelefoniaTipo() { Id = Guid.NewGuid(), Tipo = "Controle" },
                                                                                        new PlanoTelefoniaTipo() { Id = Guid.NewGuid(), Tipo = "Pós" },
                                                                                        new PlanoTelefoniaTipo() { Id = Guid.NewGuid(), Tipo = "Pré" } };

        public FakePlanoTelefoniaService()
        {
            //Simulação de planos na base - Início
            List<PlanoTelefonia> planos = new List<PlanoTelefonia>();

            for (int i = 1; i <= 12; i++)
            {
                string operadora = string.Empty;
                PlanoTelefoniaTipo tipoPlano = new PlanoTelefoniaTipo();

                if (1 <= i && i <= 3)
                {
                    operadora = "TIM";
                    tipoPlano = _tiposPlano[0];
                }
                else if (4 <= i && i <= 6)
                {
                    tipoPlano = _tiposPlano[0];
                    operadora = "CLARO";
                }
                else if (7 <= i && i <= 9)
                {
                    tipoPlano = _tiposPlano[1];
                    operadora = "OI";
                }
                else if (10 <= i && i <= 12)
                {
                    tipoPlano = _tiposPlano[2];
                    operadora = "VIVO";
                }

                PlanoTelefonia plano = new PlanoTelefonia()
                {
                    Id = Guid.NewGuid(),
                    Codigo = i.ToString(),
                    Minutos = i * 100,
                    FranquiaInternet = i + 2,
                    Valor = 19.90m + (i * 10),
                    Tipo = tipoPlano,
                    Operadora = operadora
                };

                List<PlanoTelefoniaDDD> DDDs = new List<PlanoTelefoniaDDD>();

                for (int j = 1; j <= 3; j++)
                {
                    PlanoTelefoniaDDD ddd = new PlanoTelefoniaDDD()
                    {
                        Id = Guid.NewGuid(),
                        DDD = (10 + i).ToString()
                    };
                    DDDs.Add(ddd);
                }

                plano.DDDs = DDDs;
                planos.Add(plano);
            }

            _planosTelefonia = planos;
            //Simulação de planos na base - Fim
        }

        public ReturnObject Cadastrar(PlanoTelefonia plano)
        {
            ReturnObject retorno = new ReturnObject
            {
                StatusCode = HttpStatusCode.BadRequest
            };

            if (_planosTelefonia.Where(x => x.Codigo.Equals(plano.Codigo, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault() == null)
            {
                if (plano.Tipo != null)
                {
                    PlanoTelefoniaTipo tipo = _tiposPlano.Where(x => x.Tipo.Equals(plano.Tipo.Tipo, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                    if (tipo != null)
                    {
                        _planosTelefonia.Add(plano);
                        retorno.StatusCode = HttpStatusCode.Created;
                    }
                }
            }
            return retorno;
        }

        public ReturnObject Atualizar(PlanoTelefonia plano)
        {
            ReturnObject retorno = new ReturnObject
            {
                StatusCode = HttpStatusCode.BadRequest
            };

            PlanoTelefonia planoTelefonia = _planosTelefonia.Where(x => x.Codigo.Equals(plano.Codigo, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            if (planoTelefonia != null)
            {
                if (plano.Tipo != null)
                {
                    PlanoTelefoniaTipo tipo = _tiposPlano.Where(x => x.Tipo.Equals(plano.Tipo.Tipo, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                    if (tipo != null)
                    {
                        plano.Tipo = tipo;
                        _planosTelefonia[_planosTelefonia.FindIndex(x => x.Codigo.Equals(plano.Codigo, StringComparison.InvariantCultureIgnoreCase))] = plano;
                        retorno.StatusCode = HttpStatusCode.OK;
                    }
                }
            }

            return retorno;
        }

        public ReturnObject Remover(PlanoTelefonia plano)
        {
            ReturnObject retorno = new ReturnObject
            {
                StatusCode = HttpStatusCode.BadRequest
            };

            PlanoTelefonia planoTelefonia = _planosTelefonia.Where(x => x.Codigo.Equals(plano.Codigo, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            if (planoTelefonia != null)
            {
                _planosTelefonia.Remove(planoTelefonia);
                retorno.StatusCode = HttpStatusCode.OK;
            }

            return retorno;
        }

        public IList<PlanoTelefonia> ListarPorTipo(string tipo, string ddd)
        {
            if (string.IsNullOrWhiteSpace(ddd))
                return _planosTelefonia.Where(x => x.Tipo.Tipo.Equals(tipo, StringComparison.InvariantCultureIgnoreCase)).ToList();
            else
                return _planosTelefonia.Where(x => x.Tipo.Tipo.Equals(tipo, StringComparison.InvariantCultureIgnoreCase) && x.DDDs.Where(y => y.DDD.Equals(ddd)).FirstOrDefault() != null).ToList();

        }

        public IList<PlanoTelefonia> ListarPorOperadora(string operadora, string ddd)
        {
            if (string.IsNullOrWhiteSpace(ddd))
                return _planosTelefonia.Where(x => x.Operadora.Equals(operadora, StringComparison.InvariantCultureIgnoreCase)).ToList();
            else
                return _planosTelefonia.Where(x => x.Operadora.Equals(operadora, StringComparison.InvariantCultureIgnoreCase) && x.DDDs.Where(y => y.DDD.Equals(ddd)).FirstOrDefault() != null).ToList();
        }
        public IList<PlanoTelefonia> ListarPorPlano(string plano, string ddd)
        {
            if (string.IsNullOrWhiteSpace(ddd))
                return _planosTelefonia.Where(x => x.Codigo.Equals(plano, StringComparison.InvariantCultureIgnoreCase) && x.DDDs.Where(y => y.DDD.Equals(ddd)).FirstOrDefault() != null).ToList();
            else
                return _planosTelefonia.Where(x => x.Codigo.Equals(plano, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }
    }
}
