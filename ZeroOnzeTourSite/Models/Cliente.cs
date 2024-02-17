using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ZeroOnzeTour.Util;
using System;

namespace ZeroOnzeTourSite.Models
{
    public class Cliente
    {
        [Key]
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }


        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nomr { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "RG")]
        [Column("RG")]
        public string RG { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Telefone")]
        [Column("Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Data de Nascimento")]
        [Column("DataNascimento")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Email")]
        [Column("Email")]
        public string Email { get; set; }

        [Column("ViagemId")]
        public string ViagemId { get; set; }

        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; }


        [Display(Name = "Termo de Aceite")]
        [Column("TermoAceite")]
        public bool TermoAceite { get; set; }
    }
}
