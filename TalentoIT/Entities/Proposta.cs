using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentoIT.Entities
{
    [Table("proposta")]
    public partial class Proposta
    {
        public Proposta()
        {
            //Meals = new HashSet<Meal>();
            
        }

        [Key] 
        [Column("id_proposta")] public int PropostaId { get; set; }

        [Required]
        [Column("nome_proposta")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [Column("tipo_talento")]
        [StringLength(100)]
        public string Tipo_Talento { get; set; }
        
        [Required]
        [Column("expr_minima")]
        [StringLength(100)] 
        public string Expr_m { get; set; }
        
        [Required]
        [Column("total_horas")]
        [StringLength(100)]
        public string Total_h { get; set; }

        [Required]
        [Column("descricao")]
        [StringLength(100)]
        public string Descricao { get; set; }

        //  [InverseProperty(nameof(Meal.User))] public virtual ICollection<Meal> Meals { get; set; }
    }
}