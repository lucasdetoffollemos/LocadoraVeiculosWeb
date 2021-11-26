using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.CupomModule
{
    public class CupomValidator : AbstractValidator<Cupom>
    {


        public CupomValidator()
        {
            RuleFor(cupom => cupom.Nome).NotNull().NotEmpty().WithMessage("O nome do cupom é obrigatório.");

            RuleFor(cupom => cupom.ParceiroId).NotNull().NotEmpty().WithMessage("O campo parceiro é obrigatório.");

            RuleFor(cupom => cupom.Valor).NotNull().NotEmpty().WithMessage("O campo valor é obrigatório.");

            RuleFor(cupom => cupom.ValorMinimo).NotNull().NotEmpty().WithMessage("Campo valor minimo é obrigatório").GreaterThanOrEqualTo(cupom => cupom.Valor).WithMessage("Campo valor minimo preceisa ser maior ou igual ao valor");

            RuleFor(cupom => cupom.DataValidade).NotNull().NotEmpty().WithMessage("Campo data de validade é obrigatório");

            //RuleFor(cupom => (int)cupom.Tipo).NotEmpty().WithMessage("Campo tipo é obrigatório");



        }
    }
}
