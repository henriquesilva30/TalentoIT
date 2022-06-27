using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TalentoIT.Entities
{
    public partial class propostum
    {
        public propostum()
        {
            proposta_skills = new HashSet<proposta_skill>();
            proposta_users = new HashSet<proposta_user>();
        }

        [Key]
        public int id_proposta { get; set; }
        [Required(ErrorMessage = "Campo obrigatório;")]
        [StringLength(100)]
        public string nome_proposta { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório;")]
        [StringLength(100)]
        public string tipo_talento { get; set; }
        
        [RegularExpression(@"\d{0,4}$", ErrorMessage = ("A experiência é quantificada em anos;"))]
        [Required(ErrorMessage = ("Campo obrigatório;"))]
        [StringLength(100)]
        public string expr_minima { get; set; }
        [RegularExpression(@"\d{0,4}$", ErrorMessage = ("O total de horas tem de ser um numero inteiro;"))]
        [Required(ErrorMessage = ("Campo obrigatório;"))]
        [StringLength(4)]
        public string total_horas { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório;")]
        [StringLength(100)]
        public string descricao { get; set; }

        [InverseProperty(nameof(proposta_skill.id_propostaNavigation))]
        public virtual ICollection<proposta_skill> proposta_skills { get; set; }
        [InverseProperty(nameof(proposta_user.id_propostaNavigation))]
        public virtual ICollection<proposta_user> proposta_users { get; set; }
    }
}
