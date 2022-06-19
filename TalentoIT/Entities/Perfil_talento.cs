using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentoIT.Entities
{
    [Table("perfil_talento")]
    public partial class Perfil_talento
    {
        public Perfil_talento()
        {
            //Meals = new HashSet<Meal>();
            
        }

        [Key] 
        [Column("id_perfil_talento")] public int Perfil_talentoId { get; set; }

        [Required]
        [Column("nome_talento")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [Column("preco_hora")]
        [StringLength(100)]
        public string Preco_h { get; set; }
        
        [Required]
        [Column("email")]
        [StringLength(100)] 
        public string Email { get; set; }
        
        [Required]
        [Column("flag")]
        [StringLength(100)]
        public string Flag { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))] 
        
        [InverseProperty("User")] 
        public virtual User User { get; set; }


        //  [InverseProperty(nameof(Meal.User))] public virtual ICollection<Meal> Meals { get; set; }
    }
}