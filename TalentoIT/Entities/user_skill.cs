using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TalentoIT.Entities
{
    [Table("user_skill")]
    public partial class user_skill
    {
        [Key]
        public int id_user_skill { get; set; }
        public int? id_skill { get; set; }
        public int? id_user { get; set; }

        [ForeignKey(nameof(id_skill))]
        [InverseProperty(nameof(skill.user_skills))]
        public virtual skill id_skillNavigation { get; set; }
        [ForeignKey(nameof(id_user))]
        [InverseProperty(nameof(user.user_skills))]
        public virtual user id_userNavigation { get; set; }
    }
}
