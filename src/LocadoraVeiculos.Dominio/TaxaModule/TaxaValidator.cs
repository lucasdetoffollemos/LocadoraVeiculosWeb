using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.TaxaModule
{
    public class TaxaValidator : AbstractValidator<Taxa>
    {
        public TaxaValidator()
        {
            RuleFor(parceiro => parceiro.Nome).NotNull().NotEmpty().WithMessage("O nome da taxa é obrigatório.");

            RuleFor(parceiro => parceiro.Valor).NotNull().NotEmpty().WithMessage("O valor da taxa é obrigatório.");
            
            RuleFor(parceiro => parceiro.TipoTaxa).NotNull().NotEmpty().WithMessage("O tipo da taxa é obrigatório.");
        }
    
    }
}
