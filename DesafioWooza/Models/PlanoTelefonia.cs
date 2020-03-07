using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioWooza.Models
{
    public class PlanoTelefonia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public int Minutos { get; set; }
        public int FranquiaInternet { get; set; }
        public decimal Valor { get; set; }
        public PlanoTelefoniaTipo Tipo { get; set; }
        public IList<PlanoTelefoniaDDD> DDDs { get; set; }
    }
}