using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.ViewModels
{
    public class CupomListViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string ParceiroNome { get; set; }

        public DateTime DataValidade { get; set; }

        public decimal Valor { get; set; }

        public decimal ValorMinimo { get; set; }

        public string Tipo { get; set; }
    }

    public class CupomDetailsViewModel
    {
        public int Id { get; set; }

        public int ParceiroId { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataValidade { get; set; }

        public decimal ValorMinimo { get; set; }

        public int Tipo { get; set; }
    }    

    public class CupomCreateViewModel
    {
        public int ParceiroId { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataValidade { get; set; }

        public decimal ValorMinimo { get; set; }

        public int Tipo { get; set; }
    }

    public class CupomEditViewModel
    {
        public int Id { get; set; }

        public int ParceiroId { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataValidade { get; set; }

        public decimal ValorMinimo { get; set; }

        public int Tipo { get; set; }
    }
}
