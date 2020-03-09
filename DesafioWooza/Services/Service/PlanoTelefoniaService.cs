using DesafioWooza.Models;
using DesafioWooza.Repositories.Interface;
using DesafioWooza.Services.Interface;
using System;
using System.Collections.Generic;
using System.Net;

namespace DesafioWooza.Services.Service
{
    public class PlanoTelefoniaService : IPlanoTelefoniaService
    {

        private readonly IPlanoTelefoniaRepository _planoTelefoniaRepository;

        public PlanoTelefoniaService(IPlanoTelefoniaRepository planoTelefoniaRepository)
        {
            _planoTelefoniaRepository = planoTelefoniaRepository;
        }

        public ReturnObject Cadastrar(PlanoTelefonia plano)
        {
            ReturnObject retorno = new ReturnObject
            {
                StatusCode = HttpStatusCode.BadRequest,
                Messages = new List<string>()
            };

            PlanoTelefonia planoDB = _planoTelefoniaRepository.GetPlanoPorCodigo(plano.Codigo);

            if (planoDB == null)
            {
                PlanoTelefoniaTipo planoTipoDb = _planoTelefoniaRepository.GetPlanoTipoPorTipo(plano.Tipo.Tipo);

                if (planoTipoDb != null)
                {
                    plano.Tipo = planoTipoDb;

                    _planoTelefoniaRepository.InsertPlanoTelefonia(plano);

                    retorno.StatusCode = HttpStatusCode.Created;
                    retorno.Messages.Add("Plano de telefonia criado com sucesso!");

                }
                else
                {
                    retorno.Messages.Add("Tipo de plano informado não encontrado");
                }
            }
            else
            {
                retorno.Messages.Add("Plano de telefonia já cadastrado");
            }
            return retorno;
        }

        public ReturnObject Atualizar(PlanoTelefonia plano)
        {
            ReturnObject retorno = new ReturnObject
            {
                StatusCode = HttpStatusCode.BadRequest,
                Messages = new List<string>()
            };

            PlanoTelefonia planoDB = _planoTelefoniaRepository.GetPlanoPorCodigo(plano.Codigo);

            if (planoDB != null)
            {
                PlanoTelefoniaTipo planoTipoDb = _planoTelefoniaRepository.GetPlanoTipoPorTipo(plano.Tipo.Tipo);

                if (planoTipoDb != null)
                {
                    planoDB.Codigo = plano.Codigo;
                    planoDB.Minutos = plano.Minutos;
                    planoDB.FranquiaInternet = plano.FranquiaInternet;
                    planoDB.Valor = plano.Valor;
                    planoDB.Tipo = planoTipoDb;
                    planoDB.DDDs = plano.DDDs;
                    planoDB.Operadora = plano.Operadora;

                    _planoTelefoniaRepository.DeleteDDDPorPlano(planoDB);
                    _planoTelefoniaRepository.UpdatePlanoTelefonia(planoDB);

                    retorno.StatusCode = HttpStatusCode.OK;
                    retorno.Messages.Add("Plano de telefonia atualizado com sucesso!");
                }
                else
                {
                    retorno.Messages.Add("Tipo de plano informado não encontrado");
                }
            }
            else
            {
                retorno.Messages.Add("Plano de telefonia não encontrado");
            }
            return retorno;
        }

        public ReturnObject Remover(PlanoTelefonia plano)
        {
            ReturnObject retorno = new ReturnObject
            {
                StatusCode = HttpStatusCode.BadRequest,
                Messages = new List<string>()
            };

            PlanoTelefonia planoDB = _planoTelefoniaRepository.GetPlanoPorCodigo(plano.Codigo);

            if (planoDB != null)
            {
                _planoTelefoniaRepository.DeletePlano(planoDB);
                retorno.StatusCode = HttpStatusCode.OK;
                retorno.Messages.Add("Plano de telefonia removido com sucesso!");
            }
            else
            {
                retorno.Messages.Add("Plano de telefonia não encontrado");
            }
            return retorno;
        }

        public IList<PlanoTelefonia> ListarPorTipo(string tipo, string ddd)
        {
            return _planoTelefoniaRepository.ListarPorTipo(tipo, ddd);
        }

        public IList<PlanoTelefonia> ListarPorOperadora(string operadora, string ddd)
        {
            throw new NotImplementedException();
        }

        public PlanoTelefonia GetPorPlano(string plano)
        {
            throw new NotImplementedException();
        }
    }
}
