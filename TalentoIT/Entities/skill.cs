using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TalentoIT.Entities
{
    [Table("skills")]
    public partial class skill
    {
        public skill()
        {
            proposta_skills = new HashSet<proposta_skill>();
            talento_skills = new HashSet<talento_skill>();
            user_skills = new HashSet<user_skill>();
        }

        [Key]
        public int id_skill { get; set; }
        [Required]
        [StringLength(100)]
        public string nome_skill { get; set; }
        [Required]
        [StringLength(100)]
        public string area { get; set; }

        [InverseProperty(nameof(proposta_skill.id_skillNavigation))]
        public virtual ICollection<proposta_skill> proposta_skills { get; set; }
        [InverseProperty(nameof(talento_skill.id_skillNavigation))]
        public virtual ICollection<talento_skill> talento_skills { get; set; }
        [InverseProperty(nameof(user_skill.id_skillNavigation))]
        public virtual ICollection<user_skill> user_skills { get; set; }
    }
}
