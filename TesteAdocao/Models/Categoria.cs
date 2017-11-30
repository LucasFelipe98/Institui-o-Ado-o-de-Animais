using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteAdocao.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(60, ErrorMessage = " No máximo 60 caracteres")]
        [Display(Name = "Nome da Categoria")]
        public string CategoriaNome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = " No mínimo 5 caracteres")]
        [MaxLength(500, ErrorMessage = " No máximo 500 caracteres")]
        [Display(Name = "Descrição da Categoria")]
        [DataType(DataType.MultilineText)]
        public string CategoriaDescricao { get; set; }
        public List<Animal> Animais { get; set; }
        public override string ToString()
        {
            return CategoriaNome;
        }
    }
}