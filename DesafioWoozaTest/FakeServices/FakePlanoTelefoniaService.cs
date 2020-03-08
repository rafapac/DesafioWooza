using DesafioWooza.Models;
using DesafioWooza.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioWoozaTest.FakeServices
{
    public class FakePlanoTelefoniaService : IPlanoTelefoniaService
    {

        private readonly List<PlanoTelefonia> _planosTelefonia;
        private readonly PlanoTelefoniaTipo[] _tiposPlano = new PlanoTelefoniaTipo[3] { new PlanoTelefoniaTipo() { Id = new Guid(), Tipo = "Controle" },
                                                                                        new PlanoTelefoniaTipo() { Id = new Guid(), Tipo = "Pós" },
                                                                                        new PlanoTelefoniaTipo() { Id = new Guid(), Tipo = "Pré" } };

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
                } else if (4 <= i && i <= 6)
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
                    Id = new Guid(),
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
                        Id = new Guid(),
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

        public void Cadastrar(PlanoTelefonia plano)
        {

        }

        public void Atualizar(PlanoTelefonia plano)
        {

        }

        public void Remover(PlanoTelefonia plano)
        {

        }

        public IList<PlanoTelefonia> ListarPorTipo(string tipo, string ddd)
        {
            return _planosTelefonia.Where(x => x.Tipo.Tipo.Equals(tipo) && x.DDDs.Where(y => y.DDD.Equals(ddd)).FirstOrDefault() != null).ToList();
        }

        public IList<PlanoTelefonia> ListarPorOperadora(string operadora, string ddd)
        {
            return _planosTelefonia.Where(x => x.Operadora.Equals(operadora) && x.DDDs.Where(y => y.DDD.Equals(ddd)).FirstOrDefault() != null).ToList();
        }
        public IList<PlanoTelefonia> ListarPorPlano(string plano, string ddd)
        {
            return _planosTelefonia.Where(x => x.Codigo.Equals(plano) && x.DDDs.Where(y => y.DDD.Equals(ddd)).FirstOrDefault() != null).ToList();
        }
    }
}
