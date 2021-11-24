using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.CupomModule
{
    public class ParceiroValidator: AbstractValidator<Parceiro>
    {
        public ParceiroValidator()
        {
            RuleFor(parceiro => parceiro.Nome).NotNull().NotEmpty().WithMessage("O nome do parceiro é obrigatório.");
        }
    }
}
