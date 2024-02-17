using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using ZeroOnzeTour.Util;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;

namespace ZeroOnzeTour.Models
{
    [Table("ViagemTour")]
    public class ViagemTour
    {
        [Key]
        [Display(Name = "Id")]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Tutilo")]
        [Column("Tutilo")]
        public string Tutilo { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "SubTitulo")]
        [Column("SubTitulo")]
        public string SubTitulo { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Incluso")]
        [Column("Incluso")]
        public string Incluso { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Não incluso")]
        [Column("NaoIncluso")]
        public string NaoIncluso { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Frase Final")]
        [Column("FraseFinal")]
        public string FraseFinal { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Data")]
        [Column("Data")]
        public string Data { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Destaque")]
        [Column("Destaque")]
        public string Destaque { get; set; }


        [Display(Name = "Ordem")]
        [Column("Ordem")]
        public int? Ordem { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Frase destaque")]
        [Column("FraseDestaque")]
        public string FraseDestaque { get; set; }

        [Display(Name = "Pais")]
        [Column("Pais")]
        public string Pais { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Cidade")]
        [Column("Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Data da Viagem")]
        [Column("DataViagem")]
        public string DataViagem { get; set; }

        [Display(Name = "a partir de")]
        [Column("Valor")]
        public string Valor { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Descrição")]
        [Column("Descricao")]
        public string Descricao { get; set; }

        [Display(Name = "Obs Investimento")]
        [Column("ObsInvestimento")]
        public string ObsInvestimento { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Valor Principal")]
        [Column("ValorPrincipal")]
        public string ValorPrincipal { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [Display(Name = "Descrição do Roteiro")]
        [Column("DescricaoRoteiro")]
        public string DescricaoRoteiro { get; set; }

        [Display(Name = "Ativo")]
        [Column("Ativo")]
        public bool Ativo { get; set; }
        //public virtual List<ImagensTour> ImagensTour { get; set; }

    }
}
