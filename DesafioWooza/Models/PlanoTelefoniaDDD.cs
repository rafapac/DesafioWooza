﻿using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioWooza.Models
{
    [Table("PlanoTelefoniaDDD")]
    public class PlanoTelefoniaDDD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Favor informar DDD")]
        [StringLength(2, ErrorMessage = "DDD não pode ser maior que 2 caracteres")]
        public string DDD { get; set; }

        [JsonIgnore]
        public Guid FkPlanoTelefonia { get; set; }

        [ForeignKey("FkPlanoTelefonia")]
        public virtual PlanoTelefonia Plano { get; set; }
    }
}