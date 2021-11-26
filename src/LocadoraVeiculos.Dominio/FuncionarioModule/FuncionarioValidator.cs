using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.FuncionarioModule
{
    public class FuncionarioValidator : AbstractValidator<Funcionario>
    {
        public FuncionarioValidator()
        {
            RuleFor(funcionario => funcionario.Nome).NotNull().NotEmpty().WithMessage("O campo nome é obrigatório.");

            RuleFor(funcionario => funcionario.Usuario).NotNull().NotEmpty().WithMessage("O campo de usuario é obrigatório.");

            RuleFor(funcionario => funcionario.Senha).NotNull().NotEmpty().WithMessage("O campo senha é obrigatório.");

            RuleFor(funcionario => funcionario.DataAdmissao).NotNull().NotEmpty().WithMessage("O campo de data de adimissão é obrigatório.");

            RuleFor(funcionario => funcionario.Salario).NotNull().NotEmpty().WithMessage("O campo salario é obrigatório.").GreaterThan(0).WithMessage("O salario precisa ser maior do que 0");
        }

     
    }
}
