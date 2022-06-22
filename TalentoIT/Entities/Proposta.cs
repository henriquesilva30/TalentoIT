using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentoIT.Entities
{
    [Table("proposta")]
    public partial class Proposta
    {
        public Proposta()
        {
            Propostas = new HashSet<Proposta_skill>();
            PropostasUser = new HashSet<Proposta_user>();

            
        }

        [Key] 
        [Column("id_proposta")] public int UserID { get; set; }

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
        
        [InverseProperty(nameof(Proposta_skill.Proposta))]
        public virtual ICollection<Proposta_skill> Propostas { get; set; }
        
           [InverseProperty(nameof(Proposta_user.Proposta))]
        public virtual ICollection<Proposta_user> PropostasUser  { get; set; }
       

        //  [InverseProperty(nameof(Meal.User))] public virtual ICollection<Meal> Meals { get; set; }
    }
}