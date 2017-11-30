using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteAdocao.Models
{
    [Table("Instituicoes")]
    public class Instituicao
    {
        [Key]
        public int InstituicaoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = " No mínimo 5 caracteres")]
        [MaxLength(15, ErrorMessage = " No máximo 15 caracteres")]
        [Display(Name = "Login da Instituicao")]
        public string InstituicaoLogin { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = " No mínimo 5 caracteres")]
        [MaxLength(18, ErrorMessage = " 18")]
        [Display(Name = "Senha da Instituicao")]
        [ScaffoldColumn(false)]
        [DataType(DataType.Password)]
        public string InstituicaoSenha { get; set; }
        [ScaffoldColumn(false)]
        public int? Status { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(50, ErrorMessage = " No máximo 50 caracteres")]
        [Display(Name = "Nome da Instituicao")]
        public string InstituicaoNome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(10, ErrorMessage = " No mínimo 10 caracteres")]
        [MaxLength(10, ErrorMessage = " No máximo 10 caracteres")]
        [Display(Name = "Telefone da Instituicao")]
        public string InstituicaoTelefone { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = " No mínimo 13 caracteres")]
        [MaxLength(50, ErrorMessage = " No máximo 50 caracteres")]
        [Display(Name = "Email da Instituicao")]
        public string InstituicaoEmail { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = " No mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = " No máximo 50 caracteres")]
        [Display(Name = "Endereço da Instituicao")]
        public string InstituicaoEndereco { get; set; }
        public Categoria Categoria { get; set; } //asp:DropDownList
        public Animal Animal { get; set; }  //asp:DropDownList
    }
}