using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ZeroOnzeTour.Util;

namespace ZeroOnzeTour.Models
{
    [Table("Contrato")]
    public class Contrato
    {
        [Key]
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }


        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Contrato")]
        [Column("Texto")]
        public string Texto { get; set; }


        [Display(Name = "Ativo")]
        [Column("Ativo")]
        public bool Ativo { get; set; }

    }
}
