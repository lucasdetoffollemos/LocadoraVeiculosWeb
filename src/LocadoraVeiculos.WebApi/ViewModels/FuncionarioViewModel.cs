using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.ViewModels
{
    public class FuncionarioListViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataAdmissao { get; set; }
        public double Salario { get; set; }

    }

    public class FuncionarioDetailsViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public double Salario { get; set; }
        public string Senha { get; set; }
    }

    public class FuncionarioCreateViewModel
    {
        [Required(ErrorMessage = "Campo nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo usuário é obrigatório.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo data admissão é obrigatório.")]
        public DateTime DataAdmissao { get; set; }

        [Required(ErrorMessage = "O campo salario é obrigatório.")]
        public double Salario { get; set; }
    }

    public class FuncionarioEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo usuário é obrigatório.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo data admissão é obrigatório.")]
        public DateTime DataAdmissao { get; set; }

        [Required(ErrorMessage = "O campo salario é obrigatório.")]
        public double Salario { get; set; }
    }
}
