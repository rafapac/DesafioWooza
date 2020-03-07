using DesafioWooza.Models;
using System.Collections.Generic;

namespace DesafioWooza.Services.Interface
{
    public interface IPlanoTelefoniaService
    {
        void Cadastrar(PlanoTelefonia plano);
        void Atualizar(PlanoTelefonia plano);
        void Remover(PlanoTelefonia plano);
        IList<PlanoTelefonia> ListarPorTipo(string tipo, string ddd);
        IList<PlanoTelefonia> ListarPorOperadora(string operadora, string ddd);
        IList<PlanoTelefonia> ListarPorPlano(string plano, string ddd);
    }
}
