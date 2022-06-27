using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TalentoIT.Entities
{
    [Table("clientes")]
    public partial class clientes
    {
        [Key]
        public int id_cliente { get; set; }
        
        [StringLength(100)]
        [Required(ErrorMessage = "Campo obrigatorio;")]
        public string nome { get; set; }
        
        [StringLength(9)]
        [Required(ErrorMessage = "Campo obrigatorio;")]
        public string nif { get; set; }
        
        [Required(ErrorMessage = "Email precisa de estar no formato: exemplo@exemplo.ex;")]
        [StringLength(100)]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]

        public string email { get; set; }

    }
}
