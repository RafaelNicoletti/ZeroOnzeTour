using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ZeroOnzeTour.Util;

namespace ZeroOnzeTour.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; }

        [Display(Name = "Senha")]
        [Column("Senha")]
        public string Senha { get; set; }

        [Display(Name = "Email")]
        [Column("Email")]
        public string Email { get; set; }
        [Display(Name = "Ativo")]
        [Column("Ativo")]
        public bool Ativo { get; set; }
    }
}
