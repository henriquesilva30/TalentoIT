using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TalentoIT.Entities
{
    [Table("perfil_detalhe")]
    public partial class perfil_detalhe
    {
        [Key]
        public int id_perfil_detalhe { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio;")]
        [StringLength(100)]
        public string titulo_exp { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio;")]
        [StringLength(100)]
        public string nome_empresa { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio no formato XXXX -> números;")]
        [RegularExpression(@"\d{4}$")]
        [StringLength(4)]
        public string ano_inico { get; set; }
        
        [StringLength(4)]
        public string ano_fim { get; set; }
        
        public int? id_perfil_talento { get; set; }

        [ForeignKey(nameof(id_perfil_talento))]
        [InverseProperty(nameof(perfil_talento.perfil_detalhes))]
        public virtual perfil_talento id_perfil_talentoNavigation { get; set; }
    }
}
