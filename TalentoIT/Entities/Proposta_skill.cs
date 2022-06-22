using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TalentoIT.Entities
{
       [Table("proposta_skill")]
       public partial class Proposta_skill
       {
           public Proposta_skill()
           {
               //Meals = new HashSet<Meal>();
               
           }
   
           [Key] 
           [Column("id_proposta_skill")] 
           public int Proposta_skillId { get; set; }
   
   
           public int? SkillId { get; set; }
   
           [ForeignKey(nameof(SkillId))]
           [InverseProperty("Skill")] 
           public virtual Skill Skills { get; set; }
           
           public int? PropostaId { get; set; }
              
           [ForeignKey(nameof(PropostaId))]
           [InverseProperty("Proposta")] 
           public virtual Proposta Proposta  { get; set; }
   
   
           //  [InverseProperty(nameof(Meal.User))] public virtual ICollection<Meal> Meals { get; set; }
       }
}