using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioWooza.Models
{
    [Table("PlanoTelefonia")]
    public class PlanoTelefonia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Favor informar código do plano")]
        [StringLength(50, ErrorMessage = "Código do plano não pode ser maior que 50 caracteres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Favor informar minutos do plano")]
        [Range(1, 999999, ErrorMessage = "Favor informar um valor válido para minutos do plano (1 - 999999)")]
        public int Minutos { get; set; }

        [Required(ErrorMessage = "Favor informar franquia de internet do plano")]
        [Range(1, 999999, ErrorMessage = "Favor informar um valor válido para franquia de internet do plano (1 - 999999)")]
        public int FranquiaInternet { get; set; }

        [Required(ErrorMessage = "Favor informar valor do plano")]
        [Range(1, 999999.99, ErrorMessage = "Favor informar um valor válido para valor do plano (1 - 999999,99)")]
        public decimal Valor { get; set; }

        public Guid FkPlanoTelefoniaTipo { get; set; }

        [ForeignKey("FkPlanoTelefoniaTipo")]
        [Required(ErrorMessage = "Favor informar tipo do plano")]
        public PlanoTelefoniaTipo Tipo { get; set; }

        [Required(ErrorMessage = "Favor informar operadora do plano")]
        [StringLength(50, ErrorMessage = "Operadora do plano não pode ser maior que 50 caracteres")]
        public string Operadora { get; set; }

        public ICollection<PlanoTelefoniaDDD> DDDs { get; set; }
    }
}