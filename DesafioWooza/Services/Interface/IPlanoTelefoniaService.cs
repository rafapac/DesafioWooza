using DesafioWooza.Models;
using System.Collections.Generic;

namespace DesafioWooza.Services.Interface
{
    public interface IPlanoTelefoniaService
    {
        ReturnObject Cadastrar(PlanoTelefonia plano);
        ReturnObject Atualizar(PlanoTelefonia plano);
        ReturnObject Remover(PlanoTelefonia plano);
        IList<PlanoTelefonia> ListarPorTipo(string tipo, string ddd);
        IList<PlanoTelefonia> ListarPorOperadora(string operadora, string ddd);
        IList<PlanoTelefonia> ListarPorPlano(string plano, string ddd);
    }
}
