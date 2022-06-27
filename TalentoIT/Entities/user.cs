using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TalentoIT.Entities
{
    public partial class user
    {
        public user()
        {
            perfil_talentos = new HashSet<perfil_talento>();
            proposta_users = new HashSet<proposta_user>();
            user_skills = new HashSet<user_skill>();
        }

        [Key]
        public int id_user { get; set; }
        [Required(ErrorMessage = "Email precisa de estar no formato: exemplo@exemplo.ex;")]
        [StringLength(100)]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        
        public string email { get; set; }
        [Required(ErrorMessage = "Password necessita de um cumprimento de pelo menos 4 caractéres e pelo menos 1 letra e 1 numero;")]
        [StringLength(100)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{4,}$")]
        
        public string pass { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Campo obrigatorio;")]
        public string nome_user { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio;")]
        [StringLength(100)]
        public string tipo_user { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio;")]
        [StringLength(100)]
        public string morada { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio;")]
        [StringLength(100)]
        public string nif { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio;")]
        public string media_horas { get; set; }
        

        [InverseProperty(nameof(perfil_talento.id_userNavigation))]
        public virtual ICollection<perfil_talento> perfil_talentos { get; set; }
        [InverseProperty(nameof(proposta_user.id_userNavigation))]
        public virtual ICollection<proposta_user> proposta_users { get; set; }
        [InverseProperty(nameof(user_skill.id_userNavigation))]
        public virtual ICollection<user_skill> user_skills { get; set; }
    }
}
