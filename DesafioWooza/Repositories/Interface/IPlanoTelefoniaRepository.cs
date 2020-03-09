using DesafioWooza.Models;

namespace DesafioWooza.Repositories.Interface
{
    public interface IPlanoTelefoniaRepository
    {
        PlanoTelefonia GetPlanoPorCodigo(string codigo);
        PlanoTelefoniaTipo GetPlanoTipoPorTipo(string tipo);
        PlanoTelefoniaDDD GetPlanoDDDPorDDD(string ddd);
        void InsertPlanoTelefoniaDDD(PlanoTelefoniaDDD ddd);
        void InsertPlanoTelefonia(PlanoTelefonia plano);
    }
}
