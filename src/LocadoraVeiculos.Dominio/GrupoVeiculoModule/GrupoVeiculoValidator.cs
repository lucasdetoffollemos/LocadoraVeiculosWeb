using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.GrupoVeiculoModule
{
    public class GrupoVeiculoValidator : AbstractValidator<GrupoVeiculo>
    {
        public GrupoVeiculoValidator()
        {
            RuleFor(gp => gp.Nome).NotNull().NotEmpty().WithMessage("O campo nome é obrigatório.");

            

        }

    
    }
}
