
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TalentoIT.Entities
{
         [Table("proposta_user")]
         public partial class Proposta_user
         {
             public Proposta_user()
             {
                 //Meals = new HashSet<Meal>();
                 
             }
     
             [Key] 
             [Column("id_proposta_user")] 
             public int Proposta_userId { get; set; }
 
             public int? UserId { get; set; }
             [ForeignKey(nameof(UserId))]
             [InverseProperty("User")] 
             public virtual User User { get; set; }
            
            public int? PropostaId { get; set; }
            [ForeignKey(nameof(PropostaId))]
            [InverseProperty("Proposta")] 
            public virtual Proposta Proposta { get; set; }
     
     
     
             //  [InverseProperty(nameof(Meal.User))] public virtual ICollection<Meal> Meals { get; set; }
         }
}