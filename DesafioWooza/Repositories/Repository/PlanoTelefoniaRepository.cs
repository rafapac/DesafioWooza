using DesafioWooza.Models;
using DesafioWooza.Repositories.Interface;
using System.Linq;

namespace DesafioWooza.Repositories.Repository
{
    public class PlanoTelefoniaRepository : IPlanoTelefoniaRepository
    {

        private readonly AppDbContext _db;
        public PlanoTelefoniaRepository(AppDbContext db)
        {
            _db = db;
        }

        public PlanoTelefonia GetPlanoPorCodigo(string codigo)
        {
            return _db.PlanoTelefonia.Where(x => x.Codigo.Equals(codigo)).FirstOrDefault();
        }

        public PlanoTelefoniaTipo GetPlanoTipoPorTipo(string tipo)
        {
            return _db.PlanoTelefoniaTipo.Where(x => x.Tipo.Equals(tipo)).FirstOrDefault();
        }

        public PlanoTelefoniaDDD GetPlanoDDDPorDDD(string ddd)
        {
            return _db.PlanoTelefoniaDDD.Where(x => x.DDD.Equals(ddd)).FirstOrDefault();
        }

        public void InsertPlanoTelefoniaDDD(PlanoTelefoniaDDD ddd)
        {
            _db.PlanoTelefoniaDDD.Add(ddd);
            _db.SaveChanges();
        }

        public void InsertPlanoTelefonia(PlanoTelefonia plano)
        {
            _db.PlanoTelefonia.Add(plano);
            _db.SaveChanges();
        }

        public void DeleteDDDPorPlano(PlanoTelefonia plano)
        {
            _db.PlanoTelefoniaDDD.RemoveRange(_db.PlanoTelefoniaDDD.Where(x => x.FkPlanoTelefonia == plano.Id));
            _db.SaveChanges();
        }

        public void UpdatePlanoTelefonia(PlanoTelefonia plano)
        {
            _db.PlanoTelefonia.Update(plano);
            _db.SaveChanges();
        }
    }
}
