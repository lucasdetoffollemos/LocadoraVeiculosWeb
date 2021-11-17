using LocadoraVeiculos.Dominio.Shared;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.TaxaModule
{
    public interface ITaxaRepository :
        IRepository<Taxa, int>,
        IReadOnlyRepository<Taxa, int>
    {
        List<Taxa> SelecionarTaxasNaoAdicionadas(List<Taxa> taxasJaAdicionadas);
    }
}
