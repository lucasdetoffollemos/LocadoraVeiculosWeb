using LocadoraVeiculos.Dominio.GrupoVeiculoModule;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.ORM.GrupoVeiculoModule
{
    public class GrupoVeiculoOrmDao : RepositoryOrmBase<GrupoVeiculo, int>,
        IGrupoVeiculoRepository
    {
        public GrupoVeiculoOrmDao(LocadoraDbContext db) : base(db)
        {
        }

        public List<GrupoVeiculo> SelecionarTodos(bool carregarPlanos = false)
        {
            List<GrupoVeiculo> gruposComPlanos = null;

            gruposComPlanos = dbSet
                .Include(x => x.PlanosCobranca)
                .Include(x => x.Veiculos)
                .ToList();
            
            gruposComPlanos = dbSet.ToList();

            return gruposComPlanos;
        }

        public override GrupoVeiculo SelecionarPorId(int id)
        {
           var grupoVeiculo = dbSet
                .Include(x => x.PlanosCobranca)
                .Include(x => x.Veiculos)
                .SingleOrDefault(x => x.Id.Equals(id));



            return grupoVeiculo;
        }
    }
}
