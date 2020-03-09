using System.ComponentModel.DataAnnotations;

namespace DesafioWooza.ViewModels
{
    public class ListarPorOperadoraViewModel
    {
        [Required(ErrorMessage = "Favor informar tipo do plano")]
        [StringLength(50, ErrorMessage = "Tipo do plano não pode ser maior que 50 caracteres")]
        public string Operadora { get; set; }

        [StringLength(2, ErrorMessage = "DDD não pode ser maior que 2 caracteres")]
        public string DDD { get; set; }
    }
}