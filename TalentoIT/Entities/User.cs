using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace TalentoIT.Entities
{
    [Table("users")]
    public partial class User
    {
        public User()
        {
            Talentos = new HashSet<Perfil_talento>();
            Propostas = new HashSet<Proposta_user>();
            User_skills = new HashSet<User_skill>();
            
        }

        [Key] 
        [Column("id_user")] 
        public int UserId { get; set; }

        [Required]
        [Column("email")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Column("pass")]
        [StringLength(100)]
        public string Password { get; set; }
        
        [Required]
        [Column("nome_user")]
        [StringLength(100)] 
        public string Name { get; set; }
        
        [Required]
        [Column("tipo_user")]
        [StringLength(100)]
        public string Tipo_user { get; set; }

        [Required]
        [Column("morada")]
        [StringLength(100)]
        public string Morada { get; set; }

        [Column("nif")]
        [StringLength(100)] 
        public string Nif { get; set; }

        [InverseProperty(nameof(Perfil_talento.User))]
        public virtual ICollection<Perfil_talento> Talentos { get; set; }
        
        [InverseProperty(nameof(Proposta_user.User))]
        public virtual ICollection<Proposta_user> Propostas { get; set; } 
        
        [InverseProperty(nameof(User_skill.User))]
        public virtual ICollection<User_skill> User_skills { get; set; }
    }
}