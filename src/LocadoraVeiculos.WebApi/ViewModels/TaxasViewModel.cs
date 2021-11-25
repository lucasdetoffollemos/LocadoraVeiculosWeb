using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.ViewModels
{
  

    public class TaxasListViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int TipoTaxa { get; set; }

    }

    public class TaxasDetailsViewModel
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int TipoTaxa { get; set; }

        //public List<Locacao> Locacoes { get; set; }
    }

    public class TaxasCreateViewModel
    {
        [Required(ErrorMessage = "Campo nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo valor é obrigatório.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Campo tipo de taxa é obrigatório.")]
        public int TipoTaxa { get; set; }
    }

    public class TaxasEditViewModel
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
