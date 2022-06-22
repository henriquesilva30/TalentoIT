using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TalentoIT.Entities
{
    [Table("talento_skill")]
    public partial class Talento_skill
    {
        public Talento_skill()
        {
            //Meals = new HashSet<Meal>();
               
        }
   
        [Key] 
        [Column("id_talento_skill")] 
        public int Proposta_skillId { get; set; }
   
   
        public int? SkillId { get; set; }
   
        [ForeignKey(nameof(SkillId))]
        [InverseProperty("Skill")] 
        public virtual Skill Skills { get; set; }
           
        public int? Perfil_detalheId { get; set; }
              
        [ForeignKey(nameof(Perfil_detalheId))]
        [InverseProperty("Perfil_detalhe")] 
        public virtual Perfil_detalhe Perfil_detalhe { get; set; }

        
        
   
   
        //  [InverseProperty(nameof(Meal.User))] public virtual ICollection<Meal> Meals { get; set; }
    }
}