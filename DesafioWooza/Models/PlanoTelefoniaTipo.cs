using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioWooza.Models
{
    [Table("PlanoTelefoniaTipo")]
    public class PlanoTelefoniaTipo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Favor informar tipo")]
        [StringLength(50, ErrorMessage = "Tipo não pode ser maior que 50 caracteres")]
        public string Tipo { get; set; }
    }
}