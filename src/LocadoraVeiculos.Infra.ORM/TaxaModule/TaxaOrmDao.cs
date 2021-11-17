using LocadoraVeiculos.Dominio.TaxaModule;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Infra.ORM.TaxaModule
{
    public class TaxaOrmDao : RepositoryOrmBase<Taxa, int>, ITaxaRepository
    {
        public TaxaOrmDao(LocadoraDbContext db) : base(db)
        {
        }

        public List<Taxa> SelecionarTaxasNaoAdicionadas(List<Taxa> taxasJaAdicionadas)
        {
            throw new NotImplementedException();
        }
    }
}
