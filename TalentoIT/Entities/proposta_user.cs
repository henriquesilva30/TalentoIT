using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TalentoIT.Entities
{
    [Table("proposta_user")]
    public partial class proposta_user
    {
        [Key]
        public int id_proposta_user { get; set; }
        public int? id_user { get; set; }
        public int? id_proposta { get; set; }

        [ForeignKey(nameof(id_proposta))]
        [InverseProperty(nameof(propostum.proposta_users))]
        public virtual propostum id_propostaNavigation { get; set; }
        [ForeignKey(nameof(id_user))]
        [InverseProperty(nameof(user.proposta_users))]
        public virtual user id_userNavigation { get; set; }
    }
}
