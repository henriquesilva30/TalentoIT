using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentoIT.Entities
{
  
        [Table("skills")]
        public partial class Skill
        {
            public Skill()
            {
                Skills = new HashSet<Proposta_skill>();
                User_skills = new HashSet<User_skill>();
            
            }

            [Key] 
            [Column("id_skill")] public int SkillId { get; set; }

            [Required]
            [Column("nome_skill")]
            [StringLength(100)]
            public string Nome { get; set; }

            [Required]
            [Column("area")]
            [StringLength(100)]
            public string Area { get; set; }
            
            [InverseProperty(nameof(Proposta_skill.Skills))]
            public virtual ICollection<Proposta_skill> Skills { get; set; }
            
            [InverseProperty(nameof(User_skill.Skills))]
            public virtual ICollection<User_skill> User_skills { get; set; }
        
           

            //  [InverseProperty(nameof(Meal.User))] public virtual ICollection<Meal> Meals { get; set; }
        }
    
}