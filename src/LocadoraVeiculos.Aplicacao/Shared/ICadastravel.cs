using LocadoraVeiculos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.Shared
{
    public interface ICadastravel<T> where T : EntidadeBase<int>
    {
        public bool InserirNovo(T registro);
        public bool Editar(int id, T registro);
        public bool Existe(int id);
        public bool Excluir(int id);
        public List<T> SelecionarTodos();
        public T SelecionarPorId(int id);

    }
}
