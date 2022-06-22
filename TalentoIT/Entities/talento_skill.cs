using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TalentoIT.Entities
{
    [Table("talento_skill")]
    public partial class talento_skill
    {
        [Key]
        public int id_talento_skill { get; set; }
        public int? id_skill { get; set; }
        public int? id_perfil_talento { get; set; }

        [ForeignKey(nameof(id_perfil_talento))]
        [InverseProperty(nameof(perfil_talento.talento_skills))]
        public virtual perfil_talento id_perfil_talentoNavigation { get; set; }
        [ForeignKey(nameof(id_skill))]
        [InverseProperty(nameof(skill.talento_skills))]
        public virtual skill id_skillNavigation { get; set; }
    }
}
