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


            throw new NotImplementedException();
        }

        public ReturnObject Atualizar(PlanoTelefonia plano)
        {
            throw new NotImplementedException();
        }

        public ReturnObject Remover(PlanoTelefonia plano)
        {
            throw new NotImplementedException();
        }

        public IList<PlanoTelefonia> ListarPorOperadora(string operadora, string ddd)
        {
            throw new NotImplementedException();
        }

        public PlanoTelefonia GetPorPlano(string plano)
        {
            throw new NotImplementedException();
        }

        public IList<PlanoTelefonia> ListarPorTipo(string tipo, string ddd)
        {
            throw new NotImplementedException();
        }
    }
}
