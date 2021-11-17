using LocadoraVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.CupomModule
{
    public interface ICupomRepository : IRepository<Cupom, int>, IReadOnlyRepository<Cupom, int>
    {
        /// <summary>
        /// Seleciona os cupons ativos
        /// </summary>
        /// <returns></returns>
        List<Cupom> SelecionarCuponsAtivos(DateTime dataAtual);

        Cupom SelecionarPorId(int id, bool carregarParceiro = false);


    }
}
