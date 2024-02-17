using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ZeroOnzeTour.Util;

namespace ZeroOnzeTour.Models
{
    [Table("ImagensTour")]
    public class ImagensTour
    {
        [Key]
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Id Viagem")]
        [Column("IdViagem")]
        public int IdViagem { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Descrição")]
        [Column("Descricao")]
        public string Descricao { get; set; }

        [Display(Name = "Foto")]
        [Column("Foto")]
        public string Foto { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Tipo")]
        [Column("TipoImagem")]
        public TipoImagem TipoImagem { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Ordem")]
        [Column("Ordem")]
        public int? Ordem { get; set; }

        [Display(Name = "Ativo")]
        [Column("Ativo")]
        public bool Ativo { get; set; }



    }
}
