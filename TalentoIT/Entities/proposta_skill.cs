using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TalentoIT.Entities
{
    [Table("proposta_skill")]
    public partial class proposta_skill
    {
        [Key]
        public int id_proposta_skill { get; set; }
        public int? id_skill { get; set; }
        public int? id_proposta { get; set; }

        [ForeignKey(nameof(id_proposta))]
        [InverseProperty(nameof(propostum.proposta_skills))]
        public virtual propostum id_propostaNavigation { get; set; }
        [ForeignKey(nameof(id_skill))]
        [InverseProperty(nameof(skill.proposta_skills))]
        public virtual skill id_skillNavigation { get; set; }
    }
}
