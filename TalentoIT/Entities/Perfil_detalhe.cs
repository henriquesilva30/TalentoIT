using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentoIT.Entities
{
    [Table("perfil_detalhe")]
    public partial class Perfil_detalhe
    {
        public Perfil_detalhe()
        {
            Detalhes = new HashSet<Talento_skill>();
            
        }

        [Key] 
        [Column("id_perfil_detalhe")] 
        public int Perfil_detalheId { get; set; }

        [Required]
        [Column("titulo_exp")]
        [StringLength(100)]
        public string Expr { get; set; }

        [Required]
        [Column("nome_empresa")]
        [StringLength(100)]
        public string Empresa { get; set; }
        
        [Required]
        [Column("ano_inicio")]
        [StringLength(100)] 
        public string Ano_Inicio { get; set; }
        
        [Required]
        [Column("ano_fim")]
        [StringLength(100)]
        public string Ano_Fim { get; set; }

        public int? Perfil_talentoId {  get; set; }

        [ForeignKey(nameof(Perfil_talentoId))]
        [InverseProperty("Perfil_talento")] 
        public virtual Perfil_talento Perfil_talento { get; set; }

        [InverseProperty(nameof(Talento_skill.Perfil_detalhe))]
        public virtual ICollection<Talento_skill> Detalhes { get; set; }


        //  [InverseProperty(nameof(Meal.User))] public virtual ICollection<Meal> Meals { get; set; }
    }
}