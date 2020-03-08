using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioWooza.Models
{
    [Table("PlanoTelefoniaDDDMapping")]
    public class PlanoTelefoniaDDDMapping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid FkPlanoTelefonia { get; set; }

        [ForeignKey("FkPlanoTelefonia")]
        public PlanoTelefonia Plano { get; set; }

        public Guid FkPlanoTelefoniaDDD { get; set; }

        [ForeignKey("FkPlanoTelefoniaDDD")]
        public PlanoTelefoniaDDD DDD { get; set; }
    }
}