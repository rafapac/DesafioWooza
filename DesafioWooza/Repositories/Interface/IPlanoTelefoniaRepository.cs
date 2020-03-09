using DesafioWooza.Models;
using System.Collections.Generic;

namespace DesafioWooza.Repositories.Interface
{
    public interface IPlanoTelefoniaRepository
    {
        PlanoTelefonia GetPlanoPorCodigo(string codigo);
        PlanoTelefoniaTipo GetPlanoTipoPorTipo(string tipo);
        PlanoTelefoniaDDD GetPlanoDDDPorDDD(string ddd);
        void InsertPlanoTelefoniaDDD(PlanoTelefoniaDDD ddd);
        void InsertPlanoTelefonia(PlanoTelefonia plano);
        void DeleteDDDPorPlano(PlanoTelefonia plano);
        void UpdatePlanoTelefonia(PlanoTelefonia plano);
        void DeletePlano(PlanoTelefonia plano);
        IList<PlanoTelefonia> ListarPorTipo(string tipo, string ddd);
        IList<PlanoTelefonia> ListarPorOperadora(string operadora, string ddd);
    }
}
