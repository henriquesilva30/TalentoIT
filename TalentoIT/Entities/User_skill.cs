using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentoIT.Entities
{
    [Table("talento_skill")]
    public partial class User_skill
    {
        public User_skill()
        {
            //Meals = new HashSet<Meal>();
               
        }
   
        [Key] 
        [Column("id_user_skill")] 
        public int User_skillId { get; set; }
   
   
        public int? SkillId { get; set; }
   
        [ForeignKey(nameof(SkillId))]
        [InverseProperty("Skill")] 
        public virtual Skill Skills { get; set; }
           
       
        public int? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("User")] 
        public virtual User User { get; set; }

        
        
   
   
        //  [InverseProperty(nameof(Meal.User))] public virtual ICollection<Meal> Meals { get; set; }
    }
}