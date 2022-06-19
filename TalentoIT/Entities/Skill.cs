using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentoIT.Entities
{
  
        [Table("skills")]
        public partial class Skill
        {
            public Skill()
            {
                //Meals = new HashSet<Meal>();
            
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
        

            //  [InverseProperty(nameof(Meal.User))] public virtual ICollection<Meal> Meals { get; set; }
        }
    
}