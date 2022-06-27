using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TalentoIT.Entities
{
    [Table("perfil_talento")]
    public partial class perfil_talento
    {
        public perfil_talento()
        {
            perfil_detalhes = new HashSet<perfil_detalhe>();
            talento_skills = new HashSet<talento_skill>();
        }

        [Key]
        public int id_perfil_talento { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatorio;")]
        [StringLength(100)]
        public string nome_talento { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatorio;")]
        [RegularExpression(@"\d{1,10}")]
        [StringLength(100)]
        public string preco_hora { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatorio no formato: exemplo@exemplo.ex;")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        [StringLength(100)]
        public string email { get; set; }
        
        [Required]
        [StringLength(100)]
        public string pais { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatorio no formato ativo ou inativo;")]
        [RegularExpression(@"^ativo$|^inativo$")]
        public string flag { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório;")]
        public int? id_user { get; set; }


        [ForeignKey(nameof(id_user))]
        [InverseProperty(nameof(user.perfil_talentos))]
        public virtual user id_userNavigation { get; set; }
        [InverseProperty(nameof(perfil_detalhe.id_perfil_talentoNavigation))]
        public virtual ICollection<perfil_detalhe> perfil_detalhes { get; set; }
        [InverseProperty(nameof(talento_skill.id_perfil_talentoNavigation))]
        public virtual ICollection<talento_skill> talento_skills { get; set; }
    }
}
