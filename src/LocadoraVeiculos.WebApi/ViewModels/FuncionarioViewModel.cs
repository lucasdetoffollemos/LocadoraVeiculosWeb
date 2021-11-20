using System;
using System.Collections.Generic;
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
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public DateTime DataAdmissao { get; set; }
        public double Salario { get; set; }
    }

    public class FuncionarioEditViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public DateTime DataAdmissao { get; set; }
        public double Salario { get; set; }
    }
}
