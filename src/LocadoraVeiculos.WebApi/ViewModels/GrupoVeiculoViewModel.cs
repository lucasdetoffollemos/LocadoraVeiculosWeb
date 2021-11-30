using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.ViewModels
{
    public class GrupoVeiculoViewModel
    {
        public class PlanoCobrancaDetailViewModel
        {
            public int Id { get; set; }

            public decimal ValorDia { get; set; }

            public int KilometragemLivreInclusa { get; set; }

            public decimal ValorKMRodado { get; set; }

            public string TipoPlano { get; set; }
        }

        public class PlanoCobrancaCreateViewModel
        {
            public decimal ValorDia { get; set; }

            public int KilometragemLivreInclusa { get; set; }

            public decimal ValorKMRodado { get; set; }
        }

        public class GrupoVeiculoListViewModel
        {
            public int Id { get; set; }
            public string Nome { get; set; }

            public List<PlanoCobrancaDetailViewModel> PlanosCobranca { get; set; }

        }

        public class GrupoVeiculoDetailsViewModel
        {
            public int Id { get; set; }
            public string Nome { get; set; }

            public List<PlanoCobrancaDetailViewModel> PlanosCobranca { get; set; }

        }

        public class GrupoVeiculoCreateViewModel
        {
            [Required(ErrorMessage = "Campo nome é obrigatório.")]
            public string Nome { get; set; }

            public List<PlanoCobrancaCreateViewModel> PlanosCobranca { get; set; }
        }

        public class GrupoVeiculoEditViewModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Campo nome é obrigatório.")]
            public string Nome { get; set; }

            public List<PlanoCobrancaCreateViewModel> PlanosCobranca { get; set; }
        }
    }
}
