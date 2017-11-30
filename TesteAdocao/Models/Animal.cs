using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteAdocao.Models
{
    [Table("Animais")]
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(50, ErrorMessage = " No máximo 50 caracteres")]
        [Display(Name = "Nome do Produto")]
        public string AnimalNome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = " No mínimo 5 caracteres")]
        [MaxLength(500, ErrorMessage = " No máximo 500 caracteres")]
        [Display(Name = "Descrição do Produto")]
        [DataType(DataType.MultilineText)]
        public string AnimalDescricao { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(50, ErrorMessage = " No máximo 50 caracteres")]
        [Display(Name = "Cor do Produto")]
        public string AnimalCor { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(50, ErrorMessage = " No máximo 50 caracteres")]
        [Display(Name = "Cor do Produto")]
        public string AnimalRaca { get; set; }
        public string AnimalImagem { get; set; } //asp:FileUpload
        public Categoria Categoria { get; set; } //asp:DropDownList
        public int CategoriaId { get; set; }

    }
}