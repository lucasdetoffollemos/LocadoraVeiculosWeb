using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.ViewModels
{
  

    public class TaxaListViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string TipoTaxa { get; set; }

    }

    public class TaxaDetailsViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int TipoTaxa { get; set; }

        //public List<Locacao> Locacoes { get; set; }
    }

    public class TaxaCreateViewModel
    {
        [Required(ErrorMessage = "Campo nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo valor é obrigatório.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Campo tipo de taxa é obrigatório.")]
        public int TipoTaxa { get; set; }
    }

    public class TaxaEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo valor é obrigatório.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Campo tipo de taxa é obrigatório.")]
        public int TipoTaxa { get; set; }
    }
}
