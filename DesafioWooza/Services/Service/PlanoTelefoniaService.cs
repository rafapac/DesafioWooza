using DesafioWooza.Models;
using DesafioWooza.Services.Interface;
using System;
using System.Collections.Generic;

namespace DesafioWooza.Services.Service
{
    public class PlanoTelefoniaService : IPlanoTelefoniaService
    {
        public ReturnObject Cadastrar(PlanoTelefonia plano)
        {

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

        public IList<PlanoTelefonia> ListarPorPlano(string plano, string ddd)
        {
            throw new NotImplementedException();
        }

        public IList<PlanoTelefonia> ListarPorTipo(string tipo, string ddd)
        {
            throw new NotImplementedException();
        }
    }
}
